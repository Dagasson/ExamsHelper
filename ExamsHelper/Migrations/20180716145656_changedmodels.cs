using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExamsHelper.Migrations
{
    public partial class changedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Lections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lections_UserId",
                table: "Lections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lections_Users_UserId",
                table: "Lections",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lections_Users_UserId",
                table: "Lections");

            migrationBuilder.DropIndex(
                name: "IX_Lections_UserId",
                table: "Lections");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lections");
        }
    }
}
