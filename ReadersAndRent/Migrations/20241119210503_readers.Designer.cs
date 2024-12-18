﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadersAndRent.DB;

#nullable disable

namespace ReadersAndRent.Migrations
{
    [DbContext(typeof(DBCon))]
    [Migration("20241119210503_readers")]
    partial class readers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ReadersAndRent.Model.Readers", b =>
                {
                    b.Property<int>("Id_Reader")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Reader"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Reader");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("ReadersAndRent.Model.Rent", b =>
                {
                    b.Property<int>("ID_History")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_History"));

                    b.Property<DateTime?>("Date_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Book")
                        .HasColumnType("int");

                    b.Property<int>("ID_Reader")
                        .HasColumnType("int");

                    b.Property<int>("Srok")
                        .HasColumnType("int");

                    b.HasKey("ID_History");

                    b.HasIndex("ID_Book");

                    b.HasIndex("ID_Reader");

                    b.ToTable("Rent");
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

            modelBuilder.Entity("ReadersAndRent.Model.Rent", b =>
                {
                    b.HasOne("BooksAndGenre.Model.Books", "Book")
                        .WithMany()
                        .HasForeignKey("ID_Book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadersAndRent.Model.Readers", "Readers")
                        .WithMany()
                        .HasForeignKey("ID_Reader")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Readers");
                });
#pragma warning restore 612, 618
        }
    }
}
