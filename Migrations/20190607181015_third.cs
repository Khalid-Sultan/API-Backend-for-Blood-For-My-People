using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonation.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "items",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "items",
                newName: "user_url");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "stargazers_count",
                table: "items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "user_login",
                table: "items",
                nullable: true);

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
                name: "reports");

            migrationBuilder.DropTable(
                name: "donationHistories");

            migrationBuilder.DropTable(
                name: "donors");

            migrationBuilder.DropTable(
                name: "recepients");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropColumn(
                name: "description",
                table: "items");

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "items");

            migrationBuilder.DropColumn(
                name: "name",
                table: "items");

            migrationBuilder.DropColumn(
                name: "stargazers_count",
                table: "items");

            migrationBuilder.DropColumn(
                name: "user_login",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_url",
                table: "items",
                newName: "value");
        }
    }
}
