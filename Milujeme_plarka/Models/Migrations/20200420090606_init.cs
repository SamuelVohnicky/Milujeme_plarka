using Microsoft.EntityFrameworkCore.Migrations;

namespace Milujeme_plarka.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    ChampionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionName = table.Column<string>(nullable: false),
                    Mellee = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.ChampionId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    Mellee = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    QuestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestQuote = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    QuestGamePhase = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.QuestId);
                });

            migrationBuilder.CreateTable(
                name: "Summoners",
                columns: table => new
                {
                    SummonerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SummonerName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summoners", x => x.SummonerId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", "96bedf8f-8558-4436-bc92-74fced642167", "Administrator", null },
                    { "User", "c6e7b2ce-df2c-499e-9f40-9e782d339553", "Uživatel", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "ADMINUSER", 0, "5bc22651-faba-469f-9e77-9061c7873a19", "ApplicationUser", "josef.simunek@pslib.cz", true, false, null, "JOSEF.SIMUNEK@PSLIB.CZ", "ADMIN", "AQAAAAEAACcQAAAAELJDJ4ym1+k0G5z0ZwHY87bEuvy2hJvy/cvb4pGsrc6y8D76OyjeWsaWooUu6tqOxQ==", null, false, "", false, "admin", "Main", "Administrator" });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "ChampionId", "ChampionName", "Mellee" },
                values: new object[] { 1, "Aatrox", true });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemName", "Mellee" },
                values: new object[] { 1, "Rabadon", true });

            migrationBuilder.InsertData(
                table: "Quests",
                columns: new[] { "QuestId", "QuestGamePhase", "QuestQuote", "Role" },
                values: new object[] { 1, 1, "Chcipni", 1 });

            migrationBuilder.InsertData(
                table: "Summoners",
                columns: new[] { "SummonerId", "SummonerName" },
                values: new object[] { 1, "Heal" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ADMINUSER", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Summoners");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ADMINUSER", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
