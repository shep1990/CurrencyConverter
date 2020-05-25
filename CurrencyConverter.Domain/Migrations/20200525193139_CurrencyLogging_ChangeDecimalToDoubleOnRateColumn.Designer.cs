﻿// <auto-generated />
using System;
using CurrencyConverter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyConverter.Domain.Migrations
{
    [DbContext(typeof(CurrencyConverterDbContext))]
    [Migration("20200525193139_CurrencyLogging_ChangeDecimalToDoubleOnRateColumn")]
    partial class CurrencyLogging_ChangeDecimalToDoubleOnRateColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CurrencyConverter.Domain.Data.CurrencyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrencyName");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Currency");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a980cb3-82cf-4b88-88e3-58c486c6d939"),
                            CurrencyName = "GBP"
                        },
                        new
                        {
                            Id = new Guid("3132922e-224f-40df-98d8-cb62cd282e96"),
                            CurrencyName = "USD"
                        },
                        new
                        {
                            Id = new Guid("f9eb8cd0-3c14-4480-aa93-0056f51c4ee4"),
                            CurrencyName = "AUD"
                        },
                        new
                        {
                            Id = new Guid("2d115204-059a-4018-ae21-d9c53bdad589"),
                            CurrencyName = "EUR"
                        });
                });

            modelBuilder.Entity("CurrencyConverter.Domain.Data.CurrencyLoggingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("DateLogged");

                    b.Property<double>("Rate");

                    b.Property<Guid>("SourceCurrencyId");

                    b.Property<Guid>("TargetCurrencyId");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TargetCurrencyId");

                    b.ToTable("CurrencyLogging");
                });

            modelBuilder.Entity("CurrencyConverter.Domain.Data.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("CurrencyConverter.Domain.Data.CurrencyLoggingEntity", b =>
                {
                    b.HasOne("CurrencyConverter.Domain.Data.CurrencyEntity", "Currency")
                        .WithMany()
                        .HasForeignKey("TargetCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
