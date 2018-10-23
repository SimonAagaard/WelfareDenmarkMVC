using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WelfareDenmarkMVC.Migrations
{
    public partial class TableChecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChecklistViewModel",
                table: "ChecklistViewModel");

            migrationBuilder.RenameTable(
                name: "ChecklistViewModel",
                newName: "Checklists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists");

            migrationBuilder.RenameTable(
                name: "Checklists",
                newName: "ChecklistViewModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChecklistViewModel",
                table: "ChecklistViewModel",
                column: "Id");
        }
    }
}
