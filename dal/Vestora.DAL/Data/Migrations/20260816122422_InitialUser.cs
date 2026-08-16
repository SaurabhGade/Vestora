using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vestora.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USR_USER",
                columns: table => new
                {
                    USER_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EMAIL = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PASSWORD_HASH = table.Column<string>(type: "text", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LAST_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DATE_OF_BIRTH = table.Column<DateOnly>(type: "date", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    EMAIL_VERIFIED = table.Column<bool>(type: "boolean", nullable: false),
                    PHONE_VERIFIED = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LAST_LOGIN_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_USER", x => x.USER_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USR_USER_EMAIL",
                table: "USR_USER",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USR_USER");
        }
    }
}
