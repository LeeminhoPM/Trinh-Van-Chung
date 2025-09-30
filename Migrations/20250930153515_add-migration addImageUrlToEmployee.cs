using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChungTrinhj.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationaddImageUrlToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Employee");
        }
    }
}
