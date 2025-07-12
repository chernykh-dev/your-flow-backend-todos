using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoService.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_completed",
                table: "todo_items",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_completed",
                table: "todo_items");
        }
    }
}
