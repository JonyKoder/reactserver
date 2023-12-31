﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using reactserver.database;

#nullable disable

namespace reactserver.database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230811135811_changeEntity")]
    partial class changeEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("reactserver.Domain.Models.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountHolderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BankAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SWIFTCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("reactserver.Domain.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OGRN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("reactserver.Domain.Models.IndividualEntrepreneur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BankAccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EgripImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OGRNIP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OgrnIpImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScanInnImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("IndividualEntrepreneurs");
                });

            modelBuilder.Entity("reactserver.Domain.Models.IndividualEntrepreneur", b =>
                {
                    b.HasOne("reactserver.Domain.Models.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
