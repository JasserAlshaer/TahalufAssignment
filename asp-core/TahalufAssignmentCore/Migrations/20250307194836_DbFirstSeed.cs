using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TahalufAssignmentCore.Migrations
{
    /// <inheritdoc />
    public partial class DbFirstSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupTypes", x => x.Id);
                    table.CheckConstraint("CH_Name_Length1", "LEN(NameAr) >= 2");
                    table.CheckConstraint("CH_NameAr_Length1", "LEN(Name) >= 2");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    LastName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserType = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValue: "Student"),
                    Email = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CH_UserFirstName", "LEN(FirstName)>=3");
                    table.CheckConstraint("CH_UserLastName", "LEN(LastName)>=3");
                    table.CheckConstraint("CH_UserType", "UserType like 'Admin'");
                });

            migrationBuilder.CreateTable(
                name: "LookupItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LookupTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupItems", x => x.Id);
                    table.CheckConstraint("CH_Name_Length", "LEN(NameAr) >= 2");
                    table.CheckConstraint("CH_NameAr_Length", "LEN(Name) >= 2");
                    table.ForeignKey(
                        name: "FK_LookupItems_LookupTypes_LookupTypeId",
                        column: x => x.LookupTypeId,
                        principalTable: "LookupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LookupTypes",
                columns: new[] { "Id", "CreationDate", "ModifiedDate", "Name", "NameAr" },
                values: new object[] { 1, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(2903), null, "Country", "الدولة" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "FirstName", "LastLoginDate", "LastName", "ModifiedDate", "Password", "UserType", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3115), "joshaer17@gmail.com", "Jasser", null, "Alshaer", null, "E140417FC6C73036D8E588CF6BDF571456DF87F7A7638DB7F2203A0CA86C5FB1891971D1FD87717D19D558DEEC66D337", "Admin", "FC8C0C79545BB5E9AFE969574C81EEABE7702CAD289584B0B19DFEDFBEB338A626B855A7DDB54A9FF0A9B73C76CB3FDF" },
                    { 2, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3411), "admin@tahaluf.com", "Admin", null, "Assignement", null, "E58DF53ED3BC705D5B921BA27A6101B88380F0FABAC71A1DF84834254E1F1B31D7A7700C4388E36F0F76B9148D90985B", "Admin", "9CA694A90285C034432C9550421B7B9DBD5C0F4B6673F05F6DBCE58052BA20E4248041956EE8C9A2EC9F10290CDC0782" }
                });

            migrationBuilder.InsertData(
                table: "LookupItems",
                columns: new[] { "Id", "CreationDate", "LookupTypeId", "ModifiedDate", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3005), 1, null, "United States", "الولايات المتحدة" },
                    { 2, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3006), 1, null, "Jordan", "الأردن" },
                    { 3, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3007), 1, null, "Saudi Arabia", "المملكة العربية السعودية" },
                    { 4, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3008), 1, null, "United Arab Emirates", "الإمارات العربية المتحدة" },
                    { 5, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3009), 1, null, "Egypt", "مصر" },
                    { 6, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3049), 1, null, "Morocco", "المغرب" },
                    { 7, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3050), 1, null, "France", "فرنسا" },
                    { 8, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3051), 1, null, "Germany", "ألمانيا" },
                    { 9, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3052), 1, null, "United Kingdom", "المملكة المتحدة" },
                    { 10, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3053), 1, null, "Italy", "إيطاليا" },
                    { 11, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3054), 1, null, "Spain", "إسبانيا" },
                    { 12, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3054), 1, null, "Qatar", "قطر" },
                    { 13, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3055), 1, null, "Lebanon", "لبنان" },
                    { 14, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3056), 1, null, "Syria", "سوريا" },
                    { 15, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3057), 1, null, "Iraq", "العراق" },
                    { 16, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3058), 1, null, "Kuwait", "الكويت" },
                    { 17, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3058), 1, null, "Oman", "عمان" },
                    { 18, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3059), 1, null, "Bahrain", "البحرين" },
                    { 19, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3061), 1, null, "Algeria", "الجزائر" },
                    { 20, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3062), 1, null, "Tunisia", "تونس" },
                    { 21, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3062), 1, null, "Libya", "ليبيا" },
                    { 22, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3063), 1, null, "Palestine", "فلسطين" },
                    { 23, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3064), 1, null, "Turkey", "تركيا" },
                    { 24, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3065), 1, null, "Greece", "اليونان" },
                    { 25, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3066), 1, null, "Portugal", "البرتغال" },
                    { 26, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3066), 1, null, "Netherlands", "هولندا" },
                    { 27, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3067), 1, null, "Belgium", "بلجيكا" },
                    { 28, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3068), 1, null, "Sweden", "السويد" },
                    { 29, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3069), 1, null, "Norway", "النرويج" },
                    { 30, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3069), 1, null, "Denmark", "الدنمارك" },
                    { 31, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3070), 1, null, "Switzerland", "سويسرا" },
                    { 32, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3071), 1, null, "Austria", "النمسا" },
                    { 33, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3072), 1, null, "Russia", "روسيا" },
                    { 34, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3072), 1, null, "China", "الصين" },
                    { 35, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3073), 1, null, "Japan", "اليابان" },
                    { 36, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3074), 1, null, "India", "الهند" },
                    { 37, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3075), 1, null, "Canada", "كندا" },
                    { 38, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3075), 1, null, "Australia", "أستراليا" },
                    { 39, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3076), 1, null, "Brazil", "البرازيل" },
                    { 40, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3077), 1, null, "South Africa", "جنوب أفريقيا" },
                    { 41, new DateTime(2025, 3, 7, 22, 48, 36, 199, DateTimeKind.Local).AddTicks(3078), 1, null, "Other", "غير ذلك" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookupItems_LookupTypeId",
                table: "LookupItems",
                column: "LookupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupItems_Name",
                table: "LookupItems",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_LookupItems_NameAr",
                table: "LookupItems",
                column: "NameAr");

            migrationBuilder.CreateIndex(
                name: "IX_LookupTypes_Name",
                table: "LookupTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookupTypes_NameAr",
                table: "LookupTypes",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookupItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LookupTypes");
        }
    }
}
