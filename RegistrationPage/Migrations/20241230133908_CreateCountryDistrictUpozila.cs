using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationPage.Migrations
{
    /// <inheritdoc />
    public partial class CreateCountryDistrictUpozila : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Upozilas_UpozilaId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Upozilas");

            migrationBuilder.RenameColumn(
                name: "UpozilaId",
                table: "Addresses",
                newName: "UpazilaId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UpozilaId",
                table: "Addresses",
                newName: "IX_Addresses_UpazilaId");

            migrationBuilder.CreateTable(
                name: "Upazilas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazilas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upazilas_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Upazilas_DistrictId",
                table: "Upazilas",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Upazilas_UpazilaId",
                table: "Addresses",
                column: "UpazilaId",
                principalTable: "Upazilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Upazilas_UpazilaId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Upazilas");

            migrationBuilder.RenameColumn(
                name: "UpazilaId",
                table: "Addresses",
                newName: "UpozilaId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UpazilaId",
                table: "Addresses",
                newName: "IX_Addresses_UpozilaId");

            migrationBuilder.CreateTable(
                name: "Upozilas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upozilas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upozilas_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Upozilas_DistrictId",
                table: "Upozilas",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Upozilas_UpozilaId",
                table: "Addresses",
                column: "UpozilaId",
                principalTable: "Upozilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
