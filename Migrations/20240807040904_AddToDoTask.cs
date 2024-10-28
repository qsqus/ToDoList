using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    public partial class AddToDoTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Content", "IsCompleted" },
                values: new object[] { 1, "Do laundry", false });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Content", "IsCompleted" },
                values: new object[] { 2, "Eat dinner", false });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Content", "IsCompleted" },
                values: new object[] { 3, "Go to work", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoTasks");
        }
    }
}
