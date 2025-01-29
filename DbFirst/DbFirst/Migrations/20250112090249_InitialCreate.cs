using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbFirst.Migrations
{
    /// <inheritdoc />  
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptNo = table.Column<int>(type: "int", nullable: false),
                    DeptName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__0148CAAE5E4F950B", x => x.DeptNo);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeptNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Table__AF2D66D316FEF4FA", x => x.EmpNo);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false),
                    //This is commit
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeptNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__AF2D66D3616991BD", x => x.EmpNo);
                    table.ForeignKey(
                        name: "FK_Employees_ToTable",
                        column: x => x.DeptNo,
                        principalTable: "Departments",
                        principalColumn: "DeptNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptNo",
                table: "Employees",
                column: "DeptNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
