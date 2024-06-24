using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScientificActivities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixJournalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Journals");

            migrationBuilder.AddColumn<int>(
                name: "CoreRsci",
                table: "Journals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rsci",
                table: "Journals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vak",
                table: "Journals",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoreRsci",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "Rsci",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "Vak",
                table: "Journals");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Journals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
