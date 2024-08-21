using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.Migrations
{
    /// <inheritdoc />
    public partial class commig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingSum",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a8adb08-7dcd-47e1-95ea-47065c36a5af", "6319fc43-9f6b-42c7-bf26-1261a873f622", "client", "client" },
                    { "60378c6f-4be4-4030-9794-ceb2a0f129e9", "1eef1840-d071-46d9-98ff-0b3c5dadd320", "seller", "seller" },
                    { "f86f5d76-8038-4681-9dd9-97ef694a4630", "30979e2a-b1d6-454b-8864-55d2a7900491", "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a8adb08-7dcd-47e1-95ea-47065c36a5af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60378c6f-4be4-4030-9794-ceb2a0f129e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f86f5d76-8038-4681-9dd9-97ef694a4630");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RatingSum",
                table: "AspNetUsers");

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
    }
}
