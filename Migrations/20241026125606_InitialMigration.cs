using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace toDoList.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Personal" }
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "DueDate", "Importance", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 26, 12, 56, 4, 978, DateTimeKind.Utc).AddTicks(8172), "Complete the report by Friday", new DateTime(2024, 10, 29, 12, 56, 4, 978, DateTimeKind.Utc).AddTicks(8179), 1, false, "Finish project report" },
                    { 2, 2, new DateTime(2024, 10, 26, 12, 56, 4, 978, DateTimeKind.Utc).AddTicks(8189), "With xyz boys ", new DateTime(2024, 10, 27, 12, 56, 4, 978, DateTimeKind.Utc).AddTicks(8189), 1, false, "Futsal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_CategoryId",
                table: "ToDoItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
