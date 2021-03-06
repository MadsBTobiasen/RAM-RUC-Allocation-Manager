using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee;
using RAM___RUC_Allocation_Manager.Services;
using RAM___RUC_Allocation_Manager.Services.DbServices;

namespace RAM___RUC_Allocation_Manager.Pages.EditEmployeePage
{
    public class AllocateHoursPageModel : PageModel
    {
        private UserService userService;
        private CourseService courseService;
        private LoginService loginService;
        private SettingsService settingsService;
        private DbService<Redemption> redemptionDbService;
        private DbService<EmployeeCourse> ecDbService;
        private DbService<EmployeeGroup> egDbService;
        private GroupService groupService;
        private DbService<GroupFacilitationTask> gftDbService;
        private DbService<PhdTasks> phdDbService;
        private DbService<CustomCommittee> ccDbService;
        private DbService<EmployeeCustomCommittee> eccDbService;
        private DbService<HiringCommittee> hcDbService;
        private DbService<EmployeeHiringCommittee> ehcDbService;
        private DbService<PromotionCommitteeTask> pctDbService;

        public Employee Employee { get; set; }
        public List<Group> Groups { get; set; }
        public List<Course> Courses { get; set; }
        public List<CustomCommittee> CustomCommittees { get; set; }
        public List<HiringCommittee> HiringCommittees { get; set; }
        public List<Employee> AllEmployees { get; set; }

