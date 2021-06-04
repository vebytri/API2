using Microsoft.EntityFrameworkCore.Migrations;

namespace API2.Migrations
{
    public partial class addRolerev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcountRoles_TB_M_Role_RoleId",
                table: "AcountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcountRoles",
                table: "AcountRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AcountRoles");

            migrationBuilder.RenameTable(
                name: "AcountRoles",
                newName: "TB_R_AcountRole");

            migrationBuilder.RenameIndex(
                name: "IX_AcountRoles_RoleId",
                table: "TB_R_AcountRole",
                newName: "IX_TB_R_AcountRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_R_AcountRole",
                table: "TB_R_AcountRole",
                columns: new[] { "NIK", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_R_AcountRole_TB_M_Acount_NIK",
                table: "TB_R_AcountRole",
                column: "NIK",
                principalTable: "TB_M_Acount",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_R_AcountRole_TB_M_Role_RoleId",
                table: "TB_R_AcountRole",
                column: "RoleId",
                principalTable: "TB_M_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_R_AcountRole_TB_M_Acount_NIK",
                table: "TB_R_AcountRole");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_R_AcountRole_TB_M_Role_RoleId",
                table: "TB_R_AcountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_R_AcountRole",
                table: "TB_R_AcountRole");

            migrationBuilder.RenameTable(
                name: "TB_R_AcountRole",
                newName: "AcountRoles");

            migrationBuilder.RenameIndex(
                name: "IX_TB_R_AcountRole_RoleId",
                table: "AcountRoles",
                newName: "IX_AcountRoles_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AcountRoles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcountRoles",
                table: "AcountRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AcountRoles_TB_M_Role_RoleId",
                table: "AcountRoles",
                column: "RoleId",
                principalTable: "TB_M_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
