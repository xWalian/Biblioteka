﻿// <auto-generated />
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteka.Migrations
{
    [DbContext(typeof(BibliotekaDbContext))]
    partial class BibliotekaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteka.Models.Ksiazka", b =>
                {
                    b.Property<int>("id_ksiazka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_ksiazka"));

                    b.Property<string>("autor")
                        .IsRequired()
                        .HasColumnType("Varchar(60)");

                    b.Property<int>("id_kategoria")
                        .HasColumnType("int");

                    b.Property<int>("ilosc")
                        .HasColumnType("int");

                    b.Property<int>("rok_wydania")
                        .HasColumnType("int");

                    b.Property<string>("tytul")
                        .IsRequired()
                        .HasColumnType("Varchar(60)");

                    b.Property<string>("wydawnictwo")
                        .IsRequired()
                        .HasColumnType("Varchar(60)");

                    b.HasKey("id_ksiazka");

                    b.ToTable("Ksiazki");
                });
#pragma warning restore 612, 618
        }
    }
}