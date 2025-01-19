using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationPage.Migrations
{
    /// <inheritdoc />
    public partial class CreateAccountAndAddressEntityRelationchangeNewRelationOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "CreateAccountId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreateAccountId",
                table: "Addresses",
                column: "CreateAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CreateAccounts_CreateAccountId",
                table: "Addresses",
                column: "CreateAccountId",
                principalTable: "CreateAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CreateAccounts_CreateAccountId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CreateAccountId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreateAccountId",
                table: "Addresses");

           
                

           
        }
    }
}
