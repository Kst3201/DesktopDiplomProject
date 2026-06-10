using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesktopDiplomProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class TenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PCPresets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CPUCoeff = table.Column<double>(type: "double precision", nullable: false),
                    DriveCoeff = table.Column<double>(type: "double precision", nullable: false),
                    MotherboardCoeff = table.Column<double>(type: "double precision", nullable: false),
                    RAMCoeff = table.Column<double>(type: "double precision", nullable: false),
                    VideoCardCoeff = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCPresets", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCPresets_Name",
                table: "PCPresets",
                column: "Name",
                unique: true);



            migrationBuilder.InsertData(
                table: "PCPresets",
                columns: new[] { "ID", "Name", "CPUCoeff", "DriveCoeff", "MotherboardCoeff", "RAMCoeff", "VideoCardCoeff" },
                values: new object[,]
                {
                    { 1, "Домашний", 0.7, 0.6, 0.7, 0.6, 0.7 },
                    { 2, "Игровой", 0.75, 0.55, 0.6, 1, 0.8},
                    { 3, "Оффисный", 0.6, 0.6, 0.8, 0.2, 0.7 },
                    { 4, "Графический дизайн", 0.95, 0.65, 0.85, 0.9, 1 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DeleteData(
                table: "PCPresets",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3, 4 });

            migrationBuilder.DropTable(
                name: "PCPresets");
        }
    }
}
