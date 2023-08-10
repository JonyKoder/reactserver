using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactserver.database.Migrations
{
    /// <inheritdoc />
    public partial class changeIndividual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    INN = table.Column<string>(type: "text", nullable: false),
                    OGRN = table.Column<string>(type: "text", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualEntrepreneurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    INN = table.Column<string>(type: "text", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OGRNIP = table.Column<string>(type: "text", nullable: false),
                    ScanInnImage = table.Column<string>(type: "text", nullable: false),
                    OgrnIpImage = table.Column<string>(type: "text", nullable: false),
                    EgripImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualEntrepreneurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KindActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IndividualEntrepreneurId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KindActivities_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KindActivities_IndividualEntrepreneurs_IndividualEntreprene~",
                        column: x => x.IndividualEntrepreneurId,
                        principalTable: "IndividualEntrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KindActivities_CompanyId",
                table: "KindActivities",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_KindActivities_IndividualEntrepreneurId",
                table: "KindActivities",
                column: "IndividualEntrepreneurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KindActivities");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "IndividualEntrepreneurs");
        }
    }
}
