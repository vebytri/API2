using Microsoft.EntityFrameworkCore.Migrations;

namespace API2.Migrations
{
    public partial class person_db_change_coloum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "TB_M_Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "TB_M_Person",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
