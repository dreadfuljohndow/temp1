using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Md.LocalStorage.EfCoreMsSqlProvider.Migrations
{
    /// <inheritdoc />
    public partial class add_projects_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "ToDoItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ProjectId",
                table: "ToDoItems",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Projects_ProjectId",
                table: "ToDoItems",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Projects_ProjectId",
                table: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ProjectId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ToDoItems");
        }
    }
}
