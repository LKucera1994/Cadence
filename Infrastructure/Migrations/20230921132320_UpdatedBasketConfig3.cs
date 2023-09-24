using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketConfig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bb7a68e-9bbf-455a-b442-0a0694657e52");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "b8f4977d-da6b-4aac-a3e5-2f11a2ddc36a", 0, "TestCity", "b4b88cb8-5065-4036-adef-b2cbd2387bef", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAECjDjz1sD4CDzWBGo8hAviOmEZ6garUUR8gaqrXQWQmQFG4aBM1jNiLPK2CtkvRiJw==", null, false, "d7798d2b-f8e1-4662-8755-a4e54ae9fb61", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8f4977d-da6b-4aac-a3e5-2f11a2ddc36a");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "1bb7a68e-9bbf-455a-b442-0a0694657e52", 0, "TestCity", "a67dded7-281e-4a3e-aa64-d3cf71884b56", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEMirFIHRNAQh9UbwB12krooZ1BV+ygZNbhPA5lcWg64yjB4lFlKkIGdD3rjc9UOqgQ==", null, false, "6741980a-7e1a-42e3-b2bf-379c9ede4681", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
