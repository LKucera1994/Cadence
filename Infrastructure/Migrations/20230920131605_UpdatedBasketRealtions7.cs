using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af733e7d-98e3-4e3c-a810-34ebfa6d0ccb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "f36aa2b4-2207-444b-b816-5cb49618bbb8", 0, "TestCity", "248fb8cb-5b0f-445c-a440-ac07bf8da083", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAELQ6oXfmSJtYgKDh3hzuNzm5BF6f4FNnP8sLSG2ZW3JPiYyOAZ+016EvmgHBbOiqlw==", null, false, "5ae66e3f-b036-493b-b842-a3ce6c53a548", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36aa2b4-2207-444b-b816-5cb49618bbb8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "af733e7d-98e3-4e3c-a810-34ebfa6d0ccb", 0, "TestCity", "8087ddd5-d514-44be-8ac9-8b575f4667d4", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAED4CafJuGw2N3+2v7dtqz6MaUnXWlXVtl2w3BrJPNERzhlnqkC9RLQxewYl3G8Yr6Q==", null, false, "0907eba1-6569-49fd-85f4-61a4dfa670b9", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
