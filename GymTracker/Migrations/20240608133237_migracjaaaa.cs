using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    public partial class migracjaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Userrs_UserId1",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_UserId1",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TrainingPlans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "TrainingPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_UserId1",
                table: "TrainingPlans",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Userrs_UserId1",
                table: "TrainingPlans",
                column: "UserId1",
                principalTable: "Userrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
