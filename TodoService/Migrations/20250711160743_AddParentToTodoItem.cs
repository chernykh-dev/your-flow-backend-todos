using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoService.Migrations
{
    /// <inheritdoc />
    public partial class AddParentToTodoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "parent_id",
                table: "todo_items",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_todo_items_parent_id",
                table: "todo_items",
                column: "parent_id");

            migrationBuilder.AddForeignKey(
                name: "fk_todo_items_todo_items_parent_id",
                table: "todo_items",
                column: "parent_id",
                principalTable: "todo_items",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_todo_items_todo_items_parent_id",
                table: "todo_items");

            migrationBuilder.DropIndex(
                name: "ix_todo_items_parent_id",
                table: "todo_items");

            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "todo_items");
        }
    }
}
