using Microsoft.EntityFrameworkCore.Migrations;

namespace API2.Migrations
{
    public partial class update_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Education_TB_M_University_UnivId",
                table: "TB_M_Education");

            migrationBuilder.AlterColumn<int>(
                name: "UnivId",
                table: "TB_M_Education",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Education_TB_M_University_UnivId",
                table: "TB_M_Education",
                column: "UnivId",
                principalTable: "TB_M_University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Education_TB_M_University_UnivId",
                table: "TB_M_Education");

            migrationBuilder.AlterColumn<int>(
                name: "UnivId",
                table: "TB_M_Education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Education_TB_M_University_UnivId",
                table: "TB_M_Education",
                column: "UnivId",
                principalTable: "TB_M_University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
