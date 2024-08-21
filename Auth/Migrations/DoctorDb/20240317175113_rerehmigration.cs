using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Migrations.DoctorDb
{
    /// <inheritdoc />
    public partial class rerehmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientName1",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName1",
                table: "Appointments");
        }
    }
}
