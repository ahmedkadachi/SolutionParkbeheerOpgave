using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkDataLayer.Migrations
{
    public partial class relatieTussenParkEnHuis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParkId",
                table: "Huizen",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_HuisId",
                table: "Huizen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huizen__HuisId",
                table: "Huizen",
                column: "_HuisId");

            migrationBuilder.CreateIndex(
                name: "IX_Huizen_ParkId",
                table: "Huizen",
                column: "ParkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Huizen_Huizen__HuisId",
                table: "Huizen",
                column: "_HuisId",
                principalTable: "Huizen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Huizen_Parken_ParkId",
                table: "Huizen",
                column: "ParkId",
                principalTable: "Parken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huizen_Huizen__HuisId",
                table: "Huizen");

            migrationBuilder.DropForeignKey(
                name: "FK_Huizen_Parken_ParkId",
                table: "Huizen");

            migrationBuilder.DropIndex(
                name: "IX_Huizen__HuisId",
                table: "Huizen");

            migrationBuilder.DropIndex(
                name: "IX_Huizen_ParkId",
                table: "Huizen");

            migrationBuilder.DropColumn(
                name: "ParkId",
                table: "Huizen");

            migrationBuilder.DropColumn(
                name: "_HuisId",
                table: "Huizen");
        }
    }
}
