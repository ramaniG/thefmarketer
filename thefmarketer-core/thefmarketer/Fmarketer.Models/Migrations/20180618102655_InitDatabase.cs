using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fmarketer.Models.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Star = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    ShowContact = table.Column<bool>(nullable: false),
                    ShowEmail = table.Column<bool>(nullable: false),
                    Verified = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Email2 = table.Column<string>(nullable: true),
                    Contact2 = table.Column<string>(nullable: true),
                    ContactOpt = table.Column<int>(nullable: true),
                    ContactOpt2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultantcoverages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    _ConsultantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultantcoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultantcoverages_Users__ConsultantId",
                        column: x => x._ConsultantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    LicenseActive = table.Column<bool>(nullable: false),
                    RegistrationNo = table.Column<string>(nullable: true),
                    ActiveSince = table.Column<DateTime>(nullable: false),
                    YearsOfExp = table.Column<int>(nullable: false),
                    ClientScale = table.Column<int>(nullable: false),
                    Proof = table.Column<string>(nullable: true),
                    _ConsultantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultantServices_Users__ConsultantId",
                        column: x => x._ConsultantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Service = table.Column<int>(nullable: false),
                    _ReviewId = table.Column<Guid>(nullable: true),
                    _ConsultantId = table.Column<Guid>(nullable: true),
                    _UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Users__ConsultantId",
                        column: x => x._ConsultantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Reviews__ReviewId",
                        column: x => x._ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Users__UserId",
                        column: x => x._UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultantcoverages__ConsultantId",
                table: "Consultantcoverages",
                column: "_ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantServices__ConsultantId",
                table: "ConsultantServices",
                column: "_ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests__ConsultantId",
                table: "Requests",
                column: "_ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests__ReviewId",
                table: "Requests",
                column: "_ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests__UserId",
                table: "Requests",
                column: "_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultantcoverages");

            migrationBuilder.DropTable(
                name: "ConsultantServices");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
