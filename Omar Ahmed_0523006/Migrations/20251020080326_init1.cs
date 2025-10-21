using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Omar_Ahmed_0523006.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coaches_team_TeamID",
                table: "coaches");

            migrationBuilder.DropIndex(
                name: "IX_coaches_TeamID",
                table: "coaches");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "coaches");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "team",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoachId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "team",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoachId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "team",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoachId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "team",
                keyColumn: "Id",
                keyValue: 4,
                column: "CoachId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_team_CoachId",
                table: "team",
                column: "CoachId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_team_coaches_CoachId",
                table: "team",
                column: "CoachId",
                principalTable: "coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_team_coaches_CoachId",
                table: "team");

            migrationBuilder.DropIndex(
                name: "IX_team_CoachId",
                table: "team");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "team");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: 1,
                column: "TeamID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "TeamID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "TeamID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: 4,
                column: "TeamID",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_coaches_TeamID",
                table: "coaches",
                column: "TeamID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_coaches_team_TeamID",
                table: "coaches",
                column: "TeamID",
                principalTable: "team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
