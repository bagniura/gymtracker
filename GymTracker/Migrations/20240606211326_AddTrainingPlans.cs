using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    public partial class AddTrainingPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "ExerciseType",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Training",
                newName: "ExerciseId");

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Training_ExerciseId",
                table: "Training",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Exercise_ExerciseId",
                table: "Training",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_Exercise_ExerciseId",
                table: "Training");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Training_ExerciseId",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Training",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Training",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseType",
                table: "Training",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.Id);
                });
        }
    }
}
