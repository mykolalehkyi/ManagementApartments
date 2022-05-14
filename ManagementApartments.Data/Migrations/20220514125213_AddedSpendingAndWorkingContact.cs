using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApartments.Data.Migrations
{
    public partial class AddedSpendingAndWorkingContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentPeriod_Apartment_ApartmentId",
                table: "RentPeriod");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "RentPeriod",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ApartmentSpending",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentSpending", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentSpending_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingContact", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentSpending_ApartmentId",
                table: "ApartmentSpending",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentPeriod_Apartment_ApartmentId",
                table: "RentPeriod",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentPeriod_Apartment_ApartmentId",
                table: "RentPeriod");

            migrationBuilder.DropTable(
                name: "ApartmentSpending");

            migrationBuilder.DropTable(
                name: "WorkingContact");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "RentPeriod",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d1f8ae52-e599-4418-a5f3-dafa45d3d390");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ada48457-a74e-4e2a-985e-143740fa1c7c");

            migrationBuilder.AddForeignKey(
                name: "FK_RentPeriod_Apartment_ApartmentId",
                table: "RentPeriod",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
