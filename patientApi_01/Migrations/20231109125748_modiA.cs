using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patientApi_01.Migrations
{
    public partial class modiA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diseases_DiseaseID",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "DiseaseID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NCDID1",
                table: "NCDDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AllergyID1",
                table: "AllergiesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_NCDID1",
                table: "NCDDetails",
                column: "NCDID1");

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_AllergyID1",
                table: "AllergiesDetails",
                column: "AllergyID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AllergiesDetails_Allergies_AllergyID1",
                table: "AllergiesDetails",
                column: "AllergyID1",
                principalTable: "Allergies",
                principalColumn: "AllergyID");

            migrationBuilder.AddForeignKey(
                name: "FK_NCDDetails_NCDs_NCDID1",
                table: "NCDDetails",
                column: "NCDID1",
                principalTable: "NCDs",
                principalColumn: "NCDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diseases_DiseaseID",
                table: "Patients",
                column: "DiseaseID",
                principalTable: "Diseases",
                principalColumn: "DiseaseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergiesDetails_Allergies_AllergyID1",
                table: "AllergiesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NCDDetails_NCDs_NCDID1",
                table: "NCDDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diseases_DiseaseID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_NCDDetails_NCDID1",
                table: "NCDDetails");

            migrationBuilder.DropIndex(
                name: "IX_AllergiesDetails_AllergyID1",
                table: "AllergiesDetails");

            migrationBuilder.DropColumn(
                name: "NCDID1",
                table: "NCDDetails");

            migrationBuilder.DropColumn(
                name: "AllergyID1",
                table: "AllergiesDetails");

            migrationBuilder.AlterColumn<int>(
                name: "DiseaseID",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diseases_DiseaseID",
                table: "Patients",
                column: "DiseaseID",
                principalTable: "Diseases",
                principalColumn: "DiseaseID");
        }
    }
}
