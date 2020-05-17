using Microsoft.EntityFrameworkCore.Migrations;

namespace Milujeme_plarka.Migrations
{
    public partial class ajoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Quests");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Summoners",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "08e72f62-d299-45d2-b6a3-5a30f34f2ab5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "4510c009-c514-4de6-a287-818da26f4ac6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d7604ec-b824-4c5e-abf0-af0a7d42db06", "AQAAAAEAACcQAAAAEF0qNsAg8Tb/MJCOEbp3PjXdIKpjC5XK6yxphFCCgaCzm/Mcm8v8cWjvAmSlygekRw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Summoners");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "9c1175cf-5671-4aff-9f41-041d6c126913");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "dc53988e-016b-4f44-a27b-3532434999d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94422b44-8216-4736-b57f-a2781a35f50a", "AQAAAAEAACcQAAAAEMMxauaAAQxYoCrpa0YZ6TvsNmbr5m3yH8QsrVTx8WROXpE4aSvwpDPbzQaZHXyHvA==" });
        }
    }
}
