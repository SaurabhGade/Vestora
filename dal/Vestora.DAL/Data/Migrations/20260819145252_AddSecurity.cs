using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vestora.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SEC_SECURITY",
                columns: table => new
                {
                    SECURITY_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SYMBOL = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    COMPANY_NAME = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ISIN = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EXCHANGE = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    SECURITY_TYPE = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    SECTOR = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    INDUSTRY = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_BY = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFIED_BY = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEC_SECURITY", x => x.SECURITY_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SEC_SECURITY_SYMBOL_EXCHANGE",
                table: "SEC_SECURITY",
                columns: new[] { "SYMBOL", "EXCHANGE" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SEC_SECURITY");
        }
    }
}
