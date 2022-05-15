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
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RucId = table.Column<int>(type: "int", nullable: false),
                    IsMasterThesis = table.Column<bool>(type: "bit", nullable: false),
                    MemberAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
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
                name: "EmployeeCourses",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RelativeLectureAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCourses", x => new { x.CourseId, x.EmployeeId });
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCustomCommittees",
                columns: table => new
                {
                    EmpployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomCommitteeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCustomCommittees", x => new { x.CustomCommitteeId, x.EmpployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeCustomCommittees_CustomCommittees_CustomCommitteeId",
                        column: x => x.CustomCommitteeId,
                        principalTable: "CustomCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGroup",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    RoleOfEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGroup", x => new { x.EmployeeId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_EmployeeGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHiringCommittees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    HiringCommitteeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHiringCommittees", x => new { x.EmployeeId, x.HiringCommitteeId });
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProgrammeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProgrammes", x => new { x.ProgrammeId, x.EmployeeId });
                });

            migrationBuilder.CreateTable(
                name: "LeaderProgrammes",
                columns: table => new
                {
                    ProgrammeId = table.Column<int>(type: "int", nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderProgrammes", x => new { x.ProgrammeId, x.LeaderId });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    ProgrammeId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<int>(type: "int", nullable: true),
                    IsGroupLeader = table.Column<bool>(type: "bit", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: true),
                    Savings = table.Column<int>(type: "int", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssistantProfessorSupervisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistantProfessorSupervisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistantProfessorSupervisions_User_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LectureAmount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
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
                        name: "FK_GroupFacilitationTasks_User_FacilitatorId",
                        column: x => x.FacilitatorId,
                        principalTable: "User",
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
                        name: "FK_PhdCommittees_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RoleOfEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phds_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
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
                        name: "FK_Portfolios_User_ExaminatorId",
                        column: x => x.ExaminatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programmes_User_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "User",
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
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionCommittees_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Redemptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedeemedMinutes = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redemptions_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
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
                        name: "FK_Synopses_User_ExaminatorId",
                        column: x => x.ExaminatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssistantProfessorSupervisions_SupervisorId",
                table: "AssistantProfessorSupervisions",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EmployeeId",
                table: "Courses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCourses_EmployeeId",
                table: "EmployeeCourses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCustomCommittees_EmployeeId",
                table: "EmployeeCustomCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGroup_GroupId",
                table: "EmployeeGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHiringCommittees_HiringCommitteeId",
                table: "EmployeeHiringCommittees",
                column: "HiringCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProgrammes_EmployeeId",
                table: "EmployeeProgrammes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFacilitationTasks_FacilitatorId",
                table: "GroupFacilitationTasks",
                column: "FacilitatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderProgrammes_LeaderId",
                table: "LeaderProgrammes",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdCommittees_EmployeeId",
                table: "PhdCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phds_EmployeeId",
                table: "Phds",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ExaminatorId",
                table: "Portfolios",
                column: "ExaminatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_LeaderId",
                table: "Programmes",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionCommittees_EmployeeId",
                table: "PromotionCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Redemptions_EmployeeId",
                table: "Redemptions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Synopses_ExaminatorId",
                table: "Synopses",
                column: "ExaminatorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LeaderId",
                table: "User",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProgrammeId",
                table: "User",
                column: "ProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCourses_Courses_CourseId",
                table: "EmployeeCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCourses_User_EmployeeId",
                table: "EmployeeCourses",
                column: "EmployeeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCustomCommittees_User_EmployeeId",
                table: "EmployeeCustomCommittees",
                column: "EmployeeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeGroup_User_EmployeeId",
                table: "EmployeeGroup",
                column: "EmployeeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeHiringCommittees_User_EmployeeId",
                table: "EmployeeHiringCommittees",
                column: "EmployeeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProgrammes_Programmes_ProgrammeId",
                table: "EmployeeProgrammes",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProgrammes_User_EmployeeId",
                table: "EmployeeProgrammes",
                column: "EmployeeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderProgrammes_Programmes_ProgrammeId",
                table: "LeaderProgrammes",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderProgrammes_User_LeaderId",
                table: "LeaderProgrammes",
                column: "LeaderId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Programmes_ProgrammeId",
                table: "User",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programmes_User_LeaderId",
                table: "Programmes");

            migrationBuilder.DropTable(
                name: "AssistantProfessorSupervisions");

            migrationBuilder.DropTable(
                name: "EmployeeCourses");

            migrationBuilder.DropTable(
                name: "EmployeeCustomCommittees");

            migrationBuilder.DropTable(
                name: "EmployeeGroup");

            migrationBuilder.DropTable(
                name: "EmployeeHiringCommittees");

            migrationBuilder.DropTable(
                name: "EmployeeProgrammes");

            migrationBuilder.DropTable(
                name: "GroupFacilitationTasks");

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
                name: "Groups");

            migrationBuilder.DropTable(
                name: "HiringCommittees");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Programmes");
        }
    }
}
