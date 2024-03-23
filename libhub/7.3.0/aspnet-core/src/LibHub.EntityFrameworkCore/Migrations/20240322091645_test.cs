using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibHub.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_StoredFiles_ImageId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredFiles",
                table: "StoredFiles");

            migrationBuilder.RenameTable(
                name: "StoredFiles",
                newName: "StoredFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredFile",
                table: "StoredFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_StoredFile_ImageId",
                table: "Books",
                column: "ImageId",
                principalTable: "StoredFile",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_StoredFile_ImageId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredFile",
                table: "StoredFile");

            migrationBuilder.RenameTable(
                name: "StoredFile",
                newName: "StoredFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredFiles",
                table: "StoredFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_StoredFiles_ImageId",
                table: "Books",
                column: "ImageId",
                principalTable: "StoredFiles",
                principalColumn: "Id");
        }
    }
}
