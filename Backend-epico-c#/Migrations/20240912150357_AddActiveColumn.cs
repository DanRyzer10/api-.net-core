using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_epico_c_.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Clients",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Clients");
        }
    }
}
