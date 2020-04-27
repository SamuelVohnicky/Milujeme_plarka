using Microsoft.EntityFrameworkCore.Migrations;

namespace Milujeme_plarka.Migrations
{
    public partial class pls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "4a5f2630-a821-4e56-b0e5-d4e9c0031d42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "87add2f0-192a-42e6-b986-05bc2519d4e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "977cbbbb-4539-4bf8-bec1-9ad35b5ef3f3", "AQAAAAEAACcQAAAAEM6AZ4cE0KSFSAfDB+J7pzsfquuXnI/LXLu3f6P474XRv4WDOG96mC+cqBqF7Z/W9Q==" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "ChampionId", "ChampionName", "Mellee" },
                values: new object[,]
                {
                    { 2, "b", true },
                    { 3, "c", true },
                    { 4, "d", true },
                    { 5, "e", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 5);

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
