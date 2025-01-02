using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kon.BillingBash.Migrations
{
    /// <inheritdoc />
    public partial class V101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppBill_ConsumptionRecordId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "AppBillJoiners");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ConsumptionRecordId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ConsumptionRecordId",
                table: "AbpUsers");

            migrationBuilder.CreateTable(
                name: "AppBillJoiner",
                columns: table => new
                {
                    ConsumptionRecordId = table.Column<long>(type: "bigint", nullable: false),
                    JoinersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBillJoiner", x => new { x.ConsumptionRecordId, x.JoinersId });
                    table.ForeignKey(
                        name: "FK_AppBillJoiner_AbpUsers_JoinersId",
                        column: x => x.JoinersId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppBillJoiner_AppBill_ConsumptionRecordId",
                        column: x => x.ConsumptionRecordId,
                        principalTable: "AppBill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserGroupJoiner",
                columns: table => new
                {
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserGroupJoiner", x => new { x.UserGroupId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserGroupJoiner_AbpUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserGroupJoiner_AppUserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "AppUserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBillJoiner_JoinersId",
                table: "AppBillJoiner",
                column: "JoinersId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserGroupJoiner_UsersId",
                table: "AppUserGroupJoiner",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBillJoiner");

            migrationBuilder.DropTable(
                name: "AppUserGroupJoiner");

            migrationBuilder.DropTable(
                name: "AppUserGroup");

            migrationBuilder.AddColumn<long>(
                name: "ConsumptionRecordId",
                table: "AbpUsers",
                type: "bigint",
                nullable: true);

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
    }
}
