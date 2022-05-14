using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApartments.Data.Migrations
{
    public partial class UpdateWorkingContactRefApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingContact_AspNetUsers_ApplicationUserId1",
                table: "WorkingContact");

            migrationBuilder.DropIndex(
                name: "IX_WorkingContact_ApplicationUserId1",
                table: "WorkingContact");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "WorkingContact");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "WorkingContact",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e661f56c-e53a-48ec-91e9-3e8268098914");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "89e40af4-d99c-4dbc-8a22-6199c9d0f109");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingContact_ApplicationUserId",
                table: "WorkingContact",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingContact_AspNetUsers_ApplicationUserId",
                table: "WorkingContact",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingContact_AspNetUsers_ApplicationUserId",
                table: "WorkingContact");

            migrationBuilder.DropIndex(
                name: "IX_WorkingContact_ApplicationUserId",
                table: "WorkingContact");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "WorkingContact",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "WorkingContact",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "41bea5d6-df91-4477-b084-48d2a53cd69d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e9381680-68fa-49c5-a807-63e407930695");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingContact_ApplicationUserId1",
                table: "WorkingContact",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingContact_AspNetUsers_ApplicationUserId1",
                table: "WorkingContact",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
