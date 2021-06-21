using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API2.Migrations
{
    public partial class fs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Person",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Person", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_University",
                columns: table => new
                {
                    Universityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_University", x => x.Universityid);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Acount",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Acount", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Acount_TB_M_Person_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Person",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Education",
                columns: table => new
                {
                    Educationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Universityid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Education", x => x.Educationid);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_M_University_Universityid",
                        column: x => x.Universityid,
                        principalTable: "TB_M_University",
                        principalColumn: "Universityid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_R_AcountRole",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_R_AcountRole", x => new { x.NIK, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TB_R_AcountRole_TB_M_Acount_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Acount",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_R_AcountRole_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_R_Profiling",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Educationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_R_Profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_R_Profiling_TB_M_Acount_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Acount",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_R_Profiling_TB_M_Education_Educationid",
                        column: x => x.Educationid,
                        principalTable: "TB_M_Education",
                        principalColumn: "Educationid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_Universityid",
                table: "TB_M_Education",
                column: "Universityid");

            migrationBuilder.CreateIndex(
                name: "IX_TB_R_AcountRole_RoleId",
                table: "TB_R_AcountRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_R_Profiling_Educationid",
                table: "TB_R_Profiling",
                column: "Educationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_R_AcountRole");

            migrationBuilder.DropTable(
                name: "TB_R_Profiling");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_M_Acount");

            migrationBuilder.DropTable(
                name: "TB_M_Education");

            migrationBuilder.DropTable(
                name: "TB_M_Person");

            migrationBuilder.DropTable(
                name: "TB_M_University");
        }
    }
}
