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

namespace RAM___RUC_Allocation_Manager.Pages.EditEmployeePage
{
    public class AllocateHoursPageModel : PageModel
    {
        private UserService userService;
        private DbService<Course> courseDbService;
        private LoginService loginService;
        private SettingsService settingsService;
        private DbService<Employee> empDbService;
        private DbService<Redemption> redemptionDbService;
        private DbService<EmployeeCourse> ecDbService;
        private DbService<EmployeeGroup> egDbService;
        private DbService<Group> groupDbService;
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

        public AllocateHoursPageModel(DbService<PromotionCommitteeTask> pctDbService, DbService<EmployeeHiringCommittee> ehcDbService, DbService<HiringCommittee> hcDbService, DbService<EmployeeCustomCommittee> eccDbService, DbService<CustomCommittee> ccDbService, DbService<PhdTasks> phdDbService, DbService<GroupFacilitationTask> gftDbService, DbService<Group> groupDbService, DbService<EmployeeGroup> egDbService, UserService userService, DbService<Course> courseDbService, LoginService loginService, SettingsService settingsService, DbService<Employee> empDbService, DbService<Redemption> redemptionDbService, DbService<EmployeeCourse> ecDbService)
        {
            this.userService = userService;
            this.courseDbService = courseDbService;
            this.loginService = loginService;
            this.settingsService = settingsService;
            this.empDbService = empDbService;
            this.redemptionDbService = redemptionDbService;
            this.ecDbService = ecDbService;
            this.egDbService = egDbService;
            this.groupDbService = groupDbService;
            this.gftDbService = gftDbService;
            this.phdDbService = phdDbService;
            this.ccDbService = ccDbService;
            this.eccDbService = eccDbService;
            this.ehcDbService = ehcDbService;
        }

        public IActionResult OnGet(/*int id*/)
        {
            //loginService.HttpContext = HttpContext;
            //if (!loginService.AssessUser(id, LoggedInUserId))
            //{
            //    return Redirect("/Index");
            //}
            //if (id == -1) id = LoggedInUserId;

            GetProperties(1);
            
            return Page();
        }

