using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Survey.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_Question_id1",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_Question_id1",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Question_id1",
                table: "Answers");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Question_id",
                table: "Answers",
                column: "Question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Question_id",
                table: "Answers",
                column: "Question_id",
                principalTable: "Questions",
                principalColumn: "Question_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_Question_id",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_Question_id",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "Question_id1",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Question_id1",
                table: "Answers",
                column: "Question_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Question_id1",
                table: "Answers",
                column: "Question_id1",
                principalTable: "Questions",
                principalColumn: "Question_id");
        }
    }
}
