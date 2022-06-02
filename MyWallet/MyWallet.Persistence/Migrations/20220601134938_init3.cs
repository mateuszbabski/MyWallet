using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Persistence.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_UserID",
                table: "Budgets");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Budgets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_UserID",
                table: "Budgets",
                newName: "IX_Budgets_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Budgets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_UserId",
                table: "Budgets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_UserId",
                table: "Budgets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Budgets",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                newName: "IX_Budgets_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Budgets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_UserID",
                table: "Budgets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
