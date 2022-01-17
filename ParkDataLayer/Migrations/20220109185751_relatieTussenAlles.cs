using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkDataLayer.Migrations
{
    public partial class relatieTussenAlles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huizen_Huizen__HuisId",
                table: "Huizen");

            migrationBuilder.DropIndex(
                name: "IX_Huizen__HuisId",
                table: "Huizen");

            migrationBuilder.DropColumn(
                name: "_HuisId",
                table: "Huizen");

            migrationBuilder.AddColumn<int>(
                name: "HuisId",
                table: "Huurcontracten",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HuurderId",
                table: "Huurcontracten",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huurcontracten_HuisId",
                table: "Huurcontracten",
                column: "HuisId");

            migrationBuilder.CreateIndex(
                name: "IX_Huurcontracten_HuurderId",
                table: "Huurcontracten",
                column: "HuurderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Huurcontracten_Huizen_HuisId",
                table: "Huurcontracten",
                column: "HuisId",
                principalTable: "Huizen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Huurcontracten_Huurders_HuurderId",
                table: "Huurcontracten",
                column: "HuurderId",
                principalTable: "Huurders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huurcontracten_Huizen_HuisId",
                table: "Huurcontracten");

            migrationBuilder.DropForeignKey(
                name: "FK_Huurcontracten_Huurders_HuurderId",
                table: "Huurcontracten");

            migrationBuilder.DropIndex(
                name: "IX_Huurcontracten_HuisId",
                table: "Huurcontracten");

            migrationBuilder.DropIndex(
                name: "IX_Huurcontracten_HuurderId",
                table: "Huurcontracten");

            migrationBuilder.DropColumn(
                name: "HuisId",
                table: "Huurcontracten");

            migrationBuilder.DropColumn(
                name: "HuurderId",
                table: "Huurcontracten");

            migrationBuilder.AddColumn<int>(
                name: "_HuisId",
                table: "Huizen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huizen__HuisId",
                table: "Huizen",
                column: "_HuisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Huizen_Huizen__HuisId",
                table: "Huizen",
                column: "_HuisId",
                principalTable: "Huizen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
