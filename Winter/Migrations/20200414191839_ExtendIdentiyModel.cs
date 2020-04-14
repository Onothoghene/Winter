using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Winter.Migrations
{
    public partial class ExtendIdentiyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ext",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FileUniqueName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UrlUniqueName",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Product",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Order",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Order",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Order",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Category",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(nullable: true),
                    FileUniqueName = table.Column<string>(nullable: true),
                    ProductUrl = table.Column<string>(nullable: true),
                    ProductUrlUniqueName = table.Column<string>(nullable: true),
                    Ext = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFile_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFile_ProductId",
                table: "ProductFile",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFile");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Product",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ext",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileUniqueName",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlUniqueName",
                table: "Product",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Order",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Order",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Category",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
