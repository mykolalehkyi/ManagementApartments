using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApartments.Data.Migrations
{
    public partial class AddCommWorkingContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "WorkingContact",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingContact_AspNetUsers_ApplicationUserId1",
                table: "WorkingContact");

            migrationBuilder.DropIndex(
                name: "IX_WorkingContact_ApplicationUserId1",
                table: "WorkingContact");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "WorkingContact");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "WorkingContact");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d504c028-4fd9-48c2-94b7-04815d549349");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b2b46cb2-3008-4292-bd2f-9a6805ffdf1f");
        }
    }
}
