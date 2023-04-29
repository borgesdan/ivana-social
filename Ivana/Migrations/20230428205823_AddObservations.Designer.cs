﻿// <auto-generated />
using System;
using Ivana.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ivana.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230428205823_AddObservations")]
    partial class AddObservations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Ivana.Data.Entities.DemandEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdmissionStyle")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnotherAssistanceDescription")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("BolsaFamiliaValue")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("DemandsDescription")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("DisabledPersonDescription")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("DisabledPersonType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyDependent")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasAnotherAssistanceType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBPC")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBolsaFamilia")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCrasAssistance")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSCFV")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedicalAssistance")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MedicineAmount")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Observations")
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherAdmissionDescription")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherAssistenceProgram")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientAddressDistrict")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientAddressNumber")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientAddressReference")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientAddressStreet")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PatientBirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientBirthLocal")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientCPF")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientCivilState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PatientEducation")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientGender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PatientName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientNameNormalized")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientPhone")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientRG")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientRelationship")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PatientSocialName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientSocialNameNormalized")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RentAmount")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<int>("ResidenceMonths")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResidenceStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResidenceType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResidenceYears")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomsNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SCFVDescription")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceLocal")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceNumber")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UBSName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Demands");
                });

            modelBuilder.Entity("Ivana.Data.Entities.EconomicSituationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DemandEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Income")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("IncomeAmount")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Observations")
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DemandEntityId");

                    b.ToTable("EconomicSituations");
                });

            modelBuilder.Entity("Ivana.Data.Entities.FamilyCompositionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DemandEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Education")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Observations")
                        .HasColumnType("TEXT");

                    b.Property<int>("Relationship")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DemandEntityId");

                    b.ToTable("FamilyCompositions");
                });

            modelBuilder.Entity("Ivana.Data.Entities.EconomicSituationEntity", b =>
                {
                    b.HasOne("Ivana.Data.Entities.DemandEntity", null)
                        .WithMany("EconomicSituations")
                        .HasForeignKey("DemandEntityId");
                });

            modelBuilder.Entity("Ivana.Data.Entities.FamilyCompositionEntity", b =>
                {
                    b.HasOne("Ivana.Data.Entities.DemandEntity", null)
                        .WithMany("FamilyCompositions")
                        .HasForeignKey("DemandEntityId");
                });

            modelBuilder.Entity("Ivana.Data.Entities.DemandEntity", b =>
                {
                    b.Navigation("EconomicSituations");

                    b.Navigation("FamilyCompositions");
                });
#pragma warning restore 612, 618
        }
    }
}
