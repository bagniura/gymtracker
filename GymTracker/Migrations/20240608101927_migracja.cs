using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    public partial class migracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_Exercise_ExerciseId",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_Userr_AspNetUsers_UserId",
                table: "Userr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userr",
                table: "Userr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Userr",
                newName: "Userrs");

            migrationBuilder.RenameTable(
                name: "Training",
                newName: "ExercisePlans");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Userr_UserId",
                table: "Userrs",
                newName: "IX_Userrs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Training_ExerciseId",
                table: "ExercisePlans",
                newName: "IX_ExercisePlans_ExerciseId");

            migrationBuilder.AddColumn<int>(
                name: "TrainingPlanId",
                table: "ExercisePlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userrs",
                table: "Userrs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercisePlans",
                table: "ExercisePlans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_Userrs_UserId",
                        column: x => x.UserId,
                        principalTable: "Userrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePlans_TrainingPlanId",
                table: "ExercisePlans",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_UserId",
                table: "TrainingPlans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePlans_Exercises_ExerciseId",
                table: "ExercisePlans",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePlans_TrainingPlans_TrainingPlanId",
                table: "ExercisePlans",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Userrs_AspNetUsers_UserId",
                table: "Userrs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePlans_Exercises_ExerciseId",
                table: "ExercisePlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePlans_TrainingPlans_TrainingPlanId",
                table: "ExercisePlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Userrs_AspNetUsers_UserId",
                table: "Userrs");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userrs",
                table: "Userrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercisePlans",
                table: "ExercisePlans");

            migrationBuilder.DropIndex(
                name: "IX_ExercisePlans_TrainingPlanId",
                table: "ExercisePlans");

            migrationBuilder.DropColumn(
                name: "TrainingPlanId",
                table: "ExercisePlans");

            migrationBuilder.RenameTable(
                name: "Userrs",
                newName: "Userr");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameTable(
                name: "ExercisePlans",
                newName: "Training");

            migrationBuilder.RenameIndex(
                name: "IX_Userrs_UserId",
                table: "Userr",
                newName: "IX_Userr_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExercisePlans_ExerciseId",
                table: "Training",
                newName: "IX_Training_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userr",
                table: "Userr",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training",
                table: "Training",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Exercise_ExerciseId",
                table: "Training",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Userr_AspNetUsers_UserId",
                table: "Userr",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
