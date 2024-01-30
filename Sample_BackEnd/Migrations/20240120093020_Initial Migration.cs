using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    TaskId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CompanyId = table.Column<string>(type: "longtext", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: false),
                    RequestedBy = table.Column<string>(type: "longtext", nullable: false),
                    AddedBy = table.Column<string>(type: "longtext", nullable: false),
                    AddedDate = table.Column<string>(type: "longtext", nullable: false),
                    AssignTo = table.Column<string>(type: "longtext", nullable: true),
                    UrgencyLevel = table.Column<string>(type: "longtext", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    ProjectIdentificationNumber = table.Column<string>(type: "longtext", nullable: true),
                    CallBackNumber = table.Column<string>(type: "longtext", nullable: true),
                    ChatLink = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.TaskId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskList");
        }
    }
}
