﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AboutDetails1 = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AboutDetails2 = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AboutImage1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AboutImage2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CategoryDescription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CategoryStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserMail = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WriterName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WriterSurName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WriterImage = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WriterMail = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WriterPassword = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterID);
                });

            migrationBuilder.CreateTable(
                name: "Headings",
                columns: table => new
                {
                    HeadingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeadingName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HeadingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoryID = table.Column<int>(type: "integer", nullable: false),
                    WriterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headings", x => x.HeadingID);
                    table.ForeignKey(
                        name: "FK_Headings_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Headings_Writers_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContentValue = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ContentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HeadingID = table.Column<int>(type: "integer", nullable: false),
                    WriterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentID);
                    table.ForeignKey(
                        name: "FK_Contents_Headings_HeadingID",
                        column: x => x.HeadingID,
                        principalTable: "Headings",
                        principalColumn: "HeadingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Writers_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_HeadingID",
                table: "Contents",
                column: "HeadingID");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_WriterID",
                table: "Contents",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_Headings_CategoryID",
                table: "Headings",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Headings_WriterID",
                table: "Headings",
                column: "WriterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Headings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Writers");
        }
    }
}
