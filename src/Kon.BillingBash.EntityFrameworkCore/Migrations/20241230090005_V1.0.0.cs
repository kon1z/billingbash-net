using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kon.BillingBash.Migrations
{
    /// <inheritdoc />
    public partial class V100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConsumptionRecordId",
                table: "AbpUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppBill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConsumptionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ConsumptionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ConsumptionType = table.Column<string>(type: "text", nullable: true),
                    MerchantInformation = table.Column<string>(type: "text", nullable: true),
                    Product = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    ClassificationTag = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppBillJoiners",
                columns: table => new
                {
                    ConsumptionRecordId = table.Column<long>(type: "bigint", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBillJoiners", x => new { x.ConsumptionRecordId, x.IdentityUserId });
                    table.ForeignKey(
                        name: "FK_AppBillJoiners_AbpUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppBillJoiners_AppBill_ConsumptionRecordId",
                        column: x => x.ConsumptionRecordId,
                        principalTable: "AppBill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_ConsumptionRecordId",
                table: "AbpUsers",
                column: "ConsumptionRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBillJoiners_IdentityUserId",
                table: "AppBillJoiners",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppBill_ConsumptionRecordId",
                table: "AbpUsers",
                column: "ConsumptionRecordId",
                principalTable: "AppBill",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppBill_ConsumptionRecordId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "AppBillJoiners");

            migrationBuilder.DropTable(
                name: "AppBill");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ConsumptionRecordId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ConsumptionRecordId",
                table: "AbpUsers");
        }
    }
}
