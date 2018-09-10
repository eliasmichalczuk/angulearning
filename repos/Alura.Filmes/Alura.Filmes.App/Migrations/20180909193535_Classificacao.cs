using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alura.Filmes.App.Migrations
{
    public partial class Classificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rating",
                table: "film",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_actor_first_name_last_name",
                table: "actor",
                columns: new[] { "first_name", "last_name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_actor_first_name_last_name",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "film");
        }
    }
}
