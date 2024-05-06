using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCertificationExam.Server.Migrations
{
    /// <inheritdoc />
    public partial class mmmlj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "BookingOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "BookingOrders");
        }
    }
}
