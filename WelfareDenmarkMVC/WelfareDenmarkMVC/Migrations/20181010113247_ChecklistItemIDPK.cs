using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WelfareDenmarkMVC.Migrations
{
    public partial class ChecklistItemIDPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChecklistViewModel",
                table: "ChecklistViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ChecklistViewModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ChecklistViewModel",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChecklistViewModel",
                table: "ChecklistViewModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChecklistViewModel",
                table: "ChecklistViewModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ChecklistViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ChecklistViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChecklistViewModel",
                table: "ChecklistViewModel",
                column: "Email");
        }
    }
}
