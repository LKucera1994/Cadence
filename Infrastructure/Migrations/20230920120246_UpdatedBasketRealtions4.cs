using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6f60a04-88a3-4964-992e-6714c54ebc55");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "fa6d6319-b749-429a-a1bb-84dbe2d25d15", 0, "TestCity", "a763b1a1-97d6-4053-81a1-733f0bd9dd02", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEO/ueVrSBovKC+314A9zi13P1ZkLDe1Z1glmZRkheGYLYavohksPrzERNt7tIVeRnw==", null, false, "36d3512f-cecf-409d-8b6d-004295ee9fde", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa6d6319-b749-429a-a1bb-84dbe2d25d15");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "b6f60a04-88a3-4964-992e-6714c54ebc55", 0, "TestCity", "d1ec822d-c7b2-4768-8d60-b58029d4a312", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEAVfetSVtfMDjZ6+471hhecR4KpP39vVmYrB969yf3pNAXWlh2P9tWFqanhnxEKx2w==", null, false, "3adbf77f-4680-4314-a936-4ee4f2574ee8", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
