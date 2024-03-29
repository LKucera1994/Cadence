
using API.Extensions;
using Core.Entities.Identity;
using Infrastructure.Configurations;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repository;
using Infrastructure.Data.Repository.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(connectionString); 
    });


builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var options = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
    return ConnectionMultiplexer.Connect(options);
});


builder.Services.AddIdentityCore<AppUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 10;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    
})  
    .AddEntityFrameworkStores<DataContext>()
    .AddSignInManager<SignInManager<AppUser>>();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddCors(options=>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("https://localhost:4200");
    });
});



builder.Services.AddControllers().AddJsonOptions(x=>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<IResponseCacheService, ResponseCacheService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped(typeof(UserManager<AppUser>), typeof(UserManager<AppUser>));
builder.Services.AddScoped(typeof(SignInManager<AppUser>), typeof(SignInManager<AppUser>));

builder.Services.AddControllers();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = false
        };
    }

);
builder.Services.AddAuthorization();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();  
    
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");

app.UseAuthentication();    
app.UseAuthorization();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var userManager = services.GetRequiredService<UserManager<AppUser>>();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback");
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Content")),
    RequestPath = "/Content"
});

var context = services.GetRequiredService<DataContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
    
}
catch (Exception ex)
{
    logger.LogError(ex, "Error during migration");

}



app.Run();
