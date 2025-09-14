using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dinawin.Erp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixRemainingForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Users_ApprovedByUserId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Users_CreatedByUserId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePayments_Users_ApprovedByUserId",
                table: "SalePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePayments_Users_CreatedByUserId",
                table: "SalePayments");

            migrationBuilder.DropIndex(
                name: "IX_SalePayments_ApprovedByUserId",
                table: "SalePayments");

            migrationBuilder.DropIndex(
                name: "IX_SalePayments_CreatedByUserId",
                table: "SalePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_ApprovedByUserId",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_CreatedByUserId",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "SalePayments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "SalePayments");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "PurchasePayments");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_ApprovedBy",
                table: "SalePayments",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_CreatedBy",
                table: "SalePayments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_ApprovedBy",
                table: "PurchasePayments",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_CreatedBy",
                table: "PurchasePayments",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Users_ApprovedBy",
                table: "PurchasePayments",
                column: "ApprovedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Users_CreatedBy",
                table: "PurchasePayments",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePayments_Users_ApprovedBy",
                table: "SalePayments",
                column: "ApprovedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePayments_Users_CreatedBy",
                table: "SalePayments",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Users_ApprovedBy",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Users_CreatedBy",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePayments_Users_ApprovedBy",
                table: "SalePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePayments_Users_CreatedBy",
                table: "SalePayments");

            migrationBuilder.DropIndex(
                name: "IX_SalePayments_ApprovedBy",
                table: "SalePayments");

            migrationBuilder.DropIndex(
                name: "IX_SalePayments_CreatedBy",
                table: "SalePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_ApprovedBy",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_CreatedBy",
                table: "PurchasePayments");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedByUserId",
                table: "SalePayments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "SalePayments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedByUserId",
                table: "PurchasePayments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "PurchasePayments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_ApprovedByUserId",
                table: "SalePayments",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_CreatedByUserId",
                table: "SalePayments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_ApprovedByUserId",
                table: "PurchasePayments",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_CreatedByUserId",
                table: "PurchasePayments",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Users_ApprovedByUserId",
                table: "PurchasePayments",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Users_CreatedByUserId",
                table: "PurchasePayments",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePayments_Users_ApprovedByUserId",
                table: "SalePayments",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePayments_Users_CreatedByUserId",
                table: "SalePayments",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
