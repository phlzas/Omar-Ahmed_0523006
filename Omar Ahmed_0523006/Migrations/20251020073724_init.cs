using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Omar_Ahmed_0523006.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compttion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatioon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateComp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compttion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speclatation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpYears = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_coaches_team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_player_team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teamCompttions",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CompttionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamCompttions", x => new { x.CompttionId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_teamCompttions_compttion_CompttionId",
                        column: x => x.CompttionId,
                        principalTable: "compttion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamCompttions_team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "compttion",
                columns: new[] { "Id", "DateComp", "Locatioon", "Titel" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "al_hdayk al_qopa", "WorldCup1" },
                    { 2, new DateTime(2005, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "al_hdayk al_qopa", "WorldCup2" },
                    { 3, new DateTime(2005, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "al_hdayk al_qopa", "WorldCup3" },
                    { 4, new DateTime(2005, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "al_hdayk al_qopa", "WorldCup4" }
                });

            migrationBuilder.InsertData(
                table: "team",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1, "last", "Manchester" },
                    { 2, "lastOflast", "Man" },
                    { 3, "lastOfoflast", "chester" },
                    { 4, "lastofofoflast", "misy" }
                });

            migrationBuilder.InsertData(
                table: "coaches",
                columns: new[] { "Id", "ExpYears", "Name", "Speclatation", "TeamID" },
                values: new object[,]
                {
                    { 1, 2, "omar", "puching", 1 },
                    { 2, 32, "omarAhmed", "helping", 2 },
                    { 3, 22, "omarAhmedSamy", "Feeling", 3 },
                    { 4, 67, "omarAghmedSamyMohamed", "hitting", 4 }
                });

            migrationBuilder.InsertData(
                table: "player",
                columns: new[] { "Id", "Age", "FullName", "Postion", "TeamId" },
                values: new object[,]
                {
                    { 1, 42, "ahmed", "mid", 1 },
                    { 2, 60, "Salah", "Attaker", 1 },
                    { 3, 22, "ziad", "Defender", 1 },
                    { 4, 33, "Mohamed", "Defender", 1 }
                });

            migrationBuilder.InsertData(
                table: "teamCompttions",
                columns: new[] { "CompttionId", "TeamId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_coaches_TeamID",
                table: "coaches",
                column: "TeamID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_player_TeamId",
                table: "player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_team_Name",
                table: "team",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teamCompttions_TeamId",
                table: "teamCompttions",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coaches");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "teamCompttions");

            migrationBuilder.DropTable(
                name: "compttion");

            migrationBuilder.DropTable(
                name: "team");
        }
    }
}
