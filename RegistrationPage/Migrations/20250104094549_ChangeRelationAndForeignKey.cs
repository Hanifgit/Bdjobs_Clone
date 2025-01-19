using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationPage.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationAndForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CreateAccounts_CreateAccountId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CreateAccounts_Countries_CountryId",
                table: "CreateAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CreateAccounts_CountryId",
                table: "CreateAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CreateAccountId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UpazilaId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CreateAccounts");

            migrationBuilder.RenameColumn(
                name: "CreateAccountId",
                table: "Addresses",
                newName: "CountryId");

            migrationBuilder.CreateTable(
                name: "CreateAccountAddress",
                columns: table => new
                {
                    CreateAccountId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateAccountAddress", x => new { x.CreateAccountId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_CreateAccountAddress_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreateAccountAddress_CreateAccounts_CreateAccountId",
                        column: x => x.CreateAccountId,
                        principalTable: "CreateAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UpazilaId",
                table: "Addresses",
                column: "UpazilaId");

            migrationBuilder.CreateIndex(
                name: "IX_CreateAccountAddress_AddressId",
                table: "CreateAccountAddress",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "CreateAccountAddress");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UpazilaId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Addresses",
                newName: "CreateAccountId");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CreateAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CreateAccounts_CountryId",
                table: "CreateAccounts",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreateAccountId",
                table: "Addresses",
                column: "CreateAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UpazilaId",
                table: "Addresses",
                column: "UpazilaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CreateAccounts_CreateAccountId",
                table: "Addresses",
                column: "CreateAccountId",
                principalTable: "CreateAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreateAccounts_Countries_CountryId",
                table: "CreateAccounts",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
