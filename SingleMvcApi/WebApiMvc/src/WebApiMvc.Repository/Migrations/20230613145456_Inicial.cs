using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiMvc.Repository.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "varchar(30)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", nullable: false),
                    address = table.Column<string>(type: "varvar(80)", nullable: true),
                    number = table.Column<string>(type: "varvar(20)", nullable: true),
                    neighborhood = table.Column<string>(type: "varvar(80)", nullable: true),
                    city = table.Column<string>(type: "varvar(80)", nullable: true),
                    state = table.Column<string>(type: "varvar(20)", nullable: true),
                    zip_code = table.Column<string>(type: "varvar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.id);
                    table.ForeignKey(
                        name: "fk_Contact_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "varchar(80)", nullable: true),
                    cell_phone = table.Column<string>(type: "varchar(80)", nullable: false),
                    phone_number = table.Column<string>(type: "varchar(80)", nullable: true),
                    linkedin = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetail", x => x.id);
                    table.ForeignKey(
                        name: "fk_Contact_ContactsDetails",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CategoryId",
                table: "Contact",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetail_ContactId",
                table: "ContactDetail",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDetail");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
