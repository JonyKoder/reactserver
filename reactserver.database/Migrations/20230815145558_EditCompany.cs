using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactserver.database.Migrations
{
    /// <inheritdoc />
    public partial class EditCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "peoples");

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountId",
                table: "Companies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Bic",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CheckingAccount",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CorrespondentAccount",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EgripImage",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OgrnIpImage",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScanInnImage",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BankAccountId",
                table: "Companies",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_BankAccounts_BankAccountId",
                table: "Companies",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_BankAccounts_BankAccountId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_BankAccountId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Bic",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CheckingAccount",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CorrespondentAccount",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "EgripImage",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "OgrnIpImage",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ScanInnImage",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "peoples",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    doc_ser_num = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    inn = table.Column<long>(type: "bigint", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    second_name = table.Column<string>(type: "text", nullable: false),
                    spdul_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peoples", x => x.id);
                });
        }
    }
}
