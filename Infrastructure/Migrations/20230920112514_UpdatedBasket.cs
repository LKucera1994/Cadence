using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "014bbc8e-3cb0-40c7-aeb0-344eec4eb0ef");

            migrationBuilder.CreateTable(
                name: "UserBaskets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBaskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBasketId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItem_UserBaskets_UserBasketId",
                        column: x => x.UserBasketId,
                        principalTable: "UserBaskets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "43e80132-bf33-4030-b2ed-02bf7a339f19", 0, "TestCity", "a2a7bdba-0955-4ba2-a938-94e3f53636b9", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEPMYXc679tc67YfL0FNcdxfOdbZjCPy2txA+FLTNxV1q8Se2LJKT2O9Hbs1NXvCkug==", null, false, "80bc8f48-d8bf-4a10-80be-c44d04c643c8", "TestState", "TestStreet", false, "steve@test.com", "1111" });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_UserBasketId",
                table: "BasketItem",
                column: "UserBasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "UserBaskets");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43e80132-bf33-4030-b2ed-02bf7a339f19");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "014bbc8e-3cb0-40c7-aeb0-344eec4eb0ef", 0, "TestCity", "44e4bedf-916a-4441-b262-9ab1d525912c", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEP+tZmJJGcNr6H2xCq1GiQQynfXO/Ix2FsCjRJj3HdunMQjlYg/h0ZOlz+iWMbmdqg==", null, false, "a5507695-cad4-4066-becd-e97d7c27256b", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
