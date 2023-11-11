using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLitrInFastFoodMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "FastFoods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "FastFoods",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
