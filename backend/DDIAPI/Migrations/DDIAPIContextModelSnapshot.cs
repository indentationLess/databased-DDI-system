﻿// <auto-generated />
using System;
using DDIAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDIAPI.Migrations
{
    [DbContext(typeof(DDIAPIContext))]
    partial class DDIAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DDIAPI.Models.ClinicalRecommendation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Reccomendation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("clinicalRecommendations");
                });

            modelBuilder.Entity("DDIAPI.Models.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DosageForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrugCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DrugName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenericDrugName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Interactionid")
                        .HasColumnType("int");

                    b.Property<string>("Strength")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrugCategoryId");

                    b.HasIndex("Interactionid");

                    b.ToTable("drugs");
                });

            modelBuilder.Entity("DDIAPI.Models.DrugCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("drugCategories");
                });

            modelBuilder.Entity("DDIAPI.Models.HealthCareProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("healthCareProviders");
                });

            modelBuilder.Entity("DDIAPI.Models.Interaction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clinicalRecommendationId")
                        .HasColumnType("int");

                    b.Property<int>("drug1ID")
                        .HasColumnType("int");

                    b.Property<int>("drug2ID")
                        .HasColumnType("int");

                    b.Property<int>("severityId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clinicalRecommendationId");

                    b.HasIndex("severityId");

                    b.ToTable("interactions");
                });

            modelBuilder.Entity("DDIAPI.Models.MedicationLogs", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dosage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("drugID")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("drugID");

                    b.ToTable("medicationLogs");
                });

            modelBuilder.Entity("DDIAPI.Models.Severity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("LevelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("severities");
                });

            modelBuilder.Entity("DDIAPI.Models.SystemAlert", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("interactionID")
                        .HasColumnType("int");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("interactionID");

                    b.ToTable("systemAlerts");
                });

            modelBuilder.Entity("DDIAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DDIAPI.Models.Drug", b =>
                {
                    b.HasOne("DDIAPI.Models.DrugCategory", "drugCategory")
                        .WithMany("drugs")
                        .HasForeignKey("DrugCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDIAPI.Models.Interaction", null)
                        .WithMany("drugs")
                        .HasForeignKey("Interactionid");

                    b.Navigation("drugCategory");
                });

            modelBuilder.Entity("DDIAPI.Models.HealthCareProvider", b =>
                {
                    b.HasOne("DDIAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DDIAPI.Models.Interaction", b =>
                {
                    b.HasOne("DDIAPI.Models.ClinicalRecommendation", "clinicalRecommendation")
                        .WithMany()
                        .HasForeignKey("clinicalRecommendationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDIAPI.Models.Severity", "severity")
                        .WithMany()
                        .HasForeignKey("severityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clinicalRecommendation");

                    b.Navigation("severity");
                });

            modelBuilder.Entity("DDIAPI.Models.MedicationLogs", b =>
                {
                    b.HasOne("DDIAPI.Models.Drug", "drug")
                        .WithMany()
                        .HasForeignKey("drugID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("drug");
                });

            modelBuilder.Entity("DDIAPI.Models.SystemAlert", b =>
                {
                    b.HasOne("DDIAPI.Models.Interaction", "interaction")
                        .WithMany()
                        .HasForeignKey("interactionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("interaction");
                });

            modelBuilder.Entity("DDIAPI.Models.DrugCategory", b =>
                {
                    b.Navigation("drugs");
                });

            modelBuilder.Entity("DDIAPI.Models.Interaction", b =>
                {
                    b.Navigation("drugs");
                });
#pragma warning restore 612, 618
        }
    }
}
