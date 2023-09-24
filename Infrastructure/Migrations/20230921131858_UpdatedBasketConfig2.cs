using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketConfig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "baee63f2-526c-4b07-b01b-26aed3e1f092");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "1bb7a68e-9bbf-455a-b442-0a0694657e52", 0, "TestCity", "a67dded7-281e-4a3e-aa64-d3cf71884b56", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEMirFIHRNAQh9UbwB12krooZ1BV+ygZNbhPA5lcWg64yjB4lFlKkIGdD3rjc9UOqgQ==", null, false, "6741980a-7e1a-42e3-b2bf-379c9ede4681", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bb7a68e-9bbf-455a-b442-0a0694657e52");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "baee63f2-526c-4b07-b01b-26aed3e1f092", 0, "TestCity", "b832a9a1-5cca-4cb9-a740-41bcec04135e", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEN2zGd3ABN9XjaChtT6SDTNZoZPIvi+lG1H15cF1fTyzDtfiAL4LgmqEGF2x4lvtaQ==", null, false, "a3da6ce2-e987-488e-bb9d-51620b5f4a37", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
