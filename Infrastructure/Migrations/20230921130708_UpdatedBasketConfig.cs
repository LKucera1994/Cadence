using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "57302ea4-2d57-43af-b201-684c954e5c0d");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                newName: "BasketItem");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_UserBasketId",
                table: "BasketItem",
                newName: "IX_BasketItem_UserBasketId");

            migrationBuilder.AlterColumn<string>(
                name: "UserBasketId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "0f3201bf-f66c-44c2-b137-44901efa0f60", 0, "TestCity", "82d2ff22-1ee8-4efe-9624-73b6d44ae753", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEEM7lPSRnaXthqDOFjLvPbKrNJnfHUYmrjzRBi68cRw0uIFDCd+7Yc4tZ8z+mGt9zg==", null, false, "d8c1d6a7-d904-42de-95f7-4ab2f2b8d99f", "TestState", "TestStreet", false, "steve@test.com", "1111" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_UserBaskets_UserBasketId",
                table: "BasketItem",
                column: "UserBasketId",
                principalTable: "UserBaskets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "0f3201bf-f66c-44c2-b137-44901efa0f60");

            migrationBuilder.RenameTable(
                name: "BasketItem",
                newName: "BasketItems");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_UserBasketId",
                table: "BasketItems",
                newName: "IX_BasketItems_UserBasketId");

            migrationBuilder.AlterColumn<string>(
                name: "UserBasketId",
                table: "BasketItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "57302ea4-2d57-43af-b201-684c954e5c0d", 0, "TestCity", "c3849ba4-a1c5-4c02-8112-03b1e0b27863", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEM3lJPfSwtrMGDJyzGuazOd+QkiPfI1zaN5bPhSUnomfMp9OBLxlT3wYFDLlvIePKw==", null, false, "d9955a9f-f3ba-4d8b-9019-04181e1cf605", "TestState", "TestStreet", false, "steve@test.com", "1111" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_UserBaskets_UserBasketId",
                table: "BasketItems",
                column: "UserBasketId",
                principalTable: "UserBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
