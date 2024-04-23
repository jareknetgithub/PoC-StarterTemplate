using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoCStarterTemplate.Server.Migrations
{
    /// <inheritdoc />
    public partial class DBInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("5d533b96-5fae-4147-b16b-c78eda4c3078"), "user@user.com", "User", "$2a$11$eCDWs7kKK3W/245SitYLz..wghxOWSU3By6sS60CMYGb3PfPWOXZe", "1234567891" },
                    { new Guid("fff1ae44-c101-4b6c-b417-bf3df4ba7e89"), "admin@admin.com", "Admin", "$2a$11$NgSnpDYhRUi/aDft.7.T7uBGCl/B1dOp1CNAyYjy0zfbic75cs8SW", "1234567890" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
