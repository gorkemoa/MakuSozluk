﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240501224340_writer_edit2")]
    partial class writer_edit2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AboutID"));

                    b.Property<string>("AboutDetails1")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("AboutDetails2")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("AboutImage1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("AboutImage2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("boolean");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UserMail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Content", b =>
                {
                    b.Property<int>("ContentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContentID"));

                    b.Property<DateTime>("ContentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ContentValue")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("HeadingID")
                        .HasColumnType("integer");

                    b.Property<int>("WriterID")
                        .HasColumnType("integer");

                    b.HasKey("ContentID");

                    b.HasIndex("HeadingID");

                    b.HasIndex("WriterID");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Heading", b =>
                {
                    b.Property<int>("HeadingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HeadingID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HeadingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HeadingName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("WriterID")
                        .HasColumnType("integer");

                    b.HasKey("HeadingID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WriterID");

                    b.ToTable("Headings");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Property<int>("WriterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WriterID"));

                    b.Property<string>("WriterAbout")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("WriterImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("WriterMail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("WriterName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("WriterPassword")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("WriterSurName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("WriterTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("WriterID");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Content", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Heading", "Heading")
                        .WithMany("contents")
                        .HasForeignKey("HeadingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Writer", "Writer")
                        .WithMany("Contents")
                        .HasForeignKey("WriterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Heading");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Heading", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Headings")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Writer", "Writer")
                        .WithMany("Headings")
                        .HasForeignKey("WriterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Headings");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Heading", b =>
                {
                    b.Navigation("contents");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Navigation("Contents");

                    b.Navigation("Headings");
                });
#pragma warning restore 612, 618
        }
    }
}
