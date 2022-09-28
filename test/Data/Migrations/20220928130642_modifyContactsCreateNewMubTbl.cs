using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Data.Migrations
{
    public partial class modifyContactsCreateNewMubTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneTypes_PhoneTypeId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "PhoneTypeId",
                table: "Contacts",
                newName: "NumbersOfContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_PhoneTypeId",
                table: "Contacts",
                newName: "IX_Contacts_NumbersOfContactId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTypeName",
                table: "PhoneTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "NumbersOfNumbers",
                columns: table => new
                {
                    NumbersOfContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumbersOfContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumbersOfNumbers", x => x.NumbersOfContactId);
                    table.ForeignKey(
                        name: "FK_NumbersOfNumbers_PhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneTypes",
                        principalColumn: "PhoneTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumbersOfNumbers_PhoneTypeId",
                table: "NumbersOfNumbers",
                column: "PhoneTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_NumbersOfNumbers_NumbersOfContactId",
                table: "Contacts",
                column: "NumbersOfContactId",
                principalTable: "NumbersOfNumbers",
                principalColumn: "NumbersOfContactId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_NumbersOfNumbers_NumbersOfContactId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "NumbersOfNumbers");

            migrationBuilder.RenameColumn(
                name: "NumbersOfContactId",
                table: "Contacts",
                newName: "PhoneTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_NumbersOfContactId",
                table: "Contacts",
                newName: "IX_Contacts_PhoneTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTypeName",
                table: "PhoneTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneTypes_PhoneTypeId",
                table: "Contacts",
                column: "PhoneTypeId",
                principalTable: "PhoneTypes",
                principalColumn: "PhoneTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
