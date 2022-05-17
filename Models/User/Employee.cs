using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Employee : User
    {

        #region Enumeration
        public enum EmployeeTitle
        {
            Professor,
            AssociateProfessor,
            AssistantProfessor
        }

        public enum SortingOptions
        {
            NameASC,
            NameDESC,
            TitleASC,
            TitleDESC
        }
        
        public enum EmployeeSavings
        {
            ZeroPercent,
            TwentyPercent,
            FortyPercent,
            SixtyPercent,
            EightyPercent,
            HundredPercent
        }
        #endregion

        #region Properties
        [Required]
        public EmployeeTitle Title { get; set; }
        [Required]
        public bool IsGroupLeader { get; set; }

        [Required]
        public int Balance { get; set; }
        [Required]
        public EmployeeSavings Savings { get; set; }

        #endregion

        #region Navigation properties

        public virtual ICollection<EmployeeCourse> EmployeeCourses { get; set; } = new List<EmployeeCourse>();
        public virtual ICollection<Course> CoordinatorOfCourses { get; set; } = new List<Course>();
        public virtual ICollection<EmployeeGroup> EmployeeGroups { get; set; } = new List<EmployeeGroup>();
        public virtual ICollection<GroupFacilitationTask> GroupFacilitationTasks { get; set; } = new List<GroupFacilitationTask>();
        public virtual ICollection<PhdTasks> PhdsTasks { get; set; } = new List<PhdTasks>();
        public virtual ICollection<AssistantProfessorSupervision> AssistantProfessorSupervisions { get; set; } = new List<AssistantProfessorSupervision>();
        public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public virtual ICollection<Synopsis> Synopses { get; set; } = new List<Synopsis>();
        public virtual ICollection<EmployeeProgramme> EmployeeProgrammes { get; set; } = new List<EmployeeProgramme>();
        public virtual ICollection<Redemption> Redemptions { get; set; } = new List<Redemption>();
        public virtual ICollection<PromotionCommitteeTask> PromotionCommittees { get; set; } = new List<PromotionCommitteeTask>();
        public virtual ICollection<PhdCommittee> PhdCommittees { get; set; } = new List<PhdCommittee>();
        public virtual ICollection<EmployeeHiringCommittee> EmployeeHiringCommittees { get; set; } = new List<EmployeeHiringCommittee>();
        public virtual ICollection<EmployeeCustomCommittee> EmployeeCustomCommittees { get; set; } = new List<EmployeeCustomCommittee>();
        #endregion

        #region Constructors
        
        public Employee()
        {
            Type = UserType.Employee;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns a ClaimsPrincipal to be used for authentication.
        /// </summary>
        /// <returns>Claims Principal object.</returns>
        public override ClaimsPrincipal GetClaimsPrinciple()
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.GivenName, Name),
                //new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role, Type.ToString())
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }

        /// <summary>
        /// Calculates total work assignment minutes for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalAllocationMinutes(BaseSettings baseSettings)
        {
            return CalculateTotalCourseMinutes(baseSettings) + CalculateTotalSupervisionMinutes(baseSettings) + CalculateTotalExamMinutes(baseSettings) +
                   CalculateTotalMiscMinutes(baseSettings);
        }
        /// <summary>
        /// Calculates total minutes for work assignments related to Courses for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalCourseMinutes(BaseSettings baseSettings)
        {
            int totalMinutes = 0;
            totalMinutes += CoordinatorOfCourses.Count * baseSettings.CoordinatorOfCourseMinuteValue;

            foreach (EmployeeCourse ec in EmployeeCourses)
            {
                switch (ec.Course.Type)
                {
                    case Course.CourseType.SAB:
                        totalMinutes += ec.Course.LectureAmount * baseSettings.SabLessonHourValue;
                        break;
                    case Course.CourseType.SIB:
                        totalMinutes += ec.Course.LectureAmount * baseSettings.SibLessonHourValue;
                        break;
                    case Course.CourseType.Standard:
                        totalMinutes += ec.Course.LectureAmount * baseSettings.LessonHourValue;
                        break;
                }
            }

            return totalMinutes;
        }
        /// <summary>
        /// Calculates total minutes for work assignments related to supervisions for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalSupervisionMinutes(BaseSettings baseSettings)
        {
            int totalMinutes = 0;
            var groupSupervisionsResult = EmployeeGroups.Where(eg => eg.RoleOfEmployee == EmployeeGroup.EmployeeRole.Supervisor).Select(eg => new {eg.Group.IsMasterThesis, eg.Group.MemberAmount});
            foreach (var anon in groupSupervisionsResult)
            {
                if (anon.IsMasterThesis)
                {
                    switch (anon.MemberAmount)
                    {
                        case 1:
                            totalMinutes += baseSettings.SupervisionOfGroupHourOneMemberMasters;
                            break;
                        case 2:
                            totalMinutes += baseSettings.SupervisionOfGroupHourTwoMemberMasters;
                            break;
                        case 3:
                            totalMinutes += baseSettings.SupervisionOfGroupHourThreeMemberMasters;
                            break;
                        case 4:
                            totalMinutes += baseSettings.SupervisionOfGroupHourFourMemberMasters;
                            break;
                        case 5:
                            totalMinutes += baseSettings.SupervisionOfGroupHourFiveMembersMasters;
                            break;
                        case 6:
                            totalMinutes += baseSettings.SupervisionOfGroupHourSixMembersMasters;
                            break;
                    }
                }
                else
                {
                    switch (anon.MemberAmount)
                    {
                        case 1:
                            totalMinutes += baseSettings.SupervisionOfGroupHourOneMember;
                            break;
                        case 2:
                            totalMinutes += baseSettings.SupervisionOfGroupHourTwoMember;
                            break;
                        case 3:
                            totalMinutes += baseSettings.SupervisionOfGroupHourThreeMember;
                            break;
                        case 4:
                            totalMinutes += baseSettings.SupervisionOfGroupHourFourMember;
                            break;
                        case 5:
                            totalMinutes += baseSettings.SupervisionOfGroupHourFiveMember;
                            break;
                        case 6:
                            totalMinutes += baseSettings.SupervisionOfGroupHourSixMember;
                            break;
                    }
                }
            }

            foreach (GroupFacilitationTask gft in GroupFacilitationTasks)
            {
                totalMinutes += baseSettings.GroupFacilitationBaseHour +
                                baseSettings.GroupFacilitationHourDailyIncrement * gft.DaysSpan;
            }

            totalMinutes += PhdsTasks.Where(phdt => phdt.RoleOfEmployee == PhdTasks.EmployeeRole.MainSupervisor).Select(phdt => phdt).Count() *
                            baseSettings.PhdMainSupervisionHourWorth;

            totalMinutes += PhdsTasks.Where(phdt => phdt.RoleOfEmployee == PhdTasks.EmployeeRole.SecondarySupervisor).Select(phdt => phdt).Count() *
                            baseSettings.PhdSecondarySupervisionHourWorth;

            totalMinutes += AssistantProfessorSupervisions.Count *
                            baseSettings.AssistantProfessorSupervisonMinuteValue;


            return totalMinutes;
        }
        /// <summary>
        /// Calculates total minutes for work assignments related to exams for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalExamMinutes(BaseSettings baseSettings)
        {
            int totalMinutes = 0;
            totalMinutes += Portfolios.Count * baseSettings.PortfolioHourWorth;
            totalMinutes += Synopses.Count * baseSettings.SynopsisHourWorth;
            totalMinutes += EmployeeGroups.Where(eg => eg.RoleOfEmployee == EmployeeGroup.EmployeeRole.InternalCensor).Select(eg => eg).Count() * baseSettings.InternalCensorMinuteValue;
            return totalMinutes;
        }
        /// <summary>
        /// Calculates total minutes for work assignment related to misc tasks for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalMiscMinutes(BaseSettings baseSettings)
        {
            int totalMinutes = 0;
            totalMinutes += PhdCommittees.Count * baseSettings.PhdCommitteeHourValue;

            totalMinutes += EmployeeHiringCommittees.Select(ehc =>
                ehc.HiringCommittee.PeopleToBeAssessed * baseSettings.HourPerPersonHiringCommittee).Sum();

            totalMinutes += PromotionCommittees.Select(pc =>
                pc.PeopleToBeAssessed * baseSettings.HourPerPersonPromotionCommittee).Sum();
            totalMinutes += EmployeeCustomCommittees.Select(ecc => ecc.CustomCommittee.MinuteWorth).Sum();
            totalMinutes += PhdsTasks.Where(phdt => phdt.RoleOfEmployee == PhdTasks.EmployeeRole.EndEvaluator).Select(phdt => phdt).Count() *
                            baseSettings.PhdEndEvalHourWorth;
            totalMinutes += baseSettings.PedagogicalQualification;
            if (IsGroupLeader) totalMinutes += baseSettings.GroupLeaderMinuteValue;
            return totalMinutes;
        }

        public int CalculateSavings()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateNewMinuteBalance(BaseSettings baseSettings)
        {
            switch (Title)
            {
                case EmployeeTitle.AssistantProfessor:
                    return baseSettings.BaseHoursForAssistantProfessor - CalculateTotalAllocationMinutes(baseSettings) -
                        Balance;
                case EmployeeTitle.AssociateProfessor:
                    return baseSettings.BaseHoursForAssistantProfessor - CalculateTotalAllocationMinutes(baseSettings) -
                           Balance;
                case EmployeeTitle.Professor:
                    return baseSettings.BaseHoursForAssistantProfessor - CalculateTotalAllocationMinutes(baseSettings) -
                           Balance;
            }

            throw new Exception("How did you get here?");
        }

        public int CalculateRedeemedMinutes()
        {
            return Redemptions.Where(r => r.StartDate < DateTime.Now && r.EndDate > DateTime.Now).Select(r => r.RedeemedMinutes).Sum();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"[Employee] ({Id}) {Name} {Password} {Email}";
        }
        #endregion

    }
}