        public async Task<IActionResult> OnPostSavings(int userId, Employee.EmployeeSavings savings)
        {
            GetProperties(userId);
            Employee.Savings = savings;
            userService.EditUser(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostGroupLeader(int userId, bool customSwitch)
        {
            GetProperties(userId);
            Employee.IsGroupLeader = customSwitch;
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRedeem(int userId, DateTime startDate, DateTime endDate, int hours, int minutes)
        {
            GetProperties(userId);
            Employee.Redemptions.Add(new Redemption { StartDate = startDate, EndDate = endDate, RedeemedMinutes = hours * 60 + minutes, Employee = Employee });
            await empDbService.UpdateObjectAsync(Employee);
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
            await empDbService.UpdateObjectAsync(Employee);

            return Page();
        }

        public async Task<IActionResult> OnPostManualBalance(int userId, int hours, int minutes)
        {
            GetProperties(userId);
            Employee.Balance = hours * 60 + minutes;
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveCourse(int userId, int removeId)
        {
            GetProperties(userId);
            await ecDbService.DeleteObjectAsync(Employee.EmployeeCourses.Where(ec => ec.CourseId == removeId).Select(ec => ec).FirstOrDefault());
            Employee.EmployeeCourses.Remove(Employee.EmployeeCourses.Where(ec => ec.CourseId == removeId).Select(ec => ec).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostAddCourse(int userId, int addId, int minutes, int hours)
        {
            GetProperties(userId);
            Employee.EmployeeCourses.Add(new EmployeeCourse
            {
                Employee = Employee, RelativeLectureAmount = hours * 60 + minutes,
                Course = Courses.Where(c => c.Id == addId).Select(c => c).FirstOrDefault()
            });
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }
        public async Task<IActionResult> OnPostRemoveGroup(int userId, int removeId)
        {
            GetProperties(userId);
            await egDbService.DeleteObjectAsync(Employee.EmployeeGroups.Where(eg => eg.GroupId == removeId).Select(eg => eg).FirstOrDefault());
            Employee.EmployeeGroups.Remove(Employee.EmployeeGroups.Where(eg => eg.GroupId == removeId).Select(eg => eg).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostAddGroup(int userId, int addId)
        {
            GetProperties(userId);
            Employee.EmployeeGroups.Add(new EmployeeGroup
            {
                Employee = Employee,
                Group = Groups.Where(g => g.Id == addId).Select(g => g).FirstOrDefault(),
                RoleOfEmployee = EmployeeGroup.EmployeeRole.Supervisor
            });
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostCreateGroup(int userId, int rucId, bool isMasterThesis, int members)
        {
            GetProperties(userId);
            await groupDbService.AddObjectAsync(new Group
                {RucId = rucId, IsMasterThesis = isMasterThesis, MemberAmount = members});
            return Page();
        }

        public async Task<IActionResult> OnPostAddGroupFacilitation(int userId, int daySpan)
        {
            GetProperties(userId);
            Employee.GroupFacilitationTasks.Add(new GroupFacilitationTask{DaysSpan = daySpan, Facilitator = Employee});
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveGroupFacilitation(int userId, int gftId)
        {
            GetProperties(userId);
            await gftDbService.DeleteObjectAsync(Employee.GroupFacilitationTasks.Where(gft => gft.Id == gftId)
                .Select(gft => gft).FirstOrDefault());
            Employee.GroupFacilitationTasks.Remove(Employee.GroupFacilitationTasks.Where(gft => gft.Id == gftId)
                .Select(gft => gft).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostPhdSupervision(int userId, PhdTasks.EmployeeRole employeeRole)
        {
            GetProperties(userId);
            Employee.PhdsTasks.Add(new PhdTasks{Employee = Employee, RoleOfEmployee = employeeRole});
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        

        public async Task<IActionResult> OnPostRemovePhdSupervision(int userId, int phdId)
        {
            GetProperties(userId);
            await phdDbService.DeleteObjectAsync(Employee.PhdsTasks.Where(phd => phd.Id == phdId)
                .Select(phd => phd).FirstOrDefault());
            Employee.PhdsTasks.Remove(Employee.PhdsTasks.Where(phd => phd.Id == phdId)
                .Select(phd => phd).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostAPSupervision(int userId, int apSupervisions)
        {
            GetProperties(userId);
            Employee.AssistantProfessorSupervisions = apSupervisions;
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostPortfolios(int userId, int portfolios)
        {
            GetProperties(userId);
            Employee.PortfolioExaminations = portfolios;
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }
        public async Task<IActionResult> OnPostSynopses(int userId, int synopses)
        {
            GetProperties(userId);
            Employee.SynopsisExaminations = synopses;
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveInternalCensor(int userId, int removeId)
        {
            GetProperties(userId);
            await egDbService.DeleteObjectAsync(Employee.EmployeeGroups.Where(eg => eg.GroupId == removeId).Select(eg => eg).FirstOrDefault());
            Employee.EmployeeGroups.Remove(Employee.EmployeeGroups.Where(eg => eg.GroupId == removeId).Select(eg => eg).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostAddInternalCensor(int userId, int addId)
        {
            GetProperties(userId);
            Employee.EmployeeGroups.Add(new EmployeeGroup
            {
                Employee = Employee,
                Group = Groups.Where(g => g.Id == addId).Select(g => g).FirstOrDefault(),
                RoleOfEmployee = EmployeeGroup.EmployeeRole.InternalCensor
            });
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostAddPhdEndEval(int userId, int amount)
        {
            GetProperties(userId);
            for (int i = 0; i < amount; i++)
            {
                Employee.PhdsTasks.Add(new PhdTasks { Employee = Employee, RoleOfEmployee = PhdTasks.EmployeeRole.EndEvaluator });
            }
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }
        public async Task<IActionResult> OnPostRemovePhdEndEval(int userId, int amount)
        {
            GetProperties(userId);
            if (amount < Employee.PhdsTasks.Where(phd => phd.RoleOfEmployee == PhdTasks.EmployeeRole.EndEvaluator)
                    .Select(phd => phd).Count())
            {
                amount = Employee.PhdsTasks.Where(phd => phd.RoleOfEmployee == PhdTasks.EmployeeRole.EndEvaluator)
                    .Select(phd => phd).Count();
            }
            for (int i = 0; i < amount; i++)
            {
                Employee.PhdsTasks.Remove(Employee.PhdsTasks.Where(phd=>phd.RoleOfEmployee == PhdTasks.EmployeeRole.EndEvaluator).Select(phd=>phd).FirstOrDefault());
            }
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostAddCustomCommittee(int userId, int ccId)
        {
            GetProperties(userId);
            Employee.EmployeeCustomCommittees.Add(new EmployeeCustomCommittee{CustomCommittee = CustomCommittees.Where(cc=>cc.Id == ccId).Select(cc=>cc).FirstOrDefault(), Employee = Employee});
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveCustomCommittee(int userId, int ccId)
        {
            GetProperties(userId);
            await eccDbService.DeleteObjectAsync(Employee.EmployeeCustomCommittees.Where(ecc => ecc.CustomCommitteeId == ccId).Select(ecc => ecc).FirstOrDefault());
            Employee.EmployeeCustomCommittees.Remove(Employee.EmployeeCustomCommittees.Where(ecc => ecc.CustomCommitteeId == ccId).Select(ecc => ecc).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostCreateCustomCommittee(int userId, int minutes, int hours, string name)
        {
            GetProperties(userId);
            await ccDbService.AddObjectAsync(new CustomCommittee
                { Name = name, MinuteWorth = hours*60+minutes});
            return Page();
        }

        public async Task<IActionResult> OnPostAddHiringCommittee(int userId, int hcId)
        {
            GetProperties(userId);
            Employee.EmployeeHiringCommittees.Add(new EmployeeHiringCommittee { HiringCommittee = HiringCommittees.Where(hc => hc.Id == hcId).Select(hc => hc).FirstOrDefault(), Employee = Employee });
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveHiringCommittee(int userId, int hcId)
        {
            GetProperties(userId);
            await ehcDbService.DeleteObjectAsync(Employee.EmployeeHiringCommittees.Where(ehc => ehc.HiringCommitteeId == hcId).Select(ehc => ehc).FirstOrDefault());
            Employee.EmployeeHiringCommittees.Remove(Employee.EmployeeHiringCommittees.Where(ehc => ehc.HiringCommitteeId == hcId).Select(ehc => ehc).FirstOrDefault());
            return Page();
        }

        public async Task<IActionResult> OnPostCreateHiringCommittee(int userId, int amount)
        {
            GetProperties(userId);
            await hcDbService.AddObjectAsync(new HiringCommittee
                { PeopleToBeAssessed = amount});
            return Page();
        }

        public async Task<IActionResult> OnPostPhdCommittees(int userId, int amount)
        {
            GetProperties(userId);
            Employee.PhdCommittees = amount;
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostAddPromotionCommittee(int userId, int amount)
        {
            GetProperties(userId);
            Employee.PromotionCommittees.Add(new PromotionCommitteeTask{PeopleToBeAssessed = amount});
            await empDbService.UpdateObjectAsync(Employee);
            return Page();
        }

        public async Task<IActionResult> OnPostRemovePromotionCommittee(int userId, int pcId)
        {
            GetProperties(userId);
            await pctDbService.DeleteObjectAsync(Employee.PromotionCommittees.Where(pc => pc.Id == pcId)
                .Select(pc => pc).FirstOrDefault());
            Employee.PromotionCommittees.Remove(Employee.PromotionCommittees.Where(pc => pc.Id == pcId)
                .Select(pc => pc).FirstOrDefault());
            return Page();
        }

        public string ConvertMinutesToHours(int minutes)
        {
            TimeSpan time = TimeSpan.FromMinutes(minutes);
            return string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
        }

        public void GetProperties(int userId)
        {
            Employee = empDbService.GetObjectByIdAsync(1).Result;
            Courses = courseDbService.GetObjectsAsync().Result.ToList();
            Groups = groupDbService.GetObjectsAsync().Result.ToList();
            EmployeeGroups = egDbService.GetObjectsAsync().Result.ToList();
            CustomCommittees = ccDbService.GetObjectsAsync().Result.ToList();
            HiringCommittees = hcDbService.GetObjectsAsync().Result.ToList();
            BaseSettings = settingsService.GetSettings();
        }
    }
}