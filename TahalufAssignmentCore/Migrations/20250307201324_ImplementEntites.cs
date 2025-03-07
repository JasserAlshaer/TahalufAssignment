using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TahalufAssignmentCore.Migrations
{
    /// <inheritdoc />
    public partial class ImplementEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orgnizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgnizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orgnizations_LookupItems_CountryId",
                        column: x => x.CountryId,
                        principalTable: "LookupItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    OrgnizationId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_LookupItems_CountryId",
                        column: x => x.CountryId,
                        principalTable: "LookupItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Orgnizations_OrgnizationId",
                        column: x => x.OrgnizationId,
                        principalTable: "Orgnizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 23, 13, 24, 234, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OrgnizationId",
                table: "Companies",
                column: "OrgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orgnizations_CountryId",
                table: "Orgnizations",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Orgnizations");

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3411));
        }
    }
}
