using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_UserBaskets_UserBasketId",
                table: "BasketItem");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43e80132-bf33-4030-b2ed-02bf7a339f19");

            migrationBuilder.AlterColumn<string>(
                name: "UserBasketId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "f7957d5a-bec8-4d8c-ae5b-8e020380d0db", 0, "TestCity", "4738345b-1480-4d7b-88ff-3e4093cd6660", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEOb73Mvo2Itfkxof+qfsqyhYd0B5kUZTMip01rb4rnfCqeCYijvpIosDmnTSP2jdrw==", null, false, "4bbf4d25-daf9-4d1b-a774-b0001b0ebe67", "TestState", "TestStreet", false, "steve@test.com", "1111" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_UserBaskets_UserBasketId",
                table: "BasketItem",
                column: "UserBasketId",
                principalTable: "UserBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_UserBaskets_UserBasketId",
                table: "BasketItem");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7957d5a-bec8-4d8c-ae5b-8e020380d0db");

            migrationBuilder.AlterColumn<string>(
                name: "UserBasketId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "43e80132-bf33-4030-b2ed-02bf7a339f19", 0, "TestCity", "a2a7bdba-0955-4ba2-a938-94e3f53636b9", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEPMYXc679tc67YfL0FNcdxfOdbZjCPy2txA+FLTNxV1q8Se2LJKT2O9Hbs1NXvCkug==", null, false, "80bc8f48-d8bf-4a10-80be-c44d04c643c8", "TestState", "TestStreet", false, "steve@test.com", "1111" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_UserBaskets_UserBasketId",
                table: "BasketItem",
                column: "UserBasketId",
                principalTable: "UserBaskets",
                principalColumn: "Id");
        }
    }
}
