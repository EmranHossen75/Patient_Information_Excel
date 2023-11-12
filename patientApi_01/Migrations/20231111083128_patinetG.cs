using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patientApi_01.Migrations
{
    public partial class patinetG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "NCDDetails",
                newName: "NCD_DetailsID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AllergiesDetails",
                newName: "Allergies_DetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NCD_DetailsID",
                table: "NCDDetails",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Allergies_DetailsID",
                table: "AllergiesDetails",
                newName: "ID");
        }
    }
}
