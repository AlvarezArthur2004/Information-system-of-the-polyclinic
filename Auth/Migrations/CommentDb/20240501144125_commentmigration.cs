using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Migrations.CommentDb
{
    /// <inheritdoc />
    public partial class commentmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacientId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PacientId",
                table: "Comments");
        }
    }
}
