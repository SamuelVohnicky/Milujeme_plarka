using Microsoft.EntityFrameworkCore.Migrations;

namespace Milujeme_plarka.Migrations
{
    public partial class ahoj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Champions",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Champions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "1c17d32c-c9f6-4ad4-9aa6-84f370dcc1a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "bc396df5-79d2-4bcc-9986-2cff409b8780");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9591580b-dee9-4aff-8449-0f670ac6b674", "AQAAAAEAACcQAAAAEDYG4/ibEe5dlW1Q+n83Iq7HB6dVAqzJUqZOH3EF/XsU1+Nn+K85b17b+7aHjmM/pw==" });
        }
    }
}
