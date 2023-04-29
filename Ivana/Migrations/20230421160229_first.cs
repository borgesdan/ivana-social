using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ivana.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceLocal = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ServiceNumber = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PatientName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    PatientNameNormalized = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    PatientGender = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientSocialName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    PatientSocialNameNormalized = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    PatientPhone = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    PatientBirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PatientBirthLocal = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    PatientCPF = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    PatientRG = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    PatientEducation = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    PatientAddressStreet = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    PatientAddressNumber = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true),
                    PatientAddressDistrict = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    PatientAddressReference = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    PatientCivilState = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientRelationship = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidenceType = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomsNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidenceStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    RentAmount = table.Column<decimal>(type: "TEXT", maxLength: 8, nullable: false),
                    ResidenceYears = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidenceMonths = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicalAssistance = table.Column<int>(type: "INTEGER", nullable: false),
                    UBSName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    MedicineAmount = table.Column<decimal>(type: "TEXT", maxLength: 8, nullable: false),
                    FamilyDependent = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DisabledPersonType = table.Column<int>(type: "INTEGER", nullable: false),
                    DisabledPersonDescription = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    IsBolsaFamilia = table.Column<bool>(type: "INTEGER", nullable: false),
                    BolsaFamiliaValue = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true),
                    IsBPC = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAnotherAssistanceType = table.Column<bool>(type: "INTEGER", nullable: false),
                    AnotherAssistanceDescription = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    IsCrasAssistance = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSCFV = table.Column<bool>(type: "INTEGER", nullable: false),
                    SCFVDescription = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    OtherAssistenceProgram = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    AdmissionStyle = table.Column<int>(type: "INTEGER", nullable: false),
                    OtherAdmissionDescription = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    DemandsDescription = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Observations = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EconomicSituations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Income = table.Column<int>(type: "INTEGER", nullable: false),
                    IncomeAmount = table.Column<decimal>(type: "TEXT", maxLength: 200, nullable: false),
                    Observations = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    DemandEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicSituations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EconomicSituations_Demands_DemandEntityId",
                        column: x => x.DemandEntityId,
                        principalTable: "Demands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FamilyCompositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Relationship = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Education = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    DemandEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyCompositions_Demands_DemandEntityId",
                        column: x => x.DemandEntityId,
                        principalTable: "Demands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EconomicSituations_DemandEntityId",
                table: "EconomicSituations",
                column: "DemandEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyCompositions_DemandEntityId",
                table: "FamilyCompositions",
                column: "DemandEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EconomicSituations");

            migrationBuilder.DropTable(
                name: "FamilyCompositions");

            migrationBuilder.DropTable(
                name: "Demands");
        }
    }
}
