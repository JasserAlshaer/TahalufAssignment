using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TahalufAssignmentCore.Migrations
{
    /// <inheritdoc />
    public partial class EditOrgnizationIdColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Orgnizations_OrgnizationId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "OrgnizationId",
                table: "Companies",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_OrgnizationId",
                table: "Companies",
                newName: "IX_Companies_OrganizationId");

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 3, 10, 0, 41, 58, 989, DateTimeKind.Local).AddTicks(5824));

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Orgnizations_OrganizationId",
                table: "Companies",
                column: "OrganizationId",
                principalTable: "Orgnizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Orgnizations_OrganizationId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Companies",
                newName: "OrgnizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_OrganizationId",
                table: "Companies",
                newName: "IX_Companies_OrgnizationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Orgnizations_OrgnizationId",
                table: "Companies",
                column: "OrgnizationId",
                principalTable: "Orgnizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
