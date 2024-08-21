using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.Migrations
{
    /// <inheritdoc />
    public partial class sevenmidration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13cb7c6b-322a-4a8b-86b5-7907d09e698b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "292eac5e-c9d2-4ef8-93ac-530208605d5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d15238cf-eff6-4dc3-90e6-a995efe22673");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "13cb7c6b-322a-4a8b-86b5-7907d09e698b", "f1f7738d-ecad-4eb9-82bd-c98ea8d36ada", "admin", "admin" },
                    { "292eac5e-c9d2-4ef8-93ac-530208605d5b", "c76bc8fd-21cf-4a63-8889-960de3db023e", "client", "client" },
                    { "d15238cf-eff6-4dc3-90e6-a995efe22673", "bb2a6ef3-9276-4b9c-8230-0aeb6292b2ef", "seller", "seller" }
                });
        }
    }
}
