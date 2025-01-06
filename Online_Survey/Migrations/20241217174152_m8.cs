using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Survey.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Answer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_id = table.Column<int>(type: "int", nullable: false),
                    Question_id1 = table.Column<int>(type: "int", nullable: true),
                    Answer_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Answer_id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_Question_id1",
                        column: x => x.Question_id1,
                        principalTable: "Questions",
                        principalColumn: "Question_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Question_id1",
                table: "Answers",
                column: "Question_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
