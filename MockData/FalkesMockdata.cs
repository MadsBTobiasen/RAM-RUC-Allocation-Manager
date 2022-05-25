using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.MockData
{
    public class FalkesMockdata
    {
        private List<Employee> employeeList = new List<Employee>();
        private List<Leader> leaderList = new List<Leader>();
        private List<Programme> programmesList = new List<Programme>();
        private List<CustomCommittee> customCommitteesList = new List<CustomCommittee>();
        private List<PromotionCommitteeTask> promotionCommitteeTasksList = new List<PromotionCommitteeTask>();
        private List<HiringCommittee> hiringCommitteeList = new List<HiringCommittee>();
        private List<Course> courseList = new List<Course>();
        private List<GroupFacilitationTask> groupFacilitationTaskList = new List<GroupFacilitationTask>();
        private List<PhdTasks> phdTaskList = new List<PhdTasks>();
        private List<Group> groupList = new List<Group>();
        private List<Redemption> redemptionList = new List<Redemption>();
        private List<EmployeeCourse> employeeCoursesList = new List<EmployeeCourse>();
        private List<EmployeeCustomCommittee> employeeCustomCommitteesList = new List<EmployeeCustomCommittee>();
        private List<EmployeeGroup> employeeGroupsList = new List<EmployeeGroup>();
        private List<EmployeeHiringCommittee> employeeHiringCommitteesList = new List<EmployeeHiringCommittee>();
        private List<EmployeeProgramme> employeeProgrammesList = new List<EmployeeProgramme>();
        private List<LeaderProgramme> leaderProgrammesList = new List<LeaderProgramme>();

        public FalkesMockdata()
        {
            CreateMockData();
        }
        public void CreateMockData()
        {
            //Users
            Employee Falke = new Employee();
            Falke.Name = "Falke";
            Falke.Email = "Falke@mail.dk";
            Falke.Username = "FalkeUsername";
            Falke.SetPassword("FalkePassword");
            Falke.Title = Employee.EmployeeTitle.Professor;
            Falke.IsGroupLeader = true;
            Falke.Balance = 0;
            Falke.Savings = Employee.EmployeeSavings.ZeroPercent;

            Employee Mads = new Employee();
            Mads.Name = "Mads";
            Mads.Email = "Mads@mail.dk";
            Mads.Username = "MadsUsername";
            Mads.SetPassword("MadsPassword");
            Mads.Title = Employee.EmployeeTitle.AssistantProfessor;
            Mads.IsGroupLeader = false;
            Mads.Balance = 60;
            Mads.Savings = Employee.EmployeeSavings.FortyPercent;

            Leader Martin = new Leader();
            Martin.Name = "Martin";
            Martin.Email = "Martin@Mail.dk";
            Martin.Username = "MatinUsername";
            Martin.SetPassword("MartinPassword");
            Martin.IsAdmin = true;

            Leader Simon = new Leader();
            Simon.Name = "Simon";
            Simon.Email = "Simon@mail.dk";
            Simon.Username = "SimonUsername";
            Simon.SetPassword("SimonPassword");
            Simon.IsAdmin = false;

        }

        public List<Employee> GetEmployees()
        {
            return employeeList;
        }

        public List<Leader> GetLeaders()
        {
            return leaderList;
        }

    }
}
