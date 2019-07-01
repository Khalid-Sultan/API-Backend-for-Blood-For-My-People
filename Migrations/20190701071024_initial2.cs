using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonation.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donors_users_userId",
                table: "donors");

            migrationBuilder.DropForeignKey(
                name: "FK_recepients_users_userId",
                table: "recepients");

            migrationBuilder.DropIndex(
                name: "IX_recepients_userId",
                table: "recepients");

            migrationBuilder.DropIndex(
                name: "IX_donors_userId",
                table: "donors");

            migrationBuilder.CreateIndex(
                name: "IX_recepients_userId",
                table: "recepients",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_donors_userId",
                table: "donors",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_donors_users_userId",
                table: "donors",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recepients_users_userId",
                table: "recepients",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donors_users_userId",
                table: "donors");

            migrationBuilder.DropForeignKey(
                name: "FK_recepients_users_userId",
                table: "recepients");

            migrationBuilder.DropIndex(
                name: "IX_recepients_userId",
                table: "recepients");

            migrationBuilder.DropIndex(
                name: "IX_donors_userId",
                table: "donors");

            migrationBuilder.CreateIndex(
                name: "IX_recepients_userId",
                table: "recepients",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_donors_userId",
                table: "donors",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_donors_users_userId",
                table: "donors",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_recepients_users_userId",
                table: "recepients",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
