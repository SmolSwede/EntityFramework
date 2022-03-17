﻿// <auto-generated />
using System;
using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220317171653_Initial Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFramework.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            CityName = "Tibro",
                            CountryID = 1
                        },
                        new
                        {
                            CityID = 2,
                            CityName = "Oslo",
                            CountryID = 2
                        });
                });

            modelBuilder.Entity("EntityFramework.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryID = 1,
                            CountryName = "Sweden"
                        },
                        new
                        {
                            CountryID = 2,
                            CountryName = "Norway"
                        });
                });

            modelBuilder.Entity("EntityFramework.Models.Language", b =>
                {
                    b.Property<int>("LangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LangName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LangID");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LangID = 1,
                            LangName = "Swedish"
                        },
                        new
                        {
                            LangID = 2,
                            LangName = "Norwegian"
                        });
                });

            modelBuilder.Entity("EntityFramework.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.HasIndex("CityID");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonID = 1,
                            CityID = 1,
                            FirstName = "Simon",
                            LastName = "Simonsson"
                        },
                        new
                        {
                            PersonID = 2,
                            CityID = 2,
                            FirstName = "Gustav",
                            LastName = "Gustavsson"
                        });
                });

            modelBuilder.Entity("EntityFramework.Models.PersonLanguage", b =>
                {
                    b.Property<int>("LangID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("PersonLanguageID")
                        .HasColumnType("int");

                    b.HasKey("LangID", "PersonID");

                    b.HasIndex("PersonID");

                    b.ToTable("PersonLanguages");

                    b.HasData(
                        new
                        {
                            LangID = 1,
                            PersonID = 1,
                            PersonLanguageID = 0
                        },
                        new
                        {
                            LangID = 1,
                            PersonID = 2,
                            PersonLanguageID = 0
                        },
                        new
                        {
                            LangID = 2,
                            PersonID = 2,
                            PersonLanguageID = 0
                        });
                });

            modelBuilder.Entity("EntityFramework.Models.City", b =>
                {
                    b.HasOne("EntityFramework.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework.Models.Person", b =>
                {
                    b.HasOne("EntityFramework.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityID");
                });

            modelBuilder.Entity("EntityFramework.Models.PersonLanguage", b =>
                {
                    b.HasOne("EntityFramework.Models.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Models.Person", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}