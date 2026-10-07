using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gatcha_server.Migrations
{
    /// <inheritdoc />
    public partial class Addedshopelements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Coins",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "selected_background",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "selected_character",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "selected_timer",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coins",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "selected_background",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "selected_character",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "selected_timer",
                table: "Users");
        }
    }
}
