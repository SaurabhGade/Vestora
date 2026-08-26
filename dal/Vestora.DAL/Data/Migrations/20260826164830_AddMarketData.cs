using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vestora.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMarketData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SEC_MARKET_DATA",
                columns: table => new
                {
                    MARKET_DATA_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SECURITY_ID = table.Column<long>(type: "bigint", nullable: false),
                    TRADE_DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    OPEN_PRICE = table.Column<decimal>(type: "numeric(20,6)", precision: 20, scale: 6, nullable: true),
                    HIGH_PRICE = table.Column<decimal>(type: "numeric(20,6)", precision: 20, scale: 6, nullable: true),
                    LOW_PRICE = table.Column<decimal>(type: "numeric(20,6)", precision: 20, scale: 6, nullable: true),
                    CLOSE_PRICE = table.Column<decimal>(type: "numeric(20,6)", precision: 20, scale: 6, nullable: true),
                    ADJUSTED_CLOSE_PRICE = table.Column<decimal>(type: "numeric(20,6)", precision: 20, scale: 6, nullable: true),
                    PREVIOUS_CLOSE_PRICE = table.Column<decimal>(type: "numeric(20,6)", precision: 20, scale: 6, nullable: true),
                    VOLUME = table.Column<long>(type: "bigint", nullable: true),
                    VALUE_TRADED = table.Column<decimal>(type: "numeric(24,6)", precision: 24, scale: 6, nullable: true),
                    CHANGE_VALUE = table.Column<decimal>(type: "numeric(20,6)", precision: 20, scale: 6, nullable: true),
                    CHANGE_PERCENT = table.Column<decimal>(type: "numeric(12,6)", precision: 12, scale: 6, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEC_MARKET_DATA", x => x.MARKET_DATA_ID);
                    table.ForeignKey(
                        name: "FK_SEC_MARKET_DATA_SECURITY",
                        column: x => x.SECURITY_ID,
                        principalTable: "SEC_SECURITY",
                        principalColumn: "SECURITY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_SEC_MARKET_DATA_SECURITY_DATE",
                table: "SEC_MARKET_DATA",
                columns: new[] { "SECURITY_ID", "TRADE_DATE" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SEC_MARKET_DATA");
        }
    }
}
