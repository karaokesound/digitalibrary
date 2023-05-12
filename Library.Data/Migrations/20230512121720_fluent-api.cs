using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class fluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorModelBookModel_Authors_AuthorsId",
                table: "AuthorModelBookModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorModelBookModel_Books_BooksId",
                table: "AuthorModelBookModel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "AuthorModelBookModel",
                newName: "BooksBookId");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "AuthorModelBookModel",
                newName: "AuthorsAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorModelBookModel_BooksId",
                table: "AuthorModelBookModel",
                newName: "IX_AuthorModelBookModel_BooksBookId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorModelBookModel_Authors_AuthorsAuthorId",
                table: "AuthorModelBookModel",
                column: "AuthorsAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorModelBookModel_Books_BooksBookId",
                table: "AuthorModelBookModel",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorModelBookModel_Authors_AuthorsAuthorId",
                table: "AuthorModelBookModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorModelBookModel_Books_BooksBookId",
                table: "AuthorModelBookModel");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Authors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "AuthorModelBookModel",
                newName: "BooksId");

            migrationBuilder.RenameColumn(
                name: "AuthorsAuthorId",
                table: "AuthorModelBookModel",
                newName: "AuthorsId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorModelBookModel_BooksBookId",
                table: "AuthorModelBookModel",
                newName: "IX_AuthorModelBookModel_BooksId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorModelBookModel_Authors_AuthorsId",
                table: "AuthorModelBookModel",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorModelBookModel_Books_BooksId",
                table: "AuthorModelBookModel",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
