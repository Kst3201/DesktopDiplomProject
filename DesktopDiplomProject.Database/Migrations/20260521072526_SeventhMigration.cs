using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesktopDiplomProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionActions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionActions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionDomains",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionDomains", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    DomainPermissionID = table.Column<int>(type: "integer", nullable: false),
                    ActionPermissionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolePermissions_PermissionActions_ActionPermissionID",
                        column: x => x.ActionPermissionID,
                        principalTable: "PermissionActions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_PermissionDomains_DomainPermissionID",
                        column: x => x.DomainPermissionID,
                        principalTable: "PermissionDomains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionActions_Name",
                table: "PermissionActions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionDomains_Name",
                table: "PermissionDomains",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_ActionPermissionID",
                table: "RolePermissions",
                column: "ActionPermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_DomainPermissionID",
                table: "RolePermissions",
                column: "DomainPermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleID",
                table: "RolePermissions",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "PermissionActions");

            migrationBuilder.DropTable(
                name: "PermissionDomains");
        }
    }
}
