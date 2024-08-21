using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.Migrations
{
    /// <inheritdoc />
    public partial class eightmidration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053819c0-5446-426c-a8f6-e5aae6f4a99e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084612b8-c960-4c0e-9f74-7372559d4b10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce9f662b-99d1-4be7-b185-f7ece57fa32b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d93ccd6-b011-454f-b0cd-e4e12359e33e", "e4c18d98-82e7-4148-bbaa-cb5ba836b3ec", "admin", "admin" },
                    { "ad12a1e5-d86b-4a22-9c9b-8d3c8befa200", "348dfdb1-c80e-4884-ab59-b5b72e52b2aa", "client", "client" },
                    { "f46f4715-5672-49da-9ae1-db6cd1cba4d4", "15849bb3-e445-43a5-80fc-6b7f49f66e75", "seller", "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d93ccd6-b011-454f-b0cd-e4e12359e33e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad12a1e5-d86b-4a22-9c9b-8d3c8befa200");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f46f4715-5672-49da-9ae1-db6cd1cba4d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053819c0-5446-426c-a8f6-e5aae6f4a99e", "22d933f2-33d2-4ff1-b28c-052217c8cde4", "seller", "seller" },
                    { "084612b8-c960-4c0e-9f74-7372559d4b10", "1de00fc0-7efa-4741-960a-1090dab84a62", "client", "client" },
                    { "ce9f662b-99d1-4be7-b185-f7ece57fa32b", "27528035-500e-4c7e-b392-d25212b8cba9", "admin", "admin" }
                });
        }
    }
}
