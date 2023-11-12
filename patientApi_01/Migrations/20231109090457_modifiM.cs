using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patientApi_01.Migrations
{
    public partial class modifiM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NCDDetails_Diseases_DiseaseID",
                table: "NCDDetails");

            migrationBuilder.DropIndex(
                name: "IX_NCDDetails_DiseaseID",
                table: "NCDDetails");

            migrationBuilder.DropColumn(
                name: "DiseaseID",
                table: "NCDDetails");

            migrationBuilder.AddColumn<int>(
                name: "DiseaseID",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "DiseaseID", "DiseaseName" },
                values: new object[,]
                {
                    { 1, "Diabetes" },
                    { 2, "Hypertension" },
                    { 3, "Arthritis" },
                    { 4, "Heart Disease" },
                    { 5, "Respiratory Infections" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseID",
                table: "Patients",
                column: "DiseaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diseases_DiseaseID",
                table: "Patients",
                column: "DiseaseID",
                principalTable: "Diseases",
                principalColumn: "DiseaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diseases_DiseaseID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiseaseID",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "DiseaseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "DiseaseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "DiseaseID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "DiseaseID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "DiseaseID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "DiseaseID",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "DiseaseID",
                table: "NCDDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_DiseaseID",
                table: "NCDDetails",
                column: "DiseaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_NCDDetails_Diseases_DiseaseID",
                table: "NCDDetails",
                column: "DiseaseID",
                principalTable: "Diseases",
                principalColumn: "DiseaseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
