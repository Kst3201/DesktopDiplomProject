using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesktopDiplomProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPUBaseFrequencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUBaseFrequencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CPUCoreCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoreCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CPUPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUPrices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CPUThreadsCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUThreadsCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DriveCapacities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveCapacities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DriveConnectionInterfaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveConnectionInterfaces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DriveDataTransferSpeeds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveDataTransferSpeeds", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DrivePrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivePrices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GPUFrequencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUFrequencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GPURasterizationBlocksCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPURasterizationBlocksCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GPURTCoresCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPURTCoresCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GPUTensorCoresCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUTensorCoresCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GPUTexturesBlocksCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUTexturesBlocksCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GPUUniversalProcessorsCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUUniversalProcessorsCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBCountM2Slots",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBCountM2Slots", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBCountPCIEX16Slots",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBCountPCIEX16Slots", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBCountSATASlots",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBCountSATASlots", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBPrices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBRAMFrequecies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBRAMFrequecies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBRAMSlotsCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBRAMSlotsCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBRAMValues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBRAMValues", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBSizes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBSizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PCIEInterfaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCIEInterfaces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RAMFrequencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMFrequencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RAMModulesCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMModulesCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RAMPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMPrices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RAMSingleModuleCapacities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMSingleModuleCapacities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RAMTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sockets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sockets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VCMemoryFrequencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VCMemoryFrequencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VCMonitorsCounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VCMonitorsCounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VCPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VCPrices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VCThroughputCapacities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VCThroughputCapacities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VCVideoMemoryCapacities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ScoreOne = table.Column<double>(type: "double precision", nullable: false),
                    ScoreTwo = table.Column<double>(type: "double precision", nullable: false),
                    ScoreThree = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFour = table.Column<double>(type: "double precision", nullable: false),
                    ScoreFive = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VCVideoMemoryCapacities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    CapacityID = table.Column<int>(type: "integer", nullable: false),
                    SpeedDataTransferID = table.Column<int>(type: "integer", nullable: false),
                    ConnectorInterfaceID = table.Column<int>(type: "integer", nullable: false),
                    PriceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drives_DriveCapacities_CapacityID",
                        column: x => x.CapacityID,
                        principalTable: "DriveCapacities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drives_DriveConnectionInterfaces_ConnectorInterfaceID",
                        column: x => x.ConnectorInterfaceID,
                        principalTable: "DriveConnectionInterfaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drives_DriveDataTransferSpeeds_SpeedDataTransferID",
                        column: x => x.SpeedDataTransferID,
                        principalTable: "DriveDataTransferSpeeds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drives_DrivePrices_PriceID",
                        column: x => x.PriceID,
                        principalTable: "DrivePrices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    BaseFrequencyID = table.Column<int>(type: "integer", nullable: false),
                    CountUniversalProcessorsID = table.Column<int>(type: "integer", nullable: false),
                    CountTexturerBlocksID = table.Column<int>(type: "integer", nullable: false),
                    CountRasterizationBlocksID = table.Column<int>(type: "integer", nullable: false),
                    CountRTCoresID = table.Column<int>(type: "integer", nullable: false),
                    CountTensorCoresID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GPUs_GPUFrequencies_BaseFrequencyID",
                        column: x => x.BaseFrequencyID,
                        principalTable: "GPUFrequencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPUs_GPURTCoresCounties_CountRTCoresID",
                        column: x => x.CountRTCoresID,
                        principalTable: "GPURTCoresCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPUs_GPURasterizationBlocksCounties_CountRasterizationBlock~",
                        column: x => x.CountRasterizationBlocksID,
                        principalTable: "GPURasterizationBlocksCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPUs_GPUTensorCoresCounties_CountTensorCoresID",
                        column: x => x.CountTensorCoresID,
                        principalTable: "GPUTensorCoresCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPUs_GPUTexturesBlocksCounties_CountTexturerBlocksID",
                        column: x => x.CountTexturerBlocksID,
                        principalTable: "GPUTexturesBlocksCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPUs_GPUUniversalProcessorsCounties_CountUniversalProcessor~",
                        column: x => x.CountUniversalProcessorsID,
                        principalTable: "GPUUniversalProcessorsCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RAMs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    RAMTypeID = table.Column<int>(type: "integer", nullable: false),
                    SingleModuleCapacityID = table.Column<int>(type: "integer", nullable: false),
                    CountModulesID = table.Column<int>(type: "integer", nullable: false),
                    FrequencyID = table.Column<int>(type: "integer", nullable: false),
                    PriceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RAMs_RAMFrequencies_FrequencyID",
                        column: x => x.FrequencyID,
                        principalTable: "RAMFrequencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAMs_RAMModulesCounties_CountModulesID",
                        column: x => x.CountModulesID,
                        principalTable: "RAMModulesCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAMs_RAMPrices_PriceID",
                        column: x => x.PriceID,
                        principalTable: "RAMPrices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAMs_RAMSingleModuleCapacities_SingleModuleCapacityID",
                        column: x => x.SingleModuleCapacityID,
                        principalTable: "RAMSingleModuleCapacities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAMs_RAMTypes_RAMTypeID",
                        column: x => x.RAMTypeID,
                        principalTable: "RAMTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    RoleID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    SocketID = table.Column<int>(type: "integer", nullable: false),
                    CountCoresID = table.Column<int>(type: "integer", nullable: false),
                    CountThreadsID = table.Column<int>(type: "integer", nullable: false),
                    BaseFrequencyID = table.Column<int>(type: "integer", nullable: false),
                    RAMTypeID = table.Column<int>(type: "integer", nullable: false),
                    PriceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CPUs_CPUBaseFrequencies_BaseFrequencyID",
                        column: x => x.BaseFrequencyID,
                        principalTable: "CPUBaseFrequencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUs_CPUCoreCounties_CountCoresID",
                        column: x => x.CountCoresID,
                        principalTable: "CPUCoreCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUs_CPUPrices_PriceID",
                        column: x => x.PriceID,
                        principalTable: "CPUPrices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUs_CPUThreadsCounties_CountThreadsID",
                        column: x => x.CountThreadsID,
                        principalTable: "CPUThreadsCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUs_RAMTypes_RAMTypeID",
                        column: x => x.RAMTypeID,
                        principalTable: "RAMTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUs_Sockets_SocketID",
                        column: x => x.SocketID,
                        principalTable: "Sockets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    SizeID = table.Column<int>(type: "integer", nullable: false),
                    SocketID = table.Column<int>(type: "integer", nullable: false),
                    RAMTypeID = table.Column<int>(type: "integer", nullable: false),
                    RAMCountSlotsID = table.Column<int>(type: "integer", nullable: false),
                    MaxRAMValueID = table.Column<int>(type: "integer", nullable: false),
                    MaxRAMFrequencyID = table.Column<int>(type: "integer", nullable: false),
                    PCIEInterfaceID = table.Column<int>(type: "integer", nullable: false),
                    CountPCIEX16SlotsID = table.Column<int>(type: "integer", nullable: false),
                    CountM2SlotsID = table.Column<int>(type: "integer", nullable: false),
                    CountSATASlotsID = table.Column<int>(type: "integer", nullable: false),
                    PriceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBCountM2Slots_CountM2SlotsID",
                        column: x => x.CountM2SlotsID,
                        principalTable: "MBCountM2Slots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBCountPCIEX16Slots_CountPCIEX16SlotsID",
                        column: x => x.CountPCIEX16SlotsID,
                        principalTable: "MBCountPCIEX16Slots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBCountSATASlots_CountSATASlotsID",
                        column: x => x.CountSATASlotsID,
                        principalTable: "MBCountSATASlots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBPrices_PriceID",
                        column: x => x.PriceID,
                        principalTable: "MBPrices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBRAMFrequecies_MaxRAMFrequencyID",
                        column: x => x.MaxRAMFrequencyID,
                        principalTable: "MBRAMFrequecies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBRAMSlotsCounties_RAMCountSlotsID",
                        column: x => x.RAMCountSlotsID,
                        principalTable: "MBRAMSlotsCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBRAMValues_MaxRAMValueID",
                        column: x => x.MaxRAMValueID,
                        principalTable: "MBRAMValues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_MBSizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "MBSizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_PCIEInterfaces_PCIEInterfaceID",
                        column: x => x.PCIEInterfaceID,
                        principalTable: "PCIEInterfaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_RAMTypes_RAMTypeID",
                        column: x => x.RAMTypeID,
                        principalTable: "RAMTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_Sockets_SocketID",
                        column: x => x.SocketID,
                        principalTable: "Sockets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    GPUID = table.Column<int>(type: "integer", nullable: false),
                    PCIEInterfaceID = table.Column<int>(type: "integer", nullable: false),
                    CountPCIELines = table.Column<int>(type: "integer", nullable: false),
                    RecommendedBlockPower = table.Column<int>(type: "integer", nullable: false),
                    CountPinsAdditionalPower = table.Column<int>(type: "integer", nullable: false),
                    CapacityVideoMemoryID = table.Column<int>(type: "integer", nullable: false),
                    MaxThroughputCapacityID = table.Column<int>(type: "integer", nullable: false),
                    MemoryFrequencyID = table.Column<int>(type: "integer", nullable: false),
                    CountMonitorsID = table.Column<int>(type: "integer", nullable: false),
                    PriceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VideoCards_GPUs_GPUID",
                        column: x => x.GPUID,
                        principalTable: "GPUs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCards_PCIEInterfaces_PCIEInterfaceID",
                        column: x => x.PCIEInterfaceID,
                        principalTable: "PCIEInterfaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCards_VCMemoryFrequencies_MemoryFrequencyID",
                        column: x => x.MemoryFrequencyID,
                        principalTable: "VCMemoryFrequencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCards_VCMonitorsCounties_CountMonitorsID",
                        column: x => x.CountMonitorsID,
                        principalTable: "VCMonitorsCounties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCards_VCPrices_PriceID",
                        column: x => x.PriceID,
                        principalTable: "VCPrices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCards_VCThroughputCapacities_MaxThroughputCapacityID",
                        column: x => x.MaxThroughputCapacityID,
                        principalTable: "VCThroughputCapacities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCards_VCVideoMemoryCapacities_CapacityVideoMemoryID",
                        column: x => x.CapacityVideoMemoryID,
                        principalTable: "VCVideoMemoryCapacities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CPUID = table.Column<int>(type: "integer", nullable: false),
                    MotherboardID = table.Column<int>(type: "integer", nullable: false),
                    DriveID = table.Column<int>(type: "integer", nullable: false),
                    RAMID = table.Column<int>(type: "integer", nullable: false),
                    VideoCardID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PCs_CPUs_CPUID",
                        column: x => x.CPUID,
                        principalTable: "CPUs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCs_Drives_DriveID",
                        column: x => x.DriveID,
                        principalTable: "Drives",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCs_Motherboards_MotherboardID",
                        column: x => x.MotherboardID,
                        principalTable: "Motherboards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCs_RAMs_RAMID",
                        column: x => x.RAMID,
                        principalTable: "RAMs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCs_VideoCards_VideoCardID",
                        column: x => x.VideoCardID,
                        principalTable: "VideoCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_BaseFrequencyID",
                table: "CPUs",
                column: "BaseFrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_CountCoresID",
                table: "CPUs",
                column: "CountCoresID");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_CountThreadsID",
                table: "CPUs",
                column: "CountThreadsID");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_PriceID",
                table: "CPUs",
                column: "PriceID");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_RAMTypeID",
                table: "CPUs",
                column: "RAMTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_SocketID",
                table: "CPUs",
                column: "SocketID");

            migrationBuilder.CreateIndex(
                name: "IX_DriveConnectionInterfaces_Name",
                table: "DriveConnectionInterfaces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drives_CapacityID",
                table: "Drives",
                column: "CapacityID");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_ConnectorInterfaceID",
                table: "Drives",
                column: "ConnectorInterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_PriceID",
                table: "Drives",
                column: "PriceID");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_SpeedDataTransferID",
                table: "Drives",
                column: "SpeedDataTransferID");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_BaseFrequencyID",
                table: "GPUs",
                column: "BaseFrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_CountRasterizationBlocksID",
                table: "GPUs",
                column: "CountRasterizationBlocksID");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_CountRTCoresID",
                table: "GPUs",
                column: "CountRTCoresID");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_CountTensorCoresID",
                table: "GPUs",
                column: "CountTensorCoresID");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_CountTexturerBlocksID",
                table: "GPUs",
                column: "CountTexturerBlocksID");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_CountUniversalProcessorsID",
                table: "GPUs",
                column: "CountUniversalProcessorsID");

            migrationBuilder.CreateIndex(
                name: "IX_MBSizes_Name",
                table: "MBSizes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_CountM2SlotsID",
                table: "Motherboards",
                column: "CountM2SlotsID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_CountPCIEX16SlotsID",
                table: "Motherboards",
                column: "CountPCIEX16SlotsID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_CountSATASlotsID",
                table: "Motherboards",
                column: "CountSATASlotsID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_MaxRAMFrequencyID",
                table: "Motherboards",
                column: "MaxRAMFrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_MaxRAMValueID",
                table: "Motherboards",
                column: "MaxRAMValueID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_PCIEInterfaceID",
                table: "Motherboards",
                column: "PCIEInterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_PriceID",
                table: "Motherboards",
                column: "PriceID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_RAMCountSlotsID",
                table: "Motherboards",
                column: "RAMCountSlotsID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_RAMTypeID",
                table: "Motherboards",
                column: "RAMTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SizeID",
                table: "Motherboards",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SocketID",
                table: "Motherboards",
                column: "SocketID");

            migrationBuilder.CreateIndex(
                name: "IX_PCIEInterfaces_Name",
                table: "PCIEInterfaces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PCs_CPUID",
                table: "PCs",
                column: "CPUID");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_DriveID",
                table: "PCs",
                column: "DriveID");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_MotherboardID",
                table: "PCs",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_RAMID",
                table: "PCs",
                column: "RAMID");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_UserID",
                table: "PCs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_VideoCardID",
                table: "PCs",
                column: "VideoCardID");

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_CountModulesID",
                table: "RAMs",
                column: "CountModulesID");

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_FrequencyID",
                table: "RAMs",
                column: "FrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_PriceID",
                table: "RAMs",
                column: "PriceID");

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_RAMTypeID",
                table: "RAMs",
                column: "RAMTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_SingleModuleCapacityID",
                table: "RAMs",
                column: "SingleModuleCapacityID");

            migrationBuilder.CreateIndex(
                name: "IX_RAMTypes_Name",
                table: "RAMTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sockets_Name",
                table: "Sockets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_CapacityVideoMemoryID",
                table: "VideoCards",
                column: "CapacityVideoMemoryID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_CountMonitorsID",
                table: "VideoCards",
                column: "CountMonitorsID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_GPUID",
                table: "VideoCards",
                column: "GPUID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_MaxThroughputCapacityID",
                table: "VideoCards",
                column: "MaxThroughputCapacityID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_MemoryFrequencyID",
                table: "VideoCards",
                column: "MemoryFrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_PCIEInterfaceID",
                table: "VideoCards",
                column: "PCIEInterfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_PriceID",
                table: "VideoCards",
                column: "PriceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCs");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "RAMs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VideoCards");

            migrationBuilder.DropTable(
                name: "CPUBaseFrequencies");

            migrationBuilder.DropTable(
                name: "CPUCoreCounties");

            migrationBuilder.DropTable(
                name: "CPUPrices");

            migrationBuilder.DropTable(
                name: "CPUThreadsCounties");

            migrationBuilder.DropTable(
                name: "DriveCapacities");

            migrationBuilder.DropTable(
                name: "DriveConnectionInterfaces");

            migrationBuilder.DropTable(
                name: "DriveDataTransferSpeeds");

            migrationBuilder.DropTable(
                name: "DrivePrices");

            migrationBuilder.DropTable(
                name: "MBCountM2Slots");

            migrationBuilder.DropTable(
                name: "MBCountPCIEX16Slots");

            migrationBuilder.DropTable(
                name: "MBCountSATASlots");

            migrationBuilder.DropTable(
                name: "MBPrices");

            migrationBuilder.DropTable(
                name: "MBRAMFrequecies");

            migrationBuilder.DropTable(
                name: "MBRAMSlotsCounties");

            migrationBuilder.DropTable(
                name: "MBRAMValues");

            migrationBuilder.DropTable(
                name: "MBSizes");

            migrationBuilder.DropTable(
                name: "Sockets");

            migrationBuilder.DropTable(
                name: "RAMFrequencies");

            migrationBuilder.DropTable(
                name: "RAMModulesCounties");

            migrationBuilder.DropTable(
                name: "RAMPrices");

            migrationBuilder.DropTable(
                name: "RAMSingleModuleCapacities");

            migrationBuilder.DropTable(
                name: "RAMTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "PCIEInterfaces");

            migrationBuilder.DropTable(
                name: "VCMemoryFrequencies");

            migrationBuilder.DropTable(
                name: "VCMonitorsCounties");

            migrationBuilder.DropTable(
                name: "VCPrices");

            migrationBuilder.DropTable(
                name: "VCThroughputCapacities");

            migrationBuilder.DropTable(
                name: "VCVideoMemoryCapacities");

            migrationBuilder.DropTable(
                name: "GPUFrequencies");

            migrationBuilder.DropTable(
                name: "GPURTCoresCounties");

            migrationBuilder.DropTable(
                name: "GPURasterizationBlocksCounties");

            migrationBuilder.DropTable(
                name: "GPUTensorCoresCounties");

            migrationBuilder.DropTable(
                name: "GPUTexturesBlocksCounties");

            migrationBuilder.DropTable(
                name: "GPUUniversalProcessorsCounties");
        }
    }
}
