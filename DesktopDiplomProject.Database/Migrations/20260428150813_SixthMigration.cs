using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesktopDiplomProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "regular" },
                    { 3, "guest" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Roles",
               keyColumn: "ID",
               keyValues: new object[] { 1, 2, 3 });
        }
    }
}
