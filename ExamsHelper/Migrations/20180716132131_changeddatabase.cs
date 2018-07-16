using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExamsHelper.Migrations
{
    public partial class changeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_FacultiesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UniversId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Lections",
                newName: "UserLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultiesId",
                table: "Users",
                column: "FacultiesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversId",
                table: "Users",
                column: "UniversId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_FacultiesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UniversId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserLogin",
                table: "Lections",
                newName: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultiesId",
                table: "Users",
                column: "FacultiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversId",
                table: "Users",
                column: "UniversId");
        }
    }
}
