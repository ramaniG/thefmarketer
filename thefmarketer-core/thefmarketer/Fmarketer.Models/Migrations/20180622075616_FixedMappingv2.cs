using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fmarketer.Models.Migrations
{
    public partial class FixedMappingv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Admins__AdminId",
                table: "Credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Consultants__ConsultandId",
                table: "Credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Users__UserId",
                table: "Credentials");

            migrationBuilder.DropIndex(
                name: "IX_Credentials__AdminId",
                table: "Credentials");

            migrationBuilder.DropIndex(
                name: "IX_Credentials__ConsultandId",
                table: "Credentials");

            migrationBuilder.DropIndex(
                name: "IX_Credentials__UserId",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "_AdminId",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "_ConsultandId",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "_UserId",
                table: "Credentials");

            migrationBuilder.AddColumn<Guid>(
                name: "_CredentialId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "_CredentialId",
                table: "Consultants",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "_CredentialId",
                table: "Admins",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users__CredentialId",
                table: "Users",
                column: "_CredentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants__CredentialId",
                table: "Consultants",
                column: "_CredentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins__CredentialId",
                table: "Admins",
                column: "_CredentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Credentials__CredentialId",
                table: "Admins",
                column: "_CredentialId",
                principalTable: "Credentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Credentials__CredentialId",
                table: "Consultants",
                column: "_CredentialId",
                principalTable: "Credentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Credentials__CredentialId",
                table: "Users",
                column: "_CredentialId",
                principalTable: "Credentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Credentials__CredentialId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Credentials__CredentialId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Credentials__CredentialId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users__CredentialId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Consultants__CredentialId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Admins__CredentialId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "_CredentialId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "_CredentialId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "_CredentialId",
                table: "Admins");

            migrationBuilder.AddColumn<Guid>(
                name: "_AdminId",
                table: "Credentials",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "_ConsultandId",
                table: "Credentials",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "_UserId",
                table: "Credentials",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Admins__AdminId",
                table: "Credentials",
                column: "_AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Consultants__ConsultandId",
                table: "Credentials",
                column: "_ConsultandId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Users__UserId",
                table: "Credentials",
                column: "_UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
