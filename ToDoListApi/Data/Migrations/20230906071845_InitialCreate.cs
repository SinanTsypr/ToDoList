using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Done", "Title" },
                values: new object[,]
                {
                    { 1, false, "Morning exercise" },
                    { 2, false, "Read for 30 minutes" },
                    { 3, false, "Work on project tasks" },
                    { 4, false, "Lunch break" },
                    { 5, true, "Attend team meeting" },
                    { 6, true, "Complete work tasks" },
                    { 7, true, "Dinner" },
                    { 8, true, "Relax and unwind" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");
        }
    }
}
