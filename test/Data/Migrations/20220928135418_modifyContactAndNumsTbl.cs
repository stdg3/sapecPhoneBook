using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Data.Migrations
{
    public partial class modifyContactAndNumsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_NumbersOfNumbers_NumbersOfContactId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_NumbersOfContactId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "NumbersOfContactId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "NumbersOfNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NumbersOfNumbers_ContactId",
                table: "NumbersOfNumbers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_NumbersOfNumbers_Contacts_ContactId",
                table: "NumbersOfNumbers",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumbersOfNumbers_Contacts_ContactId",
                table: "NumbersOfNumbers");

            migrationBuilder.DropIndex(
                name: "IX_NumbersOfNumbers_ContactId",
                table: "NumbersOfNumbers");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "NumbersOfNumbers");

            migrationBuilder.AddColumn<int>(
                name: "NumbersOfContactId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_NumbersOfContactId",
                table: "Contacts",
                column: "NumbersOfContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_NumbersOfNumbers_NumbersOfContactId",
                table: "Contacts",
                column: "NumbersOfContactId",
                principalTable: "NumbersOfNumbers",
                principalColumn: "NumbersOfContactId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
