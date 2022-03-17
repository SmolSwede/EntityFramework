using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LangID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LangID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_People_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguages",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false),
                    LangID = table.Column<int>(nullable: false),
                    PersonLanguageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguages", x => new { x.LangID, x.PersonID });
                    table.ForeignKey(
                        name: "FK_PersonLanguages_Languages_LangID",
                        column: x => x.LangID,
                        principalTable: "Languages",
                        principalColumn: "LangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguages_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryName" },
                values: new object[,]
                {
                    { 1, "Sweden" },
                    { 2, "Norway" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LangID", "LangName" },
                values: new object[,]
                {
                    { 1, "Swedish" },
                    { 2, "Norwegian" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName", "CountryID" },
                values: new object[] { 1, "Tibro", 1 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName", "CountryID" },
                values: new object[] { 2, "Oslo", 2 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "CityID", "FirstName", "LastName" },
                values: new object[] { 1, 1, "Simon", "Simonsson" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "CityID", "FirstName", "LastName" },
                values: new object[] { 2, 2, "Gustav", "Gustavsson" });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "LangID", "PersonID", "PersonLanguageID" },
                values: new object[] { 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "LangID", "PersonID", "PersonLanguageID" },
                values: new object[] { 1, 2, 0 });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "LangID", "PersonID", "PersonLanguageID" },
                values: new object[] { 2, 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityID",
                table: "People",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_PersonID",
                table: "PersonLanguages",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
