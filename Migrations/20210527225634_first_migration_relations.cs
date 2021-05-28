using Microsoft.EntityFrameworkCore.Migrations;

namespace API2.Migrations
{
    public partial class first_migration_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Acoount",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Acoount", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Acoount_TB_M_Person_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Person",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_University",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_University", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University_id = table.Column<int>(type: "int", nullable: false),
                    UnivId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_M_University_UnivId",
                        column: x => x.UnivId,
                        principalTable: "TB_M_University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_R_Profiling",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Education_id = table.Column<int>(type: "int", nullable: false),
                    EduId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_R_Profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_R_Profiling_TB_M_Acoount_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Acoount",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_R_Profiling_TB_M_Education_EduId",
                        column: x => x.EduId,
                        principalTable: "TB_M_Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_UnivId",
                table: "TB_M_Education",
                column: "UnivId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_R_Profiling_EduId",
                table: "TB_R_Profiling",
                column: "EduId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_R_Profiling");

            migrationBuilder.DropTable(
                name: "TB_M_Acoount");

            migrationBuilder.DropTable(
                name: "TB_M_Education");

            migrationBuilder.DropTable(
                name: "TB_M_University");
        }
    }
}
