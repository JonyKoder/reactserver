using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactserver.database.Migrations
{
    /// <inheritdoc />
    public partial class AddPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountHolderName",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BankAddress",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "SWIFTCode",
                table: "BankAccounts",
                newName: "CorrespondentAccount");

            migrationBuilder.RenameColumn(
                name: "IBAN",
                table: "BankAccounts",
                newName: "CheckingAccount");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "BankAccounts",
                newName: "BranchName");

            migrationBuilder.RenameColumn(
                name: "BankCode",
                table: "BankAccounts",
                newName: "Bic");

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    inn = table.Column<long>(type: "bigint", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    second_name = table.Column<string>(type: "text", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    spdul_code = table.Column<int>(type: "integer", nullable: false),
                    doc_ser_num = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.RenameColumn(
                name: "CorrespondentAccount",
                table: "BankAccounts",
                newName: "SWIFTCode");

            migrationBuilder.RenameColumn(
                name: "CheckingAccount",
                table: "BankAccounts",
                newName: "IBAN");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "BankAccounts",
                newName: "BankName");

            migrationBuilder.RenameColumn(
                name: "Bic",
                table: "BankAccounts",
                newName: "BankCode");

            migrationBuilder.AddColumn<string>(
                name: "AccountHolderName",
                table: "BankAccounts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "BankAccounts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BankAddress",
                table: "BankAccounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
