using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Daily.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dailies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Yesterday = table.Column<string>(nullable: false),
                    Today = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    NotDone = table.Column<string>(nullable: true),
                    Problems = table.Column<string>(nullable: true),
                    LinesOfCode = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dailies");
        }
    }
}
