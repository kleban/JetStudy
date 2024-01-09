using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JetStudy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailedDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0836c367-ee42-4947-971d-f2551ab3c543"), null, "Teacher", "TEACHER" },
                    { new Guid("7b43f445-c2f1-41ff-bdbd-4eb05c6a40b0"), null, "Student", "STUDENT" },
                    { new Guid("b84b38c2-b97f-495b-8169-4e4df322d0ba"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("035a18e1-2330-44cc-ae97-41500e7ac98a"), 0, null, "443f5d99-7117-428f-8e3c-4827ffac573f", new DateTime(2046, 11, 17, 9, 24, 28, 188, DateTimeKind.Local).AddTicks(4153), "std@jetstudy.com", true, "Andriy", "Petrenko", false, null, "STD@JETSTUDY.COM", "STD@JETSTUDY.COM", "AQAAAAIAAYagAAAAEAe92FmCYIqepdfOI32mdKVZLPdB7+9jVSYhendX8HOT5vKiUJugNvS3aBS3qTsCAA==", null, false, null, null, false, "std@jetstudy.com" },
                    { new Guid("ab93c4a1-1cec-43f1-86f4-d973db683a65"), 0, null, "7c6d7458-b3ea-40a8-8675-d7497fe33399", new DateTime(2048, 11, 17, 9, 24, 28, 188, DateTimeKind.Local).AddTicks(4092), "admin@jetstudy.com", true, "Ivan", "Petrenko", false, null, "ADMIN@JETSTUDY.COM", "ADMIN@JETSTUDY.COM", "AQAAAAIAAYagAAAAEHWgSFizcM5p4zdPAicSELWqbNfUMsFp+z27b2g6Sr+QNg5IejYEow+mDD1UrE6p3g==", null, false, null, null, false, "admin@jetstudy.com" },
                    { new Guid("df5fabe9-be0f-4bd6-9a10-a98b5acf6d36"), 0, null, "75b7734e-0fdb-4425-9408-14c39a1c6bcf", new DateTime(2044, 11, 17, 9, 24, 28, 188, DateTimeKind.Local).AddTicks(4159), "teacher@jetstudy.com", true, "Olena", "Petrenko", false, null, "TEACHER@JETSTUDY.COM", "TEACHER@JETSTUDY.COM", "AQAAAAIAAYagAAAAEKpQ3jcKvqSJn96qyRjUyGecRfTlBvf2PwYDCSavX+CMLcnFPrrC3CNlEyizSq0GpA==", null, false, null, null, false, "teacher@jetstudy.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0836c367-ee42-4947-971d-f2551ab3c543"), new Guid("035a18e1-2330-44cc-ae97-41500e7ac98a") },
                    { new Guid("7b43f445-c2f1-41ff-bdbd-4eb05c6a40b0"), new Guid("035a18e1-2330-44cc-ae97-41500e7ac98a") },
                    { new Guid("0836c367-ee42-4947-971d-f2551ab3c543"), new Guid("ab93c4a1-1cec-43f1-86f4-d973db683a65") },
                    { new Guid("b84b38c2-b97f-495b-8169-4e4df322d0ba"), new Guid("ab93c4a1-1cec-43f1-86f4-d973db683a65") },
                    { new Guid("0836c367-ee42-4947-971d-f2551ab3c543"), new Guid("df5fabe9-be0f-4bd6-9a10-a98b5acf6d36") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CoverPath", "DetailedDesc", "OwnerId", "Requirements", "ShortDesc", "Title" },
                values: new object[,]
                {
                    { new Guid("79a7201f-de5c-4d41-8eaf-0ad778f687a1"), "\\img\\course\\no_cover.jpg", "Курс \"Аналіз даних для наукових досліджень\" є спеціалізованим навчальним програмою, розробленим для тих, хто цікавиться використанням аналізу даних у наукових дослідженнях. Курс вдосконалює розуміння учасників щодо методів, інструментів і процесів, пов'язаних з обробкою і аналізом даних в контексті наукових досліджень.", new Guid("df5fabe9-be0f-4bd6-9a10-a98b5acf6d36"), "Python, R, Jupyter Notebook, Anaconda, RStduio Desktop", "Курс розглядає методи та інструменти аналізу даних у наукових дослідженнях. Включає в себе збір, очищення і статистичний аналіз даних, щоб підготувати учасників до ефективного проведення наукових досліджень.", "Аналіз даних для наукових досліджень" },
                    { new Guid("8f1ebc39-cc6b-4a54-a617-26061c6f171e"), "\\img\\course\\no_cover.jpg", "Курс \"Аналіз даних для наукових досліджень\" є спеціалізованим навчальним програмою, розробленим для тих, хто цікавиться використанням аналізу даних у наукових дослідженнях. Курс вдосконалює розуміння учасників щодо методів, інструментів і процесів, пов'язаних з обробкою і аналізом даних в контексті наукових досліджень.", new Guid("ab93c4a1-1cec-43f1-86f4-d973db683a65"), "Python, R, Jupyter Notebook, Anaconda, RStduio Desktop", "Курс розглядає методи та інструменти аналізу даних у наукових дослідженнях. Включає в себе збір, очищення і статистичний аналіз даних, щоб підготувати учасників до ефективного проведення наукових досліджень.", "Аналіз даних для маркетингу" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OwnerId",
                table: "Courses",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
