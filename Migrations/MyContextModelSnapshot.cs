﻿// <auto-generated />
using System;
using API2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API2.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API2.Models.Acount", b =>
                {
                    b.Property<int>("NIK")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("TB_M_Acoount");
                });

            modelBuilder.Entity("API2.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnivId")
                        .HasColumnType("int");

                    b.Property<int>("University_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnivId");

                    b.ToTable("TB_M_Education");
                });

            modelBuilder.Entity("API2.Models.Person", b =>
                {
                    b.Property<int>("NIK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("TB_M_Person");
                });

            modelBuilder.Entity("API2.Models.Profiling", b =>
                {
                    b.Property<int>("NIK")
                        .HasColumnType("int");

                    b.Property<int?>("EduId")
                        .HasColumnType("int");

                    b.Property<int>("Education_id")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("EduId");

                    b.ToTable("TB_R_Profiling");
                });

            modelBuilder.Entity("API2.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_University");
                });

            modelBuilder.Entity("API2.Models.Acount", b =>
                {
                    b.HasOne("API2.Models.Person", "Personn")
                        .WithOne("Account")
                        .HasForeignKey("API2.Models.Acount", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personn");
                });

            modelBuilder.Entity("API2.Models.Education", b =>
                {
                    b.HasOne("API2.Models.University", "Univ")
                        .WithMany("Edu")
                        .HasForeignKey("UnivId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Univ");
                });

            modelBuilder.Entity("API2.Models.Profiling", b =>
                {
                    b.HasOne("API2.Models.Education", "Edu")
                        .WithMany("Profilingg")
                        .HasForeignKey("EduId");

                    b.HasOne("API2.Models.Acount", "Account")
                        .WithOne("Profilingg")
                        .HasForeignKey("API2.Models.Profiling", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Edu");
                });

            modelBuilder.Entity("API2.Models.Acount", b =>
                {
                    b.Navigation("Profilingg");
                });

            modelBuilder.Entity("API2.Models.Education", b =>
                {
                    b.Navigation("Profilingg");
                });

            modelBuilder.Entity("API2.Models.Person", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("API2.Models.University", b =>
                {
                    b.Navigation("Edu");
                });
#pragma warning restore 612, 618
        }
    }
}
