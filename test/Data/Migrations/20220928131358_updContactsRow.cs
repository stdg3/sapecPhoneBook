using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Data.Migrations
{
    public partial class updContactsRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Contacts",
                newName: "ContactLastName");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Contacts",
                newName: "ContactFirstName");

            migrationBuilder.AddColumn<string>(
                name: "ContactAdress",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAdress",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ContactLastName",
                table: "Contacts",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "ContactFirstName",
                table: "Contacts",
                newName: "ContactName");
        }
    }
}
