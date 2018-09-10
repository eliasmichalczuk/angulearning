using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alura.Filmes.App.Migrations
{
    public partial class IndiceAtorUltimoNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_actor_last_name",
                table: "actor",
                newName: "idx_actor_last_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "idx_actor_last_name",
                table: "actor",
                newName: "IX_actor_last_name");
        }
    }
}
