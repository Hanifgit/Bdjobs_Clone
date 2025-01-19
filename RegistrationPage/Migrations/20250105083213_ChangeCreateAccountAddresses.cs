using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationPage.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCreateAccountAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_createAccountAddresses_Addresses_AddressId",
                table: "createAccountAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_createAccountAddresses_CreateAccounts_CreateAccountId",
                table: "createAccountAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_createAccountAddresses",
                table: "createAccountAddresses");

            migrationBuilder.RenameTable(
                name: "createAccountAddresses",
                newName: "CreateAccountAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_createAccountAddresses_AddressId",
                table: "CreateAccountAddresses",
                newName: "IX_CreateAccountAddresses_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreateAccountAddresses",
                table: "CreateAccountAddresses",
                columns: new[] { "CreateAccountId", "AddressId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CreateAccountAddresses_Addresses_AddressId",
                table: "CreateAccountAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreateAccountAddresses_CreateAccounts_CreateAccountId",
                table: "CreateAccountAddresses",
                column: "CreateAccountId",
                principalTable: "CreateAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreateAccountAddresses_Addresses_AddressId",
                table: "CreateAccountAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CreateAccountAddresses_CreateAccounts_CreateAccountId",
                table: "CreateAccountAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreateAccountAddresses",
                table: "CreateAccountAddresses");

            migrationBuilder.RenameTable(
                name: "CreateAccountAddresses",
                newName: "createAccountAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_CreateAccountAddresses_AddressId",
                table: "createAccountAddresses",
                newName: "IX_createAccountAddresses_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_createAccountAddresses",
                table: "createAccountAddresses",
                columns: new[] { "CreateAccountId", "AddressId" });

            migrationBuilder.AddForeignKey(
                name: "FK_createAccountAddresses_Addresses_AddressId",
                table: "createAccountAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_createAccountAddresses_CreateAccounts_CreateAccountId",
                table: "createAccountAddresses",
                column: "CreateAccountId",
                principalTable: "CreateAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
