using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibHub.Migrations
{
    public partial class createbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredFiles",
                table: "StoredFiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_StoredFiles_ImageId",
                table: "Books",
                column: "ImageId",
                principalTable: "StoredFiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_StoredFiles_ImageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredFiles",
                table: "StoredFiles");

            migrationBuilder.RenameTable(
                name: "StoredFiles",
                newName: "StoredFile");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "CategoryID");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryID",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
    }
}
