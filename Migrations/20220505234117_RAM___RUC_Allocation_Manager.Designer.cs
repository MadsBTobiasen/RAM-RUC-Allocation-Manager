﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAM___RUC_Allocation_Manager.Models;

namespace RAM___RUC_Allocation_Manager.Migrations
{
    [DbContext(typeof(RamDbContext))]
    [Migration("20220505234117_RAM___RUC_Allocation_Manager")]
    partial class RAM___RUC_Allocation_Manager
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.EmployeeCustomCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomCommitteeId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EmpployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomCommitteeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeCustomCommittees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.EmployeeHiringCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("HiringCommitteeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("HiringCommitteeId");

                    b.ToTable("EmployeeHiringCommittees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.EmployeeProgramme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProgrammeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("EmployeeProgrammes");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.LeaderProgramme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeaderId")
                        .HasColumnType("int");

                    b.Property<int>("ProgrammeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeaderId");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("LeaderProgrammes");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGroupLeader")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InternalCensorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMasterThesis")
                        .HasColumnType("bit");

                    b.Property<int>("RucId")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InternalCensorId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Leader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Leaders");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Programme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programmes");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Redemption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("MinutesRedeemedForSemester")
                        .HasColumnType("int");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Redemptions");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.AssistantProfessorSupervision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssistantProfessorId")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssistantProfessorId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("AssistantProfessorSupervisions");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.CustomCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MinuteWorth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomCommittees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.HiringCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PeopleToBeAssessed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HiringCommittees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.PhdCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PhdCommittees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.PromotionCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParticipatingEmployeeOneId")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipatingEmployeeTwoId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleToBeAssessed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipatingEmployeeOneId");

                    b.HasIndex("ParticipatingEmployeeTwoId");

                    b.ToTable("PromotionCommittees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("LectureAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.EmployeeCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("RelativeLectureAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeCourses");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.GroupFacilitationTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysSpan")
                        .HasColumnType("int");

                    b.Property<int?>("FacilitatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacilitatorId");

                    b.ToTable("GroupFacilitationTasks");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Phd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EndEvaluatorId")
                        .HasColumnType("int");

                    b.Property<int?>("MainSupervisorId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondarySupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndEvaluatorId");

                    b.HasIndex("MainSupervisorId");

                    b.HasIndex("SecondarySupervisorId");

                    b.ToTable("Phds");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExaminatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExaminatorId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Synopsis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExaminatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExaminatorId");

                    b.ToTable("Synopses");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.EmployeeCustomCommittee", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.CustomCommittee", "CustomCommittee")
                        .WithMany("EmployeesCustomCommittees")
                        .HasForeignKey("CustomCommitteeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Employee")
                        .WithMany("EmployeeCustomCommittees")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("CustomCommittee");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.EmployeeHiringCommittee", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Employee")
                        .WithMany("EmployeeHiringCommittees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.HiringCommittee", "HiringCommittee")
                        .WithMany("EmployeeHiringCommittees")
                        .HasForeignKey("HiringCommitteeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("HiringCommittee");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.EmployeeProgramme", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Employee")
                        .WithMany("EmployeeProgrammes")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Programme", "Programme")
                        .WithMany("EmployeeProgrammes")
                        .HasForeignKey("ProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.DbConnections.LeaderProgramme", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Leader", "Leader")
                        .WithMany("LeaderProgrammes")
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Programme", "Programme")
                        .WithMany("LeaderProgrammes")
                        .HasForeignKey("ProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leader");

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Group", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "InternalCensor")
                        .WithMany()
                        .HasForeignKey("InternalCensorId");

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");

                    b.Navigation("InternalCensor");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Redemption", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Employee")
                        .WithMany("Redemption")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.Navigation("Employee");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.AssistantProfessorSupervision", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "AssistantProfessor")
                        .WithMany()
                        .HasForeignKey("AssistantProfessorId");

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");

                    b.Navigation("AssistantProfessor");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.PhdCommittee", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.PromotionCommittee", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "ParticipatingEmployeeOne")
                        .WithMany()
                        .HasForeignKey("ParticipatingEmployeeOneId");

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "ParticipatingEmployeeTwo")
                        .WithMany()
                        .HasForeignKey("ParticipatingEmployeeTwoId");

                    b.Navigation("ParticipatingEmployeeOne");

                    b.Navigation("ParticipatingEmployeeTwo");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Course", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "ResponsibleEmployee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponsibleEmployee");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.EmployeeCourse", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Employee")
                        .WithMany("EmployeeCourses")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Course");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.GroupFacilitationTask", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Facilitator")
                        .WithMany()
                        .HasForeignKey("FacilitatorId");

                    b.Navigation("Facilitator");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Phd", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "EndEvaluator")
                        .WithMany()
                        .HasForeignKey("EndEvaluatorId");

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "MainSupervisor")
                        .WithMany()
                        .HasForeignKey("MainSupervisorId");

                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "SecondarySupervisor")
                        .WithMany()
                        .HasForeignKey("SecondarySupervisorId");

                    b.Navigation("EndEvaluator");

                    b.Navigation("MainSupervisor");

                    b.Navigation("SecondarySupervisor");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Portfolio", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Examinator")
                        .WithMany()
                        .HasForeignKey("ExaminatorId");

                    b.Navigation("Examinator");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Synopsis", b =>
                {
                    b.HasOne("RAM___RUC_Allocation_Manager.Models.Employee", "Examinator")
                        .WithMany()
                        .HasForeignKey("ExaminatorId");

                    b.Navigation("Examinator");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Employee", b =>
                {
                    b.Navigation("EmployeeCourses");

                    b.Navigation("EmployeeCustomCommittees");

                    b.Navigation("EmployeeHiringCommittees");

                    b.Navigation("EmployeeProgrammes");

                    b.Navigation("Redemption");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Leader", b =>
                {
                    b.Navigation("LeaderProgrammes");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.Programme", b =>
                {
                    b.Navigation("EmployeeProgrammes");

                    b.Navigation("LeaderProgrammes");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.CustomCommittee", b =>
                {
                    b.Navigation("EmployeesCustomCommittees");
                });

            modelBuilder.Entity("RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee.HiringCommittee", b =>
                {
                    b.Navigation("EmployeeHiringCommittees");
                });
#pragma warning restore 612, 618
        }
    }
}
