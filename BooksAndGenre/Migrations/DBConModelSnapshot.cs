﻿// <auto-generated />
using System;
using BooksAndGenre.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksAndGenre.Migrations
{
    [DbContext(typeof(DBCon))]
    partial class DBConModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BooksAndGenre.Model.Books", b =>
                {
                    b.Property<int>("ID_Book")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Book"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreID_Genre")
                        .HasColumnType("int");

                    b.Property<int>("ID_Genre")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YearOfIzd")
                        .HasColumnType("datetime2");

                    b.HasKey("ID_Book");

                    b.HasIndex("GenreID_Genre");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BooksAndGenre.Model.Genre", b =>
                {
                    b.Property<int>("ID_Genre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Genre"));

                    b.Property<string>("Name_Genre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Genre");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("BooksAndGenre.Model.Books", b =>
                {
                    b.HasOne("BooksAndGenre.Model.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID_Genre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
