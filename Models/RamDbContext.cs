using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class RamDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RamDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AssistantProfessorSupervision> AssistantProfessorSupervisions { get; set; }
        public DbSet<EmployeeCourse> EmployeeCourses { get; set; }
        public DbSet<GroupFacilitationTask> GroupFacilitationTasks { get; set; }
        public DbSet<PhdTasks> Phds { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Synopsis> Synopses { get; set; }
        public DbSet<CustomCommittee> CustomCommittees { get; set; }
        public DbSet<HiringCommittee> HiringCommittees { get; set; }
        public DbSet<PhdCommittee> PhdCommittees { get; set; }
        public DbSet<PromotionCommitteeTask> PromotionCommittees { get; set; }
        public DbSet<EmployeeProgramme> EmployeeProgrammes { get; set; }
        public DbSet<LeaderProgramme> LeaderProgrammes { get; set; }
        public DbSet<EmployeeHiringCommittee> EmployeeHiringCommittees { get; set; }
        public DbSet<EmployeeCustomCommittee> EmployeeCustomCommittees { get; set; }
        public DbSet<Redemption> Redemptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCourse>()
                .HasKey(employeeCourse => new { employeeCourse.CourseId, employeeCourse.EmployeeId });
            modelBuilder.Entity<EmployeeCustomCommittee>()
                .HasKey(employeeCustomCommittee => new { employeeCustomCommittee.CustomCommitteeId, employeeCustomCommittee.EmpployeeId });
            modelBuilder.Entity<EmployeeHiringCommittee>()
                .HasKey(employeeHiringCommittee => new { employeeHiringCommittee.EmployeeId, employeeHiringCommittee.HiringCommitteeId });
            modelBuilder.Entity<EmployeeProgramme>()
                .HasKey(employeeProgramme => new { employeeProgramme.ProgrammeId, employeeProgramme.EmployeeId });
            modelBuilder.Entity<LeaderProgramme>()
                .HasKey(leaderProgramme => new { leaderProgramme.ProgrammeId, leaderProgramme.LeaderId });
            modelBuilder.Entity<EmployeeGroup>().HasKey(eg => new {eg.EmployeeId, eg.GroupId});
        }
    }
}
