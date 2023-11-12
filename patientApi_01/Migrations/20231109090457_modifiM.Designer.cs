﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using patientApi_01.Models;

#nullable disable

namespace patientApi_01.Migrations
{
    [DbContext(typeof(PatientDbContext))]
    [Migration("20231109090457_modifiM")]
    partial class modifiM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("patientApi_01.Models.Allergies_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AllergyID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AllergyID");

                    b.HasIndex("PatientID");

                    b.ToTable("AllergiesDetails");
                });

            modelBuilder.Entity("patientApi_01.Models.Allergy", b =>
                {
                    b.Property<int>("AllergyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergyID"), 1L, 1);

                    b.Property<string>("AllergyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergyID");

                    b.ToTable("Allergies");

                    b.HasData(
                        new
                        {
                            AllergyID = 1,
                            AllergyName = "Drugs-Penicillin"
                        },
                        new
                        {
                            AllergyID = 2,
                            AllergyName = "Drugs-Others"
                        },
                        new
                        {
                            AllergyID = 3,
                            AllergyName = "Animals"
                        },
                        new
                        {
                            AllergyID = 4,
                            AllergyName = "Food"
                        },
                        new
                        {
                            AllergyID = 5,
                            AllergyName = "Ointments"
                        },
                        new
                        {
                            AllergyID = 6,
                            AllergyName = "Plants"
                        },
                        new
                        {
                            AllergyID = 7,
                            AllergyName = "Sprays"
                        },
                        new
                        {
                            AllergyID = 8,
                            AllergyName = "Others"
                        },
                        new
                        {
                            AllergyID = 9,
                            AllergyName = "No Allergies"
                        });
                });

            modelBuilder.Entity("patientApi_01.Models.Disease", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"), 1L, 1);

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.ToTable("Diseases");

                    b.HasData(
                        new
                        {
                            DiseaseID = 1,
                            DiseaseName = "Diabetes"
                        },
                        new
                        {
                            DiseaseID = 2,
                            DiseaseName = "Hypertension"
                        },
                        new
                        {
                            DiseaseID = 3,
                            DiseaseName = "Arthritis"
                        },
                        new
                        {
                            DiseaseID = 4,
                            DiseaseName = "Heart Disease"
                        },
                        new
                        {
                            DiseaseID = 5,
                            DiseaseName = "Respiratory Infections"
                        });
                });

            modelBuilder.Entity("patientApi_01.Models.NCD", b =>
                {
                    b.Property<int>("NCDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDID"), 1L, 1);

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NCDID");

                    b.ToTable("NCDs");

                    b.HasData(
                        new
                        {
                            NCDID = 1,
                            NCDName = "Asthma"
                        },
                        new
                        {
                            NCDID = 2,
                            NCDName = "Cancer"
                        },
                        new
                        {
                            NCDID = 3,
                            NCDName = "Disorders of ear"
                        },
                        new
                        {
                            NCDID = 4,
                            NCDName = "Disorders of eye"
                        },
                        new
                        {
                            NCDID = 5,
                            NCDName = "Mental illness"
                        },
                        new
                        {
                            NCDID = 6,
                            NCDName = "Oral health Problems"
                        });
                });

            modelBuilder.Entity("patientApi_01.Models.NCD_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("NCDID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NCDID");

                    b.HasIndex("PatientID");

                    b.ToTable("NCDDetails");
                });

            modelBuilder.Entity("patientApi_01.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"), 1L, 1);

                    b.Property<int?>("DiseaseID")
                        .HasColumnType("int");

                    b.Property<int>("Epilepsy")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.HasIndex("DiseaseID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("patientApi_01.Models.Allergies_Details", b =>
                {
                    b.HasOne("patientApi_01.Models.Allergy", "Allergy")
                        .WithMany()
                        .HasForeignKey("AllergyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("patientApi_01.Models.Patient", "Patient")
                        .WithMany("AllergiesDetails")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergy");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("patientApi_01.Models.NCD_Details", b =>
                {
                    b.HasOne("patientApi_01.Models.NCD", "NCD")
                        .WithMany()
                        .HasForeignKey("NCDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("patientApi_01.Models.Patient", "Patient")
                        .WithMany("NCDDetails")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NCD");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("patientApi_01.Models.Patient", b =>
                {
                    b.HasOne("patientApi_01.Models.Disease", "Disease")
                        .WithMany()
                        .HasForeignKey("DiseaseID");

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("patientApi_01.Models.Patient", b =>
                {
                    b.Navigation("AllergiesDetails");

                    b.Navigation("NCDDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
