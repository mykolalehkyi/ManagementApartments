using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApartments.Data.Migrations
{
    public partial class TenantsRentPeriodMulti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_RentPeriod_RentPeriodId",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_RentPeriodId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "RentPeriodId",
                table: "Tenant");

            migrationBuilder.CreateTable(
                name: "RentPeriodTenant",
                columns: table => new
                {
                    RentPeriodId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPeriodTenant", x => new { x.RentPeriodId, x.TenantId });
                    table.ForeignKey(
                        name: "FK_RentPeriodTenant_RentPeriod_RentPeriodId",
                        column: x => x.RentPeriodId,
                        principalTable: "RentPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentPeriodTenant_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RentPeriodTenant_TenantId",
                table: "RentPeriodTenant",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentPeriodTenant");

            migrationBuilder.AddColumn<int>(
                name: "RentPeriodId",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2acd5995-642a-421f-b1b7-e29aa1d38119");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "12868913-8b45-492e-80c5-4df2975732fc");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_RentPeriodId",
                table: "Tenant",
                column: "RentPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_RentPeriod_RentPeriodId",
                table: "Tenant",
                column: "RentPeriodId",
                principalTable: "RentPeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