        public List<EmployeeGroup> EmployeeGroups { get; set; }
        //public List<EmployeeCourse> EmployeeCourses { get; set; }
        public BaseSettings BaseSettings { get; set; }
        public int LoggedInUserId
        {
            get
            {
                return Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }

        public AllocateHoursPageModel(UserService userService, CourseService courseService, LoginService loginService, SettingsService settingsService, DbService<Redemption> redemptionDbService, DbService<EmployeeCourse> ecDbService, DbService<EmployeeGroup> egDbService, GroupService groupService, DbService<GroupFacilitationTask> gftDbService, DbService<PhdTasks> phdDbService, DbService<EmployeeCustomCommittee> eccDbService, DbService<HiringCommittee> hcDbService, DbService<EmployeeHiringCommittee> ehcDbService, DbService<PromotionCommitteeTask> pctDbService, DbService<CustomCommittee> ccDbService)
        {

            this.userService = userService;
            this.courseService = courseService;
            this.loginService = loginService;
            this.settingsService = settingsService;
            this.redemptionDbService = redemptionDbService;
            this.ecDbService = ecDbService;
            this.egDbService = egDbService;
            this.groupService = groupService;
            this.gftDbService = gftDbService;
            this.phdDbService = phdDbService;
            this.ccDbService = ccDbService;
            this.eccDbService = eccDbService;
            this.hcDbService = hcDbService;
            this.ehcDbService = ehcDbService;
            this.pctDbService = pctDbService;

        }

        public IActionResult OnGet(int id)
        {
            
            loginService.HttpContext = HttpContext;
            if (!loginService.AssessUser(id, LoggedInUserId))
            {
                return Redirect("/Index");
            }
            if (id == -1) id = LoggedInUserId;

            GetProperties(id);
            
            return Page();
        }

        #region OnPost

        public async Task<IActionResult> OnPostSavings(int userId, Employee.EmployeeSavings savings)
        {
            GetProperties(userId);
            Employee.Savings = savings;
            await userService.EditUser(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostGroupLeader(int userId, bool customSwitch)
        {
            GetProperties(userId);
            Employee.IsGroupLeader = customSwitch;
            await userService.EditUser(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRedeem(int userId, DateTime startDate, DateTime endDate, int hours, int minutes)
        {
            GetProperties(userId);
            Employee.Redemptions.Add(new Redemption { StartDate = startDate, EndDate = endDate, RedeemedMinutes = hours * 60 + minutes, Employee = Employee });
            await userService.EditUser(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteRedemption(int userId, int id)
        {
            GetProperties(userId);
            await redemptionDbService.DeleteObjectAsync(Employee.Redemptions.Where(r => r.Id == id).Select(r => r).FirstOrDefault());
            Employee.Redemptions.Remove(Employee.Redemptions.Where(r => r.Id == id).Select(r => r).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostAutoBalance(int userId)
        {
            GetProperties(userId);
            Employee.Balance = Employee.CalculateNewMinuteBalance(settingsService.GetSettings());
            await userService.EditUser(Employee);

            return Page();
        }

        public async Task<IActionResult> OnPostManualBalance(int userId, int hours, int minutes)
        {
            GetProperties(userId);
            Employee.Balance = hours * 60 + minutes;
            await userService.EditUser(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostCreateCourse(int userId, string name, int coordinatorId, int lectures,
            Course.CourseType type)
        {
            await courseService.CreateCourse(new Course
                { EmployeeId = coordinatorId, Name = name, LectureAmount = lectures, Type = type });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveCourse(int userId, int removeId)
        {
            await ecDbService.DeleteObjectAsync(new EmployeeCourse { EmployeeId = userId, CourseId = removeId });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddCourse(int userId, int addId, int relativeLectureAmount)
        {
            await ecDbService.AddObjectAsync(new EmployeeCourse
            {
                EmployeeId = userId,
                RelativeLectureAmount = relativeLectureAmount,
                CourseId = addId
            });
            GetProperties(userId);
            return Page();
        }
        public async Task<IActionResult> OnPostRemoveGroup(int userId, int removeId)
        {
            await egDbService.DeleteObjectAsync(new EmployeeGroup { EmployeeId = userId, GroupId = removeId });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddGroup(int userId, int addId)
        {
            await egDbService.AddObjectAsync(new EmployeeGroup
            {
                EmployeeId = userId,
                RoleOfEmployee = EmployeeGroup.EmployeeRole.Supervisor,
                GroupId = addId
            });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostCreateGroup(int userId, int rucId, bool isMasterThesis, int members)
        {
            await groupService.CreateGroup(new Group
                {RucId = rucId, IsMasterThesis = isMasterThesis, MemberAmount = members});
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddGroupFacilitation(int userId, int daySpan)
        {
            await gftDbService.AddObjectAsync(new GroupFacilitationTask
            {
                FacilitatorId = userId,
                DaysSpan = daySpan
            });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveGroupFacilitation(int userId, int gftId)
        {
            await gftDbService.DeleteObjectAsync(new GroupFacilitationTask { Id = gftId});
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostPhdSupervision(int userId, PhdTasks.EmployeeRole employeeRole)
        {
            await phdDbService.AddObjectAsync(new PhdTasks
            {
                EmployeeId = userId,
                RoleOfEmployee = employeeRole
            });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostRemovePhdSupervision(int userId, int phdId)
        {
            await phdDbService.DeleteObjectAsync(new PhdTasks { Id = phdId });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAPSupervision(int userId, int apSupervisions)
        {
            GetProperties(userId);
            Employee.AssistantProfessorSupervisions = apSupervisions;
            await userService.EditUser(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostPortfolios(int userId, int portfolios)
        {
            GetProperties(userId);
            Employee.PortfolioExaminations = portfolios;
            await userService.EditUser(Employee);
            return Page();
        }
        public async Task<IActionResult> OnPostSynopses(int userId, int synopses)
        {
            GetProperties(userId);
            Employee.SynopsisExaminations = synopses;
            await userService.EditUser(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveInternalCensor(int userId, int removeId)
        {
            await egDbService.DeleteObjectAsync(new EmployeeGroup { EmployeeId = userId, GroupId = removeId });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddInternalCensor(int userId, int addId)
        {
            await egDbService.AddObjectAsync(new EmployeeGroup
            {
                EmployeeId = userId,
                RoleOfEmployee = EmployeeGroup.EmployeeRole.InternalCensor,
                GroupId = addId
            });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddPhdEndEval(int userId, int amount)
        {
            GetProperties(userId);
            for (int i = 0; i < amount; i++)
            {
                await phdDbService.AddObjectAsync(new PhdTasks
                {
                    EmployeeId = userId,
                    RoleOfEmployee = PhdTasks.EmployeeRole.EndEvaluator
                });
            }
            GetProperties(userId);
            return Page();
        }
        public async Task<IActionResult> OnPostRemovePhdEndEval(int userId, int amount)
        {
            var endEval = phdDbService.GetObjectsAsync().Result.ToList().Where(phd => phd.RoleOfEmployee == PhdTasks.EmployeeRole.EndEvaluator && phd.EmployeeId == userId).Select(phd => phd).ToList();
            if (amount > endEval.Count())
            {
                amount = endEval.Count();
            }
            for (int i = 0; i < amount; i++)
            {
                await phdDbService.DeleteObjectAsync(endEval[i]);
            }
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddCustomCommittee(int userId, int ccId)
        {
            await eccDbService.AddObjectAsync(new EmployeeCustomCommittee
            {
                EmployeeId = userId,
                CustomCommitteeId = ccId
            });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveCustomCommittee(int userId, int ccId)
        {
            await eccDbService.DeleteObjectAsync(new EmployeeCustomCommittee { EmployeeId = userId, CustomCommitteeId = ccId });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostCreateCustomCommittee(int userId, int minutes, int hours, string name)
        {
            await ccDbService.AddObjectAsync(new CustomCommittee
                { Name = name, MinuteWorth = hours*60+minutes});
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddHiringCommittee(int userId, int hcId)
        {
            await ehcDbService.AddObjectAsync(new EmployeeHiringCommittee { EmployeeId = userId, HiringCommitteeId = hcId });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveHiringCommittee(int userId, int hcId)
        {
            await ehcDbService.DeleteObjectAsync(new EmployeeHiringCommittee { EmployeeId = userId, HiringCommitteeId = hcId });
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostCreateHiringCommittee(int userId, int amount)
        {
            await hcDbService.AddObjectAsync(new HiringCommittee
                { PeopleToBeAssessed = amount});
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostPhdCommittees(int userId, int amount)
        {
            Employee = (Employee)userService.GetUserByID(userId);
            Employee.PhdCommittees = amount;
            await userService.EditUser(Employee);
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddPromotionCommittee(int userId, int amount)
        {
            await pctDbService.AddObjectAsync(new PromotionCommitteeTask {PeopleToBeAssessed = amount, EmployeeId = userId});
            GetProperties(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostRemovePromotionCommittee(int userId, int pcId)
        {
            await pctDbService.DeleteObjectAsync(new PromotionCommitteeTask { EmployeeId = userId, Id = pcId });
            GetProperties(userId);
            return Page();
        }

        public string ConvertMinutesToHours(int minutes)
        {
            TimeSpan time = TimeSpan.FromMinutes(minutes);
            return string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
        }

        public void GetProperties(int userId)
        {
            Employee = (Employee) userService.GetUserWithNavPropById(userId).Result;
            Courses = courseService.GetCourses();
            Groups = groupService.GetGroups();
            EmployeeGroups = egDbService.GetObjectsAsync().Result.ToList();
            CustomCommittees = ccDbService.GetObjectsAsync().Result.ToList();
            HiringCommittees = hcDbService.GetObjectsAsync().Result.ToList();
            AllEmployees = userService.GetUsersByType(Models.User.UserType.Employee).Cast<Employee>().ToList();
            BaseSettings = settingsService.GetSettings();
        }

        #endregion

    }
}
