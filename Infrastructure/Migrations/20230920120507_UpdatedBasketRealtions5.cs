using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_UserBaskets_UserBasketId",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa6d6319-b749-429a-a1bb-84dbe2d25d15");

            migrationBuilder.RenameTable(
                name: "BasketItem",
                newName: "BasketItems");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_UserBasketId",
                table: "BasketItems",
                newName: "IX_BasketItems_UserBasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "127ad9c4-5604-468f-94fc-1006633e14d0", 0, "TestCity", "61b095bf-6c93-4ed9-8fa5-f1e34cd19b58", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEEyt78/QFUykRh0N6P51dRMIywOFVDdn+FDCEuOmZkSyyq8o/pBuZ2/EAPetVEDXLQ==", null, false, "20a59e2a-0b7d-4938-996b-98e5ea8d41d5", "TestState", "TestStreet", false, "steve@test.com", "1111" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_UserBaskets_UserBasketId",
                table: "BasketItems",
                column: "UserBasketId",
                principalTable: "UserBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_UserBaskets_UserBasketId",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "127ad9c4-5604-468f-94fc-1006633e14d0");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                newName: "BasketItem");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_UserBasketId",
                table: "BasketItem",
                newName: "IX_BasketItem_UserBasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "fa6d6319-b749-429a-a1bb-84dbe2d25d15", 0, "TestCity", "a763b1a1-97d6-4053-81a1-733f0bd9dd02", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEO/ueVrSBovKC+314A9zi13P1ZkLDe1Z1glmZRkheGYLYavohksPrzERNt7tIVeRnw==", null, false, "36d3512f-cecf-409d-8b6d-004295ee9fde", "TestState", "TestStreet", false, "steve@test.com", "1111" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_UserBaskets_UserBasketId",
                table: "BasketItem",
                column: "UserBasketId",
                principalTable: "UserBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
