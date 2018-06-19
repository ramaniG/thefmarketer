using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fmarketer.Models.Migrations
{
    public partial class AddChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultantcoverages_Users__ConsultantId",
                table: "Consultantcoverages");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantServices_Users__ConsultantId",
                table: "ConsultantServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users__ConsultantId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Contact2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactOpt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactOpt2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AuthType = table.Column<int>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    ShowEmail = table.Column<bool>(nullable: false),
                    ShowContact = table.Column<bool>(nullable: false),
                    Verified = table.Column<bool>(nullable: false),
                    Email2 = table.Column<string>(nullable: true),
                    Contact2 = table.Column<string>(nullable: true),
                    ContactOpt = table.Column<int>(nullable: false),
                    ContactOpt2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Attachment = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    _RequestId = table.Column<Guid>(nullable: true),
                    _UserId = table.Column<Guid>(nullable: true),
                    _ConsultantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Consultants__ConsultantId",
                        column: x => x._ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Requests__RequestId",
                        column: x => x._RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Users__UserId",
                        column: x => x._UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chats__ConsultantId",
                table: "Chats",
                column: "_ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats__RequestId",
                table: "Chats",
                column: "_RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats__UserId",
                table: "Chats",
                column: "_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_Email",
                table: "Consultants",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultantcoverages_Consultants__ConsultantId",
                table: "Consultantcoverages",
                column: "_ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantServices_Consultants__ConsultantId",
                table: "ConsultantServices",
                column: "_ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Consultants__ConsultantId",
                table: "Requests",
                column: "_ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultantcoverages_Consultants__ConsultantId",
                table: "Consultantcoverages");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantServices_Consultants__ConsultantId",
                table: "ConsultantServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Consultants__ConsultantId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact2",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactOpt",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactOpt2",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultantcoverages_Users__ConsultantId",
                table: "Consultantcoverages",
                column: "_ConsultantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantServices_Users__ConsultantId",
                table: "ConsultantServices",
                column: "_ConsultantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users__ConsultantId",
                table: "Requests",
                column: "_ConsultantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
