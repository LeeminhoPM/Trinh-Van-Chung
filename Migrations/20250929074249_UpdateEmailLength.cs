using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChungTrinhj.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmailLength : Migration
    {

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Employee",
                nullable: true,
                type: "nvarchar(200)",
                maxLength: 200,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldType: "nvarchar(20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
