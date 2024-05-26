using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10134934_CLDV6211_Part_Two.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTran2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Transaction",
                newName: "ArtStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArtStatus",
                table: "Transaction",
                newName: "Status");
        }
    }
}
