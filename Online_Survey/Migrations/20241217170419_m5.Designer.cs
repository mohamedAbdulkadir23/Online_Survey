﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_Survey.Data;

#nullable disable

namespace Online_Survey.Migrations
{
    [DbContext(typeof(OnlineDbCon))]
    [Migration("20241217170419_m5")]
    partial class m5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online_Survey.Models.Address", b =>
                {
                    b.Property<int>("Add_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Add_no"));

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Village")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Add_no");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Online_Survey.Models.People", b =>
                {
                    b.Property<int>("P_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("P_no"));

                    b.Property<int>("Add_no")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Reg_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tell")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("P_no");

                    b.HasIndex("Add_no");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Online_Survey.Models.Survey", b =>
                {
                    b.Property<int>("Survey_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Survey_id"));

                    b.Property<int?>("CreatedByUser_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Created_by")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Survey_id");

                    b.HasIndex("CreatedByUser_id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Online_Survey.Models.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"));

                    b.Property<int>("P_no")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Reg_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.HasIndex("P_no");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Online_Survey.Models.People", b =>
                {
                    b.HasOne("Online_Survey.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Add_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Online_Survey.Models.Survey", b =>
                {
                    b.HasOne("Online_Survey.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUser_id");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Online_Survey.Models.User", b =>
                {
                    b.HasOne("Online_Survey.Models.People", "People")
                        .WithMany()
                        .HasForeignKey("P_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}