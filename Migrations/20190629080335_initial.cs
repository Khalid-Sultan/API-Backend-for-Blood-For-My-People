using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonation.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    user_login = table.Column<string>(nullable: true),
                    user_url = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    stargazers_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "donors",
                columns: table => new
                {
                    donorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(nullable: true),
                    fullName = table.Column<string>(nullable: true),
                    dateOfBirth = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donors", x => x.donorId);
                    table.ForeignKey(
                        name: "FK_donors_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recepients",
                columns: table => new
                {
                    recepientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recepients", x => x.recepientId);
                    table.ForeignKey(
                        name: "FK_recepients_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "donationHistories",
                columns: table => new
                {
                    donationHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    donorId = table.Column<int>(nullable: true),
                    recepientId = table.Column<int>(nullable: true),
                    amount = table.Column<double>(nullable: false),
                    date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donationHistories", x => x.donationHistoryId);
                    table.ForeignKey(
                        name: "FK_donationHistories_donors_donorId",
                        column: x => x.donorId,
                        principalTable: "donors",
                        principalColumn: "donorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_donationHistories_recepients_recepientId",
                        column: x => x.recepientId,
                        principalTable: "recepients",
                        principalColumn: "recepientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    reportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    donationHistoryId = table.Column<int>(nullable: true),
                    bloodType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_reports_donationHistories_donationHistoryId",
                        column: x => x.donationHistoryId,
                        principalTable: "donationHistories",
                        principalColumn: "donationHistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donationHistories_donorId",
                table: "donationHistories",
                column: "donorId");

            migrationBuilder.CreateIndex(
                name: "IX_donationHistories_recepientId",
                table: "donationHistories",
                column: "recepientId");

            migrationBuilder.CreateIndex(
                name: "IX_donors_userId",
                table: "donors",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_recepients_userId",
                table: "recepients",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_donationHistoryId",
                table: "reports",
                column: "donationHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "donationHistories");

            migrationBuilder.DropTable(
                name: "donors");

            migrationBuilder.DropTable(
                name: "recepients");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
