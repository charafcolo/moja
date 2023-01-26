﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class ModelsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Entreprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepriseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosteRep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepriseId = table.Column<int>(type: "int", nullable: false),
                    linkedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatures_AspNetUsers_linkedUserId",
                        column: x => x.linkedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidatures_Entreprises_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "e159a8cc-3c43-4357-8b34-a473b9cff5f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "37b6f045-543a-45df-9d32-5e5c9f94f6bb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "fc8d440d-a42f-4abd-b038-fe962292bdf7", "", "", "AQAAAAEAACcQAAAAECPLBluyyKuWbNsbe2neNNkU0DnfrhmcySsqFwV0M8ABM0H1NYCdVpismiiWWV5aaA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_EntrepriseId",
                table: "Candidatures",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_linkedUserId",
                table: "Candidatures",
                column: "linkedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatures");

            migrationBuilder.DropTable(
                name: "Entreprises");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "f598bd95-0175-4e34-9d6a-f4a8f4e396b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "e7a8299e-1390-42a4-936f-bab248451b46");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13fd7a40-ec10-4cc7-bac1-0a3a9b0badae", "AQAAAAEAACcQAAAAEPDP4qcyubBW8V2YL/Y3TYIOyb7BhRvSRwoKGwErBw3I2nZtH7wr5/6shMIXbYFDVw==" });
        }
    }
}