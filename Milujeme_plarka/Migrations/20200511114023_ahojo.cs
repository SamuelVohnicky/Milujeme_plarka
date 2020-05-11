using Microsoft.EntityFrameworkCore.Migrations;

namespace Milujeme_plarka.Migrations
{
    public partial class ahojo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Items",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "73b158a3-2c3e-453c-8ed7-3a8d7e0436cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "4fd93892-9a14-49e1-ba7e-0382e97962be");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0aa58118-dc2a-4873-b6d7-e0841df50da9", "AQAAAAEAACcQAAAAEHzHzPAkU0TgWyZ/7s6yW3SBDM4YjOwLI4O6bo/U4OiI6ZzVfboMYOrgtBDrMb23tg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "1c86f84d-4f9a-4628-88e9-412c2af37810");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "0103e4d3-8624-4f7e-9916-81c2fd2d6ec0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b43b8e1f-170c-44ca-b7ad-9d0730e740d5", "AQAAAAEAACcQAAAAEAfzF8J8V+FqJQMbn1pBThg3OlsFpQ1G95nuixgfxH9xlFIqRrAPInC2o4dLKTifyQ==" });
        }
    }
}
