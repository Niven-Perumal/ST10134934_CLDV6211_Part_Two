using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10134934_CLDV6211_Part_Two.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transaction");
        }
    }
}
