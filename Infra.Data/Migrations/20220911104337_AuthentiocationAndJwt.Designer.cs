﻿// <auto-generated />
using System;
using Infra.Data.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220911104337_AuthentiocationAndJwt")]
    partial class AuthentiocationAndJwt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("BookType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PageNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Published")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Domain.Models.BookShelf", b =>
                {
                    b.Property<int?>("BookID")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "ShelfID");

                    b.HasIndex("ShelfID");

                    b.ToTable("bookShelves");
                });

            modelBuilder.Entity("Domain.Models.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("BookRead")
                        .HasColumnType("bit");

                    b.Property<bool?>("BookReading")
                        .HasColumnType("bit");

                    b.Property<bool?>("BookRed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReadDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShelfName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("Domain.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Domain.Models.BookShelf", b =>
                {
                    b.HasOne("Domain.Models.Books", "Book")
                        .WithMany("BookShelves")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Shelf", "Shelf")
                        .WithMany("BookShelves")
                        .HasForeignKey("ShelfID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("Domain.Models.Shelf", b =>
                {
                    b.HasOne("Domain.Models.Users", "User")
                        .WithMany("Shelves")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Books", b =>
                {
                    b.Navigation("BookShelves");
                });

            modelBuilder.Entity("Domain.Models.Shelf", b =>
                {
                    b.Navigation("BookShelves");
                });

            modelBuilder.Entity("Domain.Models.Users", b =>
                {
                    b.Navigation("Shelves");
                });
#pragma warning restore 612, 618
        }
    }
}
