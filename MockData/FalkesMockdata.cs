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
        private void CreateMockData()
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

            //Programmes
            Programme ComputerScience = new Programme();
            ComputerScience.Name = "Computer science";

            Programme Sociology = new Programme();
            Sociology.Name = "Sociology";

            Programme Medicine = new Programme();
            Medicine.Name = "Medicine";

            Programme MultimediaDesign = new Programme();
            MultimediaDesign.Name = "Multimedia Design";

            //WorkAssignments
            CustomCommittee CustomCommittee = new CustomCommittee();
            CustomCommittee.Name = "Test Custom committee";
            CustomCommittee.MinuteWorth = 240;

            PromotionCommitteeTask promotionCommitteeTask = new PromotionCommitteeTask();
            promotionCommitteeTask.PeopleToBeAssessed = 4;

            HiringCommittee hiringCommittee = new HiringCommittee();
            hiringCommittee.PeopleToBeAssessed = 5;


            Course course = new Course();
            course.ResponsibleEmployee = Mads;
            course.Name = "Course name";
            course.LectureAmount = 100;
            course.Type = Course.CourseType.Standard;

            GroupFacilitationTask groupFacilitation = new GroupFacilitationTask();
            groupFacilitation.DaysSpan = 3;
            groupFacilitation.Facilitator = Falke;

            PhdTasks phd = new PhdTasks();
            phd.Employee = Falke;
            phd.RoleOfEmployee = PhdTasks.EmployeeRole.EndEvaluator;


            Group group = new Group();
            group.IsMasterThesis = false;
            group.MemberAmount = 3;
            group.RucId = 1;

            Redemption redemption = new Redemption();
            redemption.Employee = Falke;
            redemption.RedeemedMinutes = 60;
            redemption.StartDate = new DateTime(2022, 1, 1);
            redemption.EndDate = new DateTime(2023, 1, 1);

            //DbConnections
            EmployeeCourse employeeCourse = new EmployeeCourse();
            employeeCourse.Employee = Falke;
            employeeCourse.Course = course;
            employeeCourse.RelativeLectureAmount = 50;

            EmployeeCustomCommittee employeeCustomCommittee = new EmployeeCustomCommittee();
            employeeCustomCommittee.Employee = Falke;
            employeeCustomCommittee.CustomCommittee = CustomCommittee;

            EmployeeGroup employeeGroup = new EmployeeGroup();
            employeeGroup.Employee = Falke;
            employeeGroup.Group = group;
            employeeGroup.RoleOfEmployee = EmployeeGroup.EmployeeRole.InternalCensor;

            EmployeeHiringCommittee employeeHiringCommittee = new EmployeeHiringCommittee();
            employeeHiringCommittee.Employee = Falke;
            employeeHiringCommittee.HiringCommittee = hiringCommittee;

            EmployeeProgramme employeeProgramme = new EmployeeProgramme();
            employeeProgramme.Employee = Falke;
            employeeProgramme.Programme = ComputerScience;

            LeaderProgramme leaderProgramme = new LeaderProgramme();
            leaderProgramme.Programme = ComputerScience;
            leaderProgramme.Leader = Martin;

            //ListGenerating
            employeeList.Add(Falke);
            employeeList.Add(Mads);
            leaderList.Add(Martin);
            leaderList.Add(Simon);
            programmesList.Add(ComputerScience);
            programmesList.Add(Sociology);
            programmesList.Add(MultimediaDesign);
            programmesList.Add(Medicine);
            customCommitteesList.Add(CustomCommittee);
            promotionCommitteeTasksList.Add(promotionCommitteeTask);
            hiringCommitteeList.Add(hiringCommittee);
            courseList.Add(course);
            groupFacilitationTaskList.Add(groupFacilitation);
            phdTaskList.Add(phd);
            groupList.Add(group);
            redemptionList.Add(redemption);
            employeeCoursesList.Add(employeeCourse);
            employeeCustomCommitteesList.Add(employeeCustomCommittee);
            employeeGroupsList.Add(employeeGroup);
            employeeHiringCommitteesList.Add(employeeHiringCommittee);
            employeeProgrammesList.Add(employeeProgramme);
            leaderProgrammesList.Add(leaderProgramme);
        }

        public List<Employee> GetEmployees()
        {
            return employeeList;
        }

        public List<Leader> GetLeaders()
        {
            return leaderList;
        }

        public List<Programme> GetProgrammes()
        {
            return programmesList;
        }

        public List<CustomCommittee> GetCustomCommittees()
        {
            return customCommitteesList;
        }

        public List<PromotionCommitteeTask> GetPromotionCommitteeTasks()
        {
            return promotionCommitteeTasksList;
        }

        public List<HiringCommittee> GetHiringCommittees()
        {
            return hiringCommitteeList;
        }



        public List<Course> GetCourses()
        {
            return courseList;
        }

        public List<GroupFacilitationTask> GetGroupFacilitationTasks()
        {
            return groupFacilitationTaskList;
        }

        public List<PhdTasks> GetPhdTasks()
        {
            return phdTaskList;
        }




        public List<Group> GetGroups()
        {
            return groupList;
        }

        public List<Redemption> GetRedemptions()
        {
            return redemptionList;
        }

        public List<EmployeeCourse> GetEmployeeCourses()
        {
            return employeeCoursesList;
        }

        public List<EmployeeCustomCommittee> GetEmployeeCustomCommittees()
        {
            return employeeCustomCommitteesList;
        }

        public List<EmployeeGroup> GetEmployeeGroups()
        {
            return employeeGroupsList;
        }

        public List<EmployeeHiringCommittee> GetEmployeeHiringCommittees()
        {
            return employeeHiringCommitteesList;
        }

        public List<EmployeeProgramme> GetEmployeeProgrammes()
        {
            return employeeProgrammesList;
        }

        public List<LeaderProgramme> GetLeaderProgrammes()
        {
            return leaderProgrammesList;
        }
    }
}
