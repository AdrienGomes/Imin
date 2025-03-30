using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMINBackend.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase_Distribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastDistribution",
                table: "Volunteers",
                newName: "LastDistributionDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PoleMemberships",
                newName: "MembershipStatus");

            migrationBuilder.AddColumn<int>(
                name: "MinimumAge",
                table: "Poles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumNumberOfVolunteers",
                table: "Poles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "PoleMemberships",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    State = table.Column<string>(type: "varchar(30)", nullable: false),
                    PublisherId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributions_Volunteers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistributionEnlistements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DistributionId = table.Column<string>(type: "text", nullable: false),
                    VolunteerId = table.Column<string>(type: "text", nullable: false),
                    PoleId = table.Column<string>(type: "text", nullable: false),
                    PoleEnlistementStatus = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionEnlistements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributionEnlistements_Distributions_DistributionId",
                        column: x => x.DistributionId,
                        principalTable: "Distributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributionEnlistements_Poles_PoleId",
                        column: x => x.PoleId,
                        principalTable: "Poles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributionEnlistements_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoleDistributionEnlistements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DistributionId = table.Column<string>(type: "text", nullable: false),
                    PoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoleDistributionEnlistements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoleDistributionEnlistements_Distributions_DistributionId",
                        column: x => x.DistributionId,
                        principalTable: "Distributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoleDistributionEnlistements_Poles_PoleId",
                        column: x => x.PoleId,
                        principalTable: "Poles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistributionEnlistements_DistributionId",
                table: "DistributionEnlistements",
                column: "DistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionEnlistements_PoleId",
                table: "DistributionEnlistements",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionEnlistements_VolunteerId",
                table: "DistributionEnlistements",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_PublisherId",
                table: "Distributions",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_PoleDistributionEnlistements_DistributionId",
                table: "PoleDistributionEnlistements",
                column: "DistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoleDistributionEnlistements_PoleId",
                table: "PoleDistributionEnlistements",
                column: "PoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributionEnlistements");

            migrationBuilder.DropTable(
                name: "PoleDistributionEnlistements");

            migrationBuilder.DropTable(
                name: "Distributions");

            migrationBuilder.DropColumn(
                name: "MinimumAge",
                table: "Poles");

            migrationBuilder.DropColumn(
                name: "MinimumNumberOfVolunteers",
                table: "Poles");

            migrationBuilder.RenameColumn(
                name: "LastDistributionDate",
                table: "Volunteers",
                newName: "LastDistribution");

            migrationBuilder.RenameColumn(
                name: "MembershipStatus",
                table: "PoleMemberships",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "PoleMemberships",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
