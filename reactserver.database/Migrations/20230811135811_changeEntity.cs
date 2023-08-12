using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactserver.database.Migrations
{
    /// <inheritdoc />
    public partial class changeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KindActivities");

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountId",
                table: "IndividualEntrepreneurs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    BankCode = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: false),
                    BankAddress = table.Column<string>(type: "text", nullable: false),
                    SWIFTCode = table.Column<string>(type: "text", nullable: false),
                    IBAN = table.Column<string>(type: "text", nullable: false),
                    AccountHolderName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualEntrepreneurs_BankAccountId",
                table: "IndividualEntrepreneurs",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualEntrepreneurs_BankAccounts_BankAccountId",
                table: "IndividualEntrepreneurs",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualEntrepreneurs_BankAccounts_BankAccountId",
                table: "IndividualEntrepreneurs");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_IndividualEntrepreneurs_BankAccountId",
                table: "IndividualEntrepreneurs");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "IndividualEntrepreneurs");

            migrationBuilder.CreateTable(
                name: "KindActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndividualEntrepreneurId = table.Column<Guid>(type: "uuid", nullable: false)
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
    }
}
