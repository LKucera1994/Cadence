using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f36aa2b4-2207-444b-b816-5cb49618bbb8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "57302ea4-2d57-43af-b201-684c954e5c0d", 0, "TestCity", "c3849ba4-a1c5-4c02-8112-03b1e0b27863", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEM3lJPfSwtrMGDJyzGuazOd+QkiPfI1zaN5bPhSUnomfMp9OBLxlT3wYFDLlvIePKw==", null, false, "d9955a9f-f3ba-4d8b-9019-04181e1cf605", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57302ea4-2d57-43af-b201-684c954e5c0d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "f36aa2b4-2207-444b-b816-5cb49618bbb8", 0, "TestCity", "248fb8cb-5b0f-445c-a440-ac07bf8da083", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAELQ6oXfmSJtYgKDh3hzuNzm5BF6f4FNnP8sLSG2ZW3JPiYyOAZ+016EvmgHBbOiqlw==", null, false, "5ae66e3f-b036-493b-b842-a3ce6c53a548", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
