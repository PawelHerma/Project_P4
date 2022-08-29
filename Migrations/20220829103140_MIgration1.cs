using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_P4.Migrations
{
    public partial class MIgration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpGroup",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExpGroup__149AF30A2E244628", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemberBudget = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Expence",
                columns: table => new
                {
                    ExpenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    ExpenceDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpenceCost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expence", x => x.ExpenceID);
                    table.ForeignKey(
                        name: "ref2",
                        column: x => x.GroupID,
                        principalTable: "ExpGroup",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "ref3",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    IncomeDate = table.Column<DateTime>(type: "date", nullable: false),
                    IncomeCost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "ref1",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expence_GroupID",
                table: "Expence",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Expence_MemberID",
                table: "Expence",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "UQ__ExpGroup__6EFCD434E207C59C",
                table: "ExpGroup",
                column: "GroupName",
                unique: true,
                filter: "[GroupName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Income_MemberID",
                table: "Income",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "UQ__Member__BE50FDEF485273A9",
                table: "Member",
                column: "MemberName",
                unique: true,
                filter: "[MemberName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expence");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "ExpGroup");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
