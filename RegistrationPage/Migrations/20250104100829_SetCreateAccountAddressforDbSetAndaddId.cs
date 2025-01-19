using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationPage.Migrations
{
    /// <inheritdoc />
    public partial class SetCreateAccountAddressforDbSetAndaddId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreateAccountAddress_Addresses_AddressId",
                table: "CreateAccountAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CreateAccountAddress_CreateAccounts_CreateAccountId",
                table: "CreateAccountAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreateAccountAddress",
                table: "CreateAccountAddress");

            migrationBuilder.RenameTable(
                name: "CreateAccountAddress",
                newName: "createAccountAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_CreateAccountAddress_AddressId",
                table: "createAccountAddresses",
                newName: "IX_createAccountAddresses_AddressId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "createAccountAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "createAccountAddresses");

            migrationBuilder.RenameTable(
                name: "createAccountAddresses",
                newName: "CreateAccountAddress");

            migrationBuilder.RenameIndex(
                name: "IX_createAccountAddresses_AddressId",
                table: "CreateAccountAddress",
                newName: "IX_CreateAccountAddress_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreateAccountAddress",
                table: "CreateAccountAddress",
                columns: new[] { "CreateAccountId", "AddressId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CreateAccountAddress_Addresses_AddressId",
                table: "CreateAccountAddress",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreateAccountAddress_CreateAccounts_CreateAccountId",
                table: "CreateAccountAddress",
                column: "CreateAccountId",
                principalTable: "CreateAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
