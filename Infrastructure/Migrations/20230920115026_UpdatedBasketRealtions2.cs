using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7957d5a-bec8-4d8c-ae5b-8e020380d0db");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "a9ce0803-a730-4740-8665-1f74d8df55b3", 0, "TestCity", "5a8bbc22-30f4-40e3-963d-023a75ee1b2e", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEIHqXXXvyC2ticupMazXeMvedHImXTM9DVSBtSL/MtdCeK4GtQ8IAn9tCkkYueX8LQ==", null, false, "8015e9f8-5b24-4e6e-9edb-1ec7c9151613", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9ce0803-a730-4740-8665-1f74d8df55b3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "f7957d5a-bec8-4d8c-ae5b-8e020380d0db", 0, "TestCity", "4738345b-1480-4d7b-88ff-3e4093cd6660", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEOb73Mvo2Itfkxof+qfsqyhYd0B5kUZTMip01rb4rnfCqeCYijvpIosDmnTSP2jdrw==", null, false, "4bbf4d25-daf9-4d1b-a774-b0001b0ebe67", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
