using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabWorks_Subjects_SubjectId",
                table: "LabWorks");

            migrationBuilder.AddForeignKey(
                name: "FK_LabWorks_Subjects_SubjectId",
                table: "LabWorks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabWorks_Subjects_SubjectId",
                table: "LabWorks");

            migrationBuilder.AddForeignKey(
                name: "FK_LabWorks_Subjects_SubjectId",
                table: "LabWorks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
