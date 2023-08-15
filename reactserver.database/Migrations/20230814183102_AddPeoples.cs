using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactserver.database.Migrations
{
    /// <inheritdoc />
    public partial class AddPeoples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Peoples",
                table: "Peoples");

            migrationBuilder.RenameTable(
                name: "Peoples",
                newName: "peoples");

            migrationBuilder.AddPrimaryKey(
                name: "PK_peoples",
                table: "peoples",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_peoples",
                table: "peoples");

            migrationBuilder.RenameTable(
                name: "peoples",
                newName: "Peoples");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peoples",
                table: "Peoples",
                column: "id");
        }
    }
}
