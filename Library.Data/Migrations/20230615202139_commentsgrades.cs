using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class commentsgrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "BookGrades",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGrades", x => new { x.BookId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_BookGrades_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGrades_GradeId",
                table: "BookGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGrades");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
