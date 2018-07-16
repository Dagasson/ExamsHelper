using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExamsHelper.Migrations
{
    public partial class tryFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lections_Users_Userid",
                table: "Lections");

            migrationBuilder.DropIndex(
                name: "IX_Lections_Userid",
                table: "Lections");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Lections");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Lections");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Lections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Lections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lections_Userid",
                table: "Lections",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Lections_Users_Userid",
                table: "Lections",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
