﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedBasketRealtions3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9ce0803-a730-4740-8665-1f74d8df55b3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "b6f60a04-88a3-4964-992e-6714c54ebc55", 0, "TestCity", "d1ec822d-c7b2-4768-8d60-b58029d4a312", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEAVfetSVtfMDjZ6+471hhecR4KpP39vVmYrB969yf3pNAXWlh2P9tWFqanhnxEKx2w==", null, false, "3adbf77f-4680-4314-a936-4ee4f2574ee8", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6f60a04-88a3-4964-992e-6714c54ebc55");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "a9ce0803-a730-4740-8665-1f74d8df55b3", 0, "TestCity", "5a8bbc22-30f4-40e3-963d-023a75ee1b2e", "Steve", "steve@test.com", false, "Steve", "Stevenson", false, null, "STEVE@TEST.COM", "STEVE@TEST.COM", "AQAAAAEAACcQAAAAEIHqXXXvyC2ticupMazXeMvedHImXTM9DVSBtSL/MtdCeK4GtQ8IAn9tCkkYueX8LQ==", null, false, "8015e9f8-5b24-4e6e-9edb-1ec7c9151613", "TestState", "TestStreet", false, "steve@test.com", "1111" });
        }
    }
}