using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fmarketer.Models.Migrations
{
    public partial class FixedMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Consultants__ConsultantId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users__UserId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats__ConsultantId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats__UserId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "AuthType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthType",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "_ConsultantId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "_UserId",
                table: "Chats");

            migrationBuilder.AddColumn<int>(
                name: "Service",
                table: "ConsultantServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "Chats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AuthType = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    NumberOfTry = table.Column<int>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    CredentialState = table.Column<int>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    Verified = table.Column<bool>(nullable: false),
                    _ConsultandId = table.Column<Guid>(nullable: false),
                    _UserId = table.Column<Guid>(nullable: false),
                    _AdminId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_Admins__AdminId",
                        column: x => x._AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credentials_Consultants__ConsultandId",
                        column: x => x._ConsultandId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credentials_Users__UserId",
                        column: x => x._UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    AuthenticatedTime = table.Column<DateTime>(nullable: false),
                    ExpiryTime = table.Column<DateTime>(nullable: false),
                    _CredentialId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityTokens_Credentials__CredentialId",
                        column: x => x._CredentialId,
                        principalTable: "Credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_Email",
                table: "Credentials",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials__AdminId",
                table: "Credentials",
                column: "_AdminId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credentials__ConsultandId",
                table: "Credentials",
                column: "_ConsultandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credentials__UserId",
                table: "Credentials",
                column: "_UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTokens__CredentialId",
                table: "SecurityTokens",
                column: "_CredentialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityTokens");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "ConsultantServices");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Chats");

            migrationBuilder.AddColumn<int>(
                name: "AuthType",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AuthType",
                table: "Consultants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Consultants",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Consultants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Consultants",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Consultants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "_ConsultantId",
                table: "Chats",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "_UserId",
                table: "Chats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats__ConsultantId",
                table: "Chats",
                column: "_ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats__UserId",
                table: "Chats",
                column: "_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Consultants__ConsultantId",
                table: "Chats",
                column: "_ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users__UserId",
                table: "Chats",
                column: "_UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
