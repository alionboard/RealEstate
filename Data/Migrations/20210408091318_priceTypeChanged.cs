using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class priceTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Estates",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Estates",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
