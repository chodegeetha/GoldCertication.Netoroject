using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCertificationExam.Server.Migrations
{
    /// <inheritdoc />
    public partial class mmmll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingOrder_Packages_PackageId",
                table: "BookingOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingOrder",
                table: "BookingOrder");

            migrationBuilder.RenameTable(
                name: "BookingOrder",
                newName: "BookingOrders");

            migrationBuilder.RenameIndex(
                name: "IX_BookingOrder_PackageId",
                table: "BookingOrders",
                newName: "IX_BookingOrders_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingOrders",
                table: "BookingOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingOrders_Packages_PackageId",
                table: "BookingOrders",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingOrders_Packages_PackageId",
                table: "BookingOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingOrders",
                table: "BookingOrders");

            migrationBuilder.RenameTable(
                name: "BookingOrders",
                newName: "BookingOrder");

            migrationBuilder.RenameIndex(
                name: "IX_BookingOrders_PackageId",
                table: "BookingOrder",
                newName: "IX_BookingOrder_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingOrder",
                table: "BookingOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingOrder_Packages_PackageId",
                table: "BookingOrder",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
