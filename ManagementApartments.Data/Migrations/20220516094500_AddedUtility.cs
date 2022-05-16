using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApartments.Data.Migrations
{
    public partial class AddedUtility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a3f5bf35-f04c-4c08-b328-5eb17f3782e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9f06c3be-e671-452c-a205-5c4ac5b62b66");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4b8adeb8-9a55-48b0-8019-e12b8debe948");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "34018b7e-b608-4f67-bb11-6fd4a318f2a2");
        }
    }
}
