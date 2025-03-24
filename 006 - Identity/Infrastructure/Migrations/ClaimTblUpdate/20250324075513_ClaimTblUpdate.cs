using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.ClaimTblUpdate
{
    /// <inheritdoc />
    public partial class ClaimTblUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Claims",
                newName: "ClaimValue");

            migrationBuilder.RenameIndex(
                name: "IX_Claims_Name",
                table: "Claims",
                newName: "IX_Claims_ClaimValue");

            migrationBuilder.AddColumn<string>(
                name: "ClaimType",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimType",
                table: "Claims");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "Claims",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Claims_ClaimValue",
                table: "Claims",
                newName: "IX_Claims_Name");
        }
    }
}
