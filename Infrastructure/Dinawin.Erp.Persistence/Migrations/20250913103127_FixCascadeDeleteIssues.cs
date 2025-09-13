using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dinawin.Erp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDeleteIssues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalPeriods_Users_ClosedByUserId",
                table: "AccFiscalPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalPeriods_Users_LockedByUserId",
                table: "AccFiscalPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalYears_Users_ClosedByUserId",
                table: "AccFiscalYears");

            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalYears_Users_LockedByUserId",
                table: "AccFiscalYears");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Users_ManagerUserId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_ApprovedByUserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_CreatedByUserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_LastModifiedByUserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingRuns_Users_ApprovedByUserId",
                table: "ClosingRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingRuns_Users_ExecutedByUserId",
                table: "ClosingRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingRuns_Users_ReversedByUserId",
                table: "ClosingRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgUnits_Users_ManagerUserId",
                table: "OrgUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionAudits_Users_UserId",
                table: "SessionAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Users_UserId",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrgUnits_Users_UserId",
                table: "UserOrgUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalPeriods_Users_ClosedByUserId",
                table: "AccFiscalPeriods",
                column: "ClosedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalPeriods_Users_LockedByUserId",
                table: "AccFiscalPeriods",
                column: "LockedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalYears_Users_ClosedByUserId",
                table: "AccFiscalYears",
                column: "ClosedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalYears_Users_LockedByUserId",
                table: "AccFiscalYears",
                column: "LockedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Users_ManagerUserId",
                table: "Branches",
                column: "ManagerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_ApprovedByUserId",
                table: "Budgets",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_CreatedByUserId",
                table: "Budgets",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_LastModifiedByUserId",
                table: "Budgets",
                column: "LastModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingRuns_Users_ApprovedByUserId",
                table: "ClosingRuns",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingRuns_Users_ExecutedByUserId",
                table: "ClosingRuns",
                column: "ExecutedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingRuns_Users_ReversedByUserId",
                table: "ClosingRuns",
                column: "ReversedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrgUnits_Users_ManagerUserId",
                table: "OrgUnits",
                column: "ManagerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAudits_Users_UserId",
                table: "SessionAudits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Users_UserId",
                table: "Technicians",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrgUnits_Users_UserId",
                table: "UserOrgUnits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalPeriods_Users_ClosedByUserId",
                table: "AccFiscalPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalPeriods_Users_LockedByUserId",
                table: "AccFiscalPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalYears_Users_ClosedByUserId",
                table: "AccFiscalYears");

            migrationBuilder.DropForeignKey(
                name: "FK_AccFiscalYears_Users_LockedByUserId",
                table: "AccFiscalYears");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Users_ManagerUserId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_ApprovedByUserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_CreatedByUserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_LastModifiedByUserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingRuns_Users_ApprovedByUserId",
                table: "ClosingRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingRuns_Users_ExecutedByUserId",
                table: "ClosingRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingRuns_Users_ReversedByUserId",
                table: "ClosingRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgUnits_Users_ManagerUserId",
                table: "OrgUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionAudits_Users_UserId",
                table: "SessionAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Users_UserId",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrgUnits_Users_UserId",
                table: "UserOrgUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalPeriods_Users_ClosedByUserId",
                table: "AccFiscalPeriods",
                column: "ClosedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalPeriods_Users_LockedByUserId",
                table: "AccFiscalPeriods",
                column: "LockedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalYears_Users_ClosedByUserId",
                table: "AccFiscalYears",
                column: "ClosedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AccFiscalYears_Users_LockedByUserId",
                table: "AccFiscalYears",
                column: "LockedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Users_ManagerUserId",
                table: "Branches",
                column: "ManagerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_ApprovedByUserId",
                table: "Budgets",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_CreatedByUserId",
                table: "Budgets",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_LastModifiedByUserId",
                table: "Budgets",
                column: "LastModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingRuns_Users_ApprovedByUserId",
                table: "ClosingRuns",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingRuns_Users_ExecutedByUserId",
                table: "ClosingRuns",
                column: "ExecutedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingRuns_Users_ReversedByUserId",
                table: "ClosingRuns",
                column: "ReversedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OrgUnits_Users_ManagerUserId",
                table: "OrgUnits",
                column: "ManagerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAudits_Users_UserId",
                table: "SessionAudits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Users_UserId",
                table: "Technicians",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrgUnits_Users_UserId",
                table: "UserOrgUnits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
