using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibHub.Migrations
{
    public partial class initialmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "SpaceStatus",
                table: "Spaces",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "SpaceName",
                table: "Spaces",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LibrarianId",
                table: "BookRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BookRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StoredFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Folder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ImageId",
                table: "Books",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_LibrarianId",
                table: "BookRequests",
                column: "LibrarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Person_LibrarianId",
                table: "BookRequests",
                column: "LibrarianId",
                principalTable: "Person",
                principalColumn: "Id");

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
                name: "FK_BookRequests_Person_LibrarianId",
                table: "BookRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_StoredFile_ImageId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "StoredFile");

            migrationBuilder.DropIndex(
                name: "IX_Books_ImageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_LibrarianId",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LibrarianId",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookRequests");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Spaces",
                newName: "SpaceStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Spaces",
                newName: "SpaceName");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
