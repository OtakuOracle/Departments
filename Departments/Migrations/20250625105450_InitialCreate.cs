using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Departments.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "calend");

            migrationBuilder.CreateSequence(
                name: "employee_employeeid_seq",
                schema: "calend");

            migrationBuilder.CreateTable(
                name: "department",
                schema: "calend",
                columns: table => new
                {
                    departmentid = table.Column<int>(type: "integer", nullable: false),
                    departmentname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("department_pkey", x => x.departmentid);
                });

            migrationBuilder.CreateTable(
                name: "position",
                schema: "calend",
                columns: table => new
                {
                    positionid = table.Column<int>(type: "integer", nullable: false),
                    positionname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ismanager = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("position_pkey", x => x.positionid);
                });

            migrationBuilder.CreateTable(
                name: "department_subdivision",
                schema: "calend",
                columns: table => new
                {
                    subdivisionid = table.Column<int>(type: "integer", nullable: false),
                    departmentid = table.Column<int>(type: "integer", nullable: false),
                    subdivisionname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    headpositionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("department_subdivision_pkey", x => x.subdivisionid);
                    table.ForeignKey(
                        name: "department_subdivision_departmentid_fkey",
                        column: x => x.departmentid,
                        principalSchema: "calend",
                        principalTable: "department",
                        principalColumn: "departmentid");
                    table.ForeignKey(
                        name: "fk_head_position",
                        column: x => x.headpositionid,
                        principalSchema: "calend",
                        principalTable: "position",
                        principalColumn: "positionid");
                });

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "calend",
                columns: table => new
                {
                    employeeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personalnumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    middlename = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    mobiletel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    worktel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    office = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    positionid = table.Column<int>(type: "integer", nullable: false),
                    subdivisionid = table.Column<int>(type: "integer", nullable: true),
                    is_manager = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.employeeid);
                    table.ForeignKey(
                        name: "employee_subdivisionid_fkey",
                        column: x => x.subdivisionid,
                        principalSchema: "calend",
                        principalTable: "department_subdivision",
                        principalColumn: "subdivisionid");
                    table.ForeignKey(
                        name: "fk_position_id",
                        column: x => x.positionid,
                        principalSchema: "calend",
                        principalTable: "position",
                        principalColumn: "positionid");
                });

            migrationBuilder.CreateTable(
                name: "employee_relation",
                schema: "calend",
                columns: table => new
                {
                    relationid = table.Column<int>(type: "integer", nullable: false),
                    employeeid = table.Column<int>(type: "integer", nullable: true),
                    managerid = table.Column<int>(type: "integer", nullable: true),
                    assistantid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_relations_pkey", x => x.relationid);
                    table.ForeignKey(
                        name: "employee_relations_assistantid_fkey",
                        column: x => x.assistantid,
                        principalSchema: "calend",
                        principalTable: "employee",
                        principalColumn: "employeeid");
                    table.ForeignKey(
                        name: "employee_relations_employeeid_fkey",
                        column: x => x.employeeid,
                        principalSchema: "calend",
                        principalTable: "employee",
                        principalColumn: "employeeid");
                    table.ForeignKey(
                        name: "employee_relations_managerid_fkey",
                        column: x => x.managerid,
                        principalSchema: "calend",
                        principalTable: "employee",
                        principalColumn: "employeeid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_department_subdivision_departmentid",
                schema: "calend",
                table: "department_subdivision",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_department_subdivision_headpositionid",
                schema: "calend",
                table: "department_subdivision",
                column: "headpositionid");

            migrationBuilder.CreateIndex(
                name: "IX_employee_positionid",
                schema: "calend",
                table: "employee",
                column: "positionid");

            migrationBuilder.CreateIndex(
                name: "IX_employee_subdivisionid",
                schema: "calend",
                table: "employee",
                column: "subdivisionid");

            migrationBuilder.CreateIndex(
                name: "IX_employee_relation_assistantid",
                schema: "calend",
                table: "employee_relation",
                column: "assistantid");

            migrationBuilder.CreateIndex(
                name: "IX_employee_relation_employeeid",
                schema: "calend",
                table: "employee_relation",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_employee_relation_managerid",
                schema: "calend",
                table: "employee_relation",
                column: "managerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_relation",
                schema: "calend");

            migrationBuilder.DropTable(
                name: "employee",
                schema: "calend");

            migrationBuilder.DropTable(
                name: "department_subdivision",
                schema: "calend");

            migrationBuilder.DropTable(
                name: "department",
                schema: "calend");

            migrationBuilder.DropTable(
                name: "position",
                schema: "calend");

            migrationBuilder.DropSequence(
                name: "employee_employeeid_seq",
                schema: "calend");
        }
    }
}
