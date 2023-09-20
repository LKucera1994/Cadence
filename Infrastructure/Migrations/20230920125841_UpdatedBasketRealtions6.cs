using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "127ad9c4-5604-468f-94fc-1006633e14d0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "af733e7d-98e3-4e3c-a810-34ebfa6d0ccb", 0, "TestCity", "8087ddd5-d514-44be-8ac9-8b575f4667d4", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAED4CafJuGw2N3+2v7dtqz6MaUnXWlXVtl2w3BrJPNERzhlnqkC9RLQxewYl3G8Yr6Q==", null, false, "0907eba1-6569-49fd-85f4-61a4dfa670b9", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af733e7d-98e3-4e3c-a810-34ebfa6d0ccb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "127ad9c4-5604-468f-94fc-1006633e14d0", 0, "TestCity", "61b095bf-6c93-4ed9-8fa5-f1e34cd19b58", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEEyt78/QFUykRh0N6P51dRMIywOFVDdn+FDCEuOmZkSyyq8o/pBuZ2/EAPetVEDXLQ==", null, false, "20a59e2a-0b7d-4938-996b-98e5ea8d41d5", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
