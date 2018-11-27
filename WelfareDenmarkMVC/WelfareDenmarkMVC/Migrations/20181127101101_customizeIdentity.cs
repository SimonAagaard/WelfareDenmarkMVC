using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WelfareDenmarkMVC.Migrations
{
    public partial class customizeIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Checklists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ApplicationUserId",
                table: "Checklists",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_AspNetUsers_ApplicationUserId",
                table: "Checklists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_AspNetUsers_ApplicationUserId",
                table: "Checklists");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_ApplicationUserId",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Checklists");
        }
    }
}
