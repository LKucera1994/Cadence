using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketConfig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8f4977d-da6b-4aac-a3e5-2f11a2ddc36a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "b8f4977d-da6b-4aac-a3e5-2f11a2ddc36a", 0, "TestCity", "b4b88cb8-5065-4036-adef-b2cbd2387bef", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAECjDjz1sD4CDzWBGo8hAviOmEZ6garUUR8gaqrXQWQmQFG4aBM1jNiLPK2CtkvRiJw==", null, false, "d7798d2b-f8e1-4662-8755-a4e54ae9fb61", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}
