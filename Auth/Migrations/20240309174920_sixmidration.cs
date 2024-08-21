using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.Migrations
{
    /// <inheritdoc />
    public partial class sixmidration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "13cb7c6b-322a-4a8b-86b5-7907d09e698b", "f1f7738d-ecad-4eb9-82bd-c98ea8d36ada", "admin", "admin" },
                    { "292eac5e-c9d2-4ef8-93ac-530208605d5b", "c76bc8fd-21cf-4a63-8889-960de3db023e", "client", "client" },
                    { "d15238cf-eff6-4dc3-90e6-a995efe22673", "bb2a6ef3-9276-4b9c-8230-0aeb6292b2ef", "seller", "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "49a366b2-fedb-4f1d-bdea-4418c9cf83b3", "89766788-a949-4678-9512-075ac19ac1d3", "admin", "admin" },
                    { "5f91c218-ffd2-4ab7-afca-a444cc891eb4", "b78b019b-14b9-460d-8de8-ea5b38b1f636", "client", "client" },
                    { "aad81055-81e6-409d-b65d-08b8534d2475", "dc90ddd7-1162-4e4c-82ab-099103337c4a", "seller", "seller" }
                });
        }
    }
}
