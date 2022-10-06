using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductBrands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nite" },
                    { 2, "Speed" },
                    { 3, "Despair" },
                    { 4, "Bassos" },
                    { 5, "Porco Bicycles" },
                    { 6, "Pavic Parts" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boards" },
                    { 2, "Hats" },
                    { 3, "Boots" },
                    { 4, "Gloves" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PhotoUrl", "Price", "ProductBrandId", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, "Sample Description", "Nite Speedster Board 2000", "images/products/sb-ang1.png", 200m, 1, 1 },
                    { 2, "Sample Description", "Green Nite Board 3000", "images/products/sb-ang2.png", 150m, 1, 1 },
                    { 3, "Sample Description", "Speed Board Speed Rush 3", "images/products/sb-core1.png", 180m, 2, 1 },
                    { 4, "Sample Description", "Speed Super Board", "images/products/sb-core2.png", 300m, 2, 1 },
                    { 5, "Sample Description", "Bassos Board Super Whizzy Fast", "images/products/sb-react1.png", 250m, 4, 1 },
                    { 6, "Sample Description", "Porco Bicycles Entry Board", "images/products/sb-ts1.png", 120m, 5, 1 },
                    { 7, "Sample Description", "Speed Blue Hat", "images/products/hat-core1.png", 10m, 2, 2 },
                    { 8, "Sample Description", "Green Bassos Woolen Hat", "images/products/hat-react1.png", 8m, 4, 2 },
                    { 9, "Sample Description", "Purple Bassos Woolen Hat", "images/products/hat-react2.png", 15m, 4, 2 },
                    { 10, "Sample Description", "Blue Despair Gloves", "images/products/glove-code1.png", 18m, 3, 4 },
                    { 11, "Sample Description", "Green Despair Gloves", "images/products/glove-code2.png", 15m, 3, 4 },
                    { 12, "Sample Description", "Purple Bassos Gloves", "images/products/glove-react1.png", 16m, 4, 4 },
                    { 13, "Sample Description", "Green Bassos Gloves", "images/products/glove-react2.png", 14m, 4, 4 },
                    { 14, "Sample Description", "Pavic Parts Red Boots", "images/products/boot-redis1.png", 250m, 6, 3 },
                    { 15, "Sample Description", "Speed Boots", "images/products/boot-core2.png", 189m, 2, 3 },
                    { 16, "Sample Description", "Speed Purple Boots", "images/products/boot-core1.png", 199m, 2, 3 },
                    { 17, "Sample Description", "Nite Purple Boots", "images/products/boot-ang2.png", 150m, 1, 3 },
                    { 18, "Sample Description", "Nite Blue Boots", "images/products/boot-ang1.png", 180m, 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductBrands",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
