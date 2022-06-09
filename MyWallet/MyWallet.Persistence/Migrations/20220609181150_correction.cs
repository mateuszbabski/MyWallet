using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Persistence.Migrations
{
    public partial class correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Transactions",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "UserID");
        }
    }
}
