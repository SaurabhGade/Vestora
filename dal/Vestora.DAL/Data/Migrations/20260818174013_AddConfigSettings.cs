using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vestora.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COM_CONFIGSETTINGS",
                columns: table => new
                {
                    CONFIG_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CONFIG_KEY = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CONFIG_VALUE = table.Column<string>(type: "text", nullable: true),
                    CONFIG_TYPE = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_BY = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFIED_BY = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_CONFIGSETTINGS", x => x.CONFIG_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COM_CONFIGSETTINGS_CONFIG_KEY",
                table: "COM_CONFIGSETTINGS",
                column: "CONFIG_KEY",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COM_CONFIGSETTINGS");
        }
    }
}
