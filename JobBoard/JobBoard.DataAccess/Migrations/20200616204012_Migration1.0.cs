using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.DataAccess.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ExpiresAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedAt", "Description", "ExpiresAt", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 16, 14, 40, 11, 704, DateTimeKind.Local).AddTicks(4372), ".NET Developer", new DateTime(2020, 7, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(3922), ".NET Developer" },
                    { 2, new DateTime(2020, 6, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4874), "QA Analyst", new DateTime(2020, 7, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4889), "QA Analyst" },
                    { 3, new DateTime(2020, 6, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4908), "Backend Developer", new DateTime(2020, 7, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4909), "Backend Developer" },
                    { 4, new DateTime(2020, 6, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4912), "Frontend Developer", new DateTime(2020, 7, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4913), "Frontend Developer" },
                    { 5, new DateTime(2020, 6, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4915), "DevOps Engineer", new DateTime(2020, 7, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4917), "DevOps Engineer" },
                    { 6, new DateTime(2020, 6, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4919), "Dev Manager", new DateTime(2020, 7, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4920), "Dev Manager" },
                    { 7, new DateTime(2020, 6, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4922), "React Developer", new DateTime(2020, 7, 16, 14, 40, 11, 706, DateTimeKind.Local).AddTicks(4923), "React Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
