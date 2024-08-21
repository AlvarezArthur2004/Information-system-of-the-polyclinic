using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.Migrations
{
    /// <inheritdoc />
    public partial class FouthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc94d62-844d-4694-be6b-ec03cc04176b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7fa321a-33d6-4287-8837-de93f4297573");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaaee491-d5d9-43eb-8254-f7cd8388e429");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10adaf69-5cd2-4b47-8120-ed6f0dd0a26a", "50c3c567-05a2-417f-97ee-9b0072110797", "seller", "seller" },
                    { "8977cba2-74ec-40f9-8376-b1ec80cded21", "ac70addf-cbd5-4652-a6a0-8e15695f31c1", "admin", "admin" },
                    { "de8cadf7-627a-4f7a-bbe0-aac0b5e8514c", "7893f04d-dea7-4dcf-87d2-4eb5e08ad691", "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10adaf69-5cd2-4b47-8120-ed6f0dd0a26a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8977cba2-74ec-40f9-8376-b1ec80cded21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de8cadf7-627a-4f7a-bbe0-aac0b5e8514c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bdc94d62-844d-4694-be6b-ec03cc04176b", "84adb541-cfab-4d6b-8c8e-c28491301a49", "admin", "admin" },
                    { "e7fa321a-33d6-4287-8837-de93f4297573", "1a70dd13-7514-4d5a-961d-cc6abba9ceb0", "seller", "seller" },
                    { "eaaee491-d5d9-43eb-8254-f7cd8388e429", "7aa17ce5-dae9-4d40-93b2-974d6f95f9b9", "client", "client" }
                });
        }
    }
}
