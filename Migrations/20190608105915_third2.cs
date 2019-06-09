using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonation.Migrations
{
    public partial class third2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "reportId",
                table: "reports",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "recepientId",
                table: "recepients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "donorId",
                table: "donors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "donationHistoryId",
                table: "donationHistories",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reports",
                newName: "reportId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "recepients",
                newName: "recepientId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "donors",
                newName: "donorId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "donationHistories",
                newName: "donationHistoryId");
        }
    }
}
