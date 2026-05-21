using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesktopDiplomProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class EighthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_RoleID",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_DomainPermissionID",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_ActionPermissionID",
                table: "RolePermissions");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_Role_DomainPermission_ActionPermission",
                table: "RolePermissions",
                columns: new[] { "RoleID", "DomainPermissionID", "ActionPermissionID" },
                unique: true);

            migrationBuilder.InsertData(
                table: "PermissionActions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Read" },
                    { 2, "Write" },
                    { 3, "Add" },
                    { 4, "Remove" },
                    { 5, "Update" }
                });

            migrationBuilder.InsertData(
                table: "PermissionDomains",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Users" },
                    { 2, "PCComponents" },
                    { 3, "PCHistory" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "ID", "RoleID", "DomainPermissionID", "ActionPermissionID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 1, 2, 1 },
                    { 4, 1, 2, 2 },
                    { 5, 1, 3, 1 },
                    { 6, 1, 3, 2 },
                    { 7, 2, 2, 1 },
                    { 8, 2, 3, 1 },
                    { 9, 3, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_Role_DomainPermission_ActionPermission",
                table: "RolePermissions");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleID",
                table: "RolePermissions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_DomainPermissionID",
                table: "RolePermissions",
                column: "DomainPermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_ActionPermissionID",
                table: "RolePermissions",
                column: "ActionPermissionID");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            migrationBuilder.DeleteData(
                table: "PermissionDomains",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "PermissionActions",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
