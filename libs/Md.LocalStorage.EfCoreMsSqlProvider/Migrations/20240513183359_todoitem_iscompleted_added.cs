using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Md.LocalStorage.EfCoreMsSqlProvider.Migrations
{
    /// <inheritdoc />
    public partial class todoitem_iscompleted_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDateTime",
                table: "ToDoItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ToDoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDateTime",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ToDoItems");
        }
    }
}
