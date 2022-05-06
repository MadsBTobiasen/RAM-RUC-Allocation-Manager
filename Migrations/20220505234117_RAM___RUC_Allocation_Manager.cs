using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RAM___RUC_Allocation_Manager.Migrations
{
    public partial class RAM___RUC_Allocation_Manager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinuteWorth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCommittees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    IsGroupLeader = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiringCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleToBeAssessed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringCommittees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssistantProfessorSupervisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    AssistantProfessorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistantProfessorSupervisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistantProfessorSupervisions_Employees_AssistantProfessorId",
                        column: x => x.AssistantProfessorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssistantProfessorSupervisions_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LectureAmount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCustomCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomCommitteeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCustomCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCustomCommittees_CustomCommittees_CustomCommitteeId",
                        column: x => x.CustomCommitteeId,
                        principalTable: "CustomCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCustomCommittees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupFacilitationTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilitatorId = table.Column<int>(type: "int", nullable: true),
                    DaysSpan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFacilitationTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupFacilitationTasks_Employees_FacilitatorId",
                        column: x => x.FacilitatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RucId = table.Column<int>(type: "int", nullable: false),
                    IsMasterThesis = table.Column<bool>(type: "bit", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    InternalCensorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Employees_InternalCensorId",
                        column: x => x.InternalCensorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhdCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhdCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhdCommittees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainSupervisorId = table.Column<int>(type: "int", nullable: true),
                    SecondarySupervisorId = table.Column<int>(type: "int", nullable: true),
                    EndEvaluatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phds_Employees_EndEvaluatorId",
                        column: x => x.EndEvaluatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phds_Employees_MainSupervisorId",
                        column: x => x.MainSupervisorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phds_Employees_SecondarySupervisorId",
                        column: x => x.SecondarySupervisorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExaminatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Employees_ExaminatorId",
                        column: x => x.ExaminatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleToBeAssessed = table.Column<int>(type: "int", nullable: false),
                    ParticipatingEmployeeOneId = table.Column<int>(type: "int", nullable: true),
                    ParticipatingEmployeeTwoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionCommittees_Employees_ParticipatingEmployeeOneId",
                        column: x => x.ParticipatingEmployeeOneId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionCommittees_Employees_ParticipatingEmployeeTwoId",
                        column: x => x.ParticipatingEmployeeTwoId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Synopses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExaminatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Synopses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Synopses_Employees_ExaminatorId",
                        column: x => x.ExaminatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHiringCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    HiringCommitteeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHiringCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeHiringCommittees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeHiringCommittees_HiringCommittees_HiringCommitteeId",
                        column: x => x.HiringCommitteeId,
                        principalTable: "HiringCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProgrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProgrammeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProgrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProgrammes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProgrammes_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaderProgrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammeId = table.Column<int>(type: "int", nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderProgrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderProgrammes_Leaders_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Leaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaderProgrammes_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Redemptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    MinutesRedeemedForSemester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redemptions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Redemptions_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RelativeLectureAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCourses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssistantProfessorSupervisions_AssistantProfessorId",
                table: "AssistantProfessorSupervisions",
                column: "AssistantProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssistantProfessorSupervisions_SupervisorId",
                table: "AssistantProfessorSupervisions",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EmployeeId",
                table: "Courses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCourses_CourseId",
                table: "EmployeeCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCourses_EmployeeId",
                table: "EmployeeCourses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCustomCommittees_CustomCommitteeId",
                table: "EmployeeCustomCommittees",
                column: "CustomCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCustomCommittees_EmployeeId",
                table: "EmployeeCustomCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHiringCommittees_EmployeeId",
                table: "EmployeeHiringCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHiringCommittees_HiringCommitteeId",
                table: "EmployeeHiringCommittees",
                column: "HiringCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProgrammes_EmployeeId",
                table: "EmployeeProgrammes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProgrammes_ProgrammeId",
                table: "EmployeeProgrammes",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFacilitationTasks_FacilitatorId",
                table: "GroupFacilitationTasks",
                column: "FacilitatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_InternalCensorId",
                table: "Groups",
                column: "InternalCensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SupervisorId",
                table: "Groups",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderProgrammes_LeaderId",
                table: "LeaderProgrammes",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderProgrammes_ProgrammeId",
                table: "LeaderProgrammes",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdCommittees_EmployeeId",
                table: "PhdCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phds_EndEvaluatorId",
                table: "Phds",
                column: "EndEvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Phds_MainSupervisorId",
                table: "Phds",
                column: "MainSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Phds_SecondarySupervisorId",
                table: "Phds",
                column: "SecondarySupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ExaminatorId",
                table: "Portfolios",
                column: "ExaminatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionCommittees_ParticipatingEmployeeOneId",
                table: "PromotionCommittees",
                column: "ParticipatingEmployeeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionCommittees_ParticipatingEmployeeTwoId",
                table: "PromotionCommittees",
                column: "ParticipatingEmployeeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Redemptions_EmployeeId",
                table: "Redemptions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Redemptions_SemesterId",
                table: "Redemptions",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Synopses_ExaminatorId",
                table: "Synopses",
                column: "ExaminatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssistantProfessorSupervisions");

            migrationBuilder.DropTable(
                name: "EmployeeCourses");

            migrationBuilder.DropTable(
                name: "EmployeeCustomCommittees");

            migrationBuilder.DropTable(
                name: "EmployeeHiringCommittees");

            migrationBuilder.DropTable(
                name: "EmployeeProgrammes");

            migrationBuilder.DropTable(
                name: "GroupFacilitationTasks");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "LeaderProgrammes");

            migrationBuilder.DropTable(
                name: "PhdCommittees");

            migrationBuilder.DropTable(
                name: "Phds");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "PromotionCommittees");

            migrationBuilder.DropTable(
                name: "Redemptions");

            migrationBuilder.DropTable(
                name: "Synopses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CustomCommittees");

            migrationBuilder.DropTable(
                name: "HiringCommittees");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
