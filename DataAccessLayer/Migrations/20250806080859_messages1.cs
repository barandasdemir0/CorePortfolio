using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class messages1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_Messages_MessageID",
                table: "UserMessages");

            migrationBuilder.DropIndex(
                name: "IX_UserMessages_MessageID",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "MessageID",
                table: "UserMessages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageID",
                table: "UserMessages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_MessageID",
                table: "UserMessages",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_Messages_MessageID",
                table: "UserMessages",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "MessageID");
        }
    }
}
