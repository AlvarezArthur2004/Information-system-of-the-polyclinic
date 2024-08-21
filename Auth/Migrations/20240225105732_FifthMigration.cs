using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "49a366b2-fedb-4f1d-bdea-4418c9cf83b3", "89766788-a949-4678-9512-075ac19ac1d3", "admin", "admin" },
                    { "5f91c218-ffd2-4ab7-afca-a444cc891eb4", "b78b019b-14b9-460d-8de8-ea5b38b1f636", "client", "client" },
                    { "aad81055-81e6-409d-b65d-08b8534d2475", "dc90ddd7-1162-4e4c-82ab-099103337c4a", "seller", "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49a366b2-fedb-4f1d-bdea-4418c9cf83b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f91c218-ffd2-4ab7-afca-a444cc891eb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aad81055-81e6-409d-b65d-08b8534d2475");

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
    }
}
