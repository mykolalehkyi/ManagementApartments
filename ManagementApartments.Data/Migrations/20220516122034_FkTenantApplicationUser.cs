using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApartments.Data.Migrations
{
    public partial class FkTenantApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utility_Apartment_ApartmentId",
                table: "Utility");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Utility",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tenant",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4d39a2e9-31a3-457c-a15b-372713573be6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6beff1ba-a99b-498d-b384-23002a51f2f4");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_ApplicationUserId",
                table: "Tenant",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_AspNetUsers_ApplicationUserId",
                table: "Tenant",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utility_Apartment_ApartmentId",
                table: "Utility",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_AspNetUsers_ApplicationUserId",
                table: "Tenant");

            migrationBuilder.DropForeignKey(
                name: "FK_Utility_Apartment_ApartmentId",
                table: "Utility");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_ApplicationUserId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tenant");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Utility",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Utility_Apartment_ApartmentId",
                table: "Utility",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
