using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
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
        #endregion

        #region Fields
        private SettingsService settingsService;
        #endregion

        #region Properties
        [Required]
        public EmployeeTitle Title { get; set; }
        [Required]
        public bool IsGroupLeader { get; set; }

        [Required]
        public int Balance { get; set; }
        #endregion

        #region Navigation properties
        public virtual ICollection<EmployeeCourse> EmployeeCourses { get; set; }
        public virtual ICollection<Course> CoordinatorOfCourses { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<GroupFacilitationTask> GroupFacilitationTasks { get; set; }
        public virtual ICollection<Phd> Phds { get; set; }
        public virtual ICollection<AssistantProfessorSupervision> AssistantProfessorSupervisions { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Synopsis> Synopses { get; set; }
        public virtual ICollection<EmployeeProgramme> EmployeeProgrammes { get; set; }
        public virtual ICollection<Redemption> Redemption { get; set; }
        public virtual ICollection<PromotionCommittee> PromotionCommittees { get; set; }
        public virtual ICollection<PhdCommittee> PhdCommittees { get; set; }
        public virtual ICollection<EmployeeHiringCommittee> EmployeeHiringCommittees { get; set; }
        public virtual ICollection<EmployeeCustomCommittee> EmployeeCustomCommittees { get; set; }
        #endregion

        #region Constructors
        public Employee(SettingsService settingsService)
        {
            this.settingsService = settingsService;
            Type = UserType.Employee;
        }

        public Employee()
        {
            Type = UserType.Employee;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculates total work assignment minutes for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalAllocationMinutes()
        {
            return CalculateTotalCourseMinutes() + CalculateTotalSupervisionMinutes() + CalculateTotalExamMinutes() +
                   CalculateTotalMiscMinutes();
        }
        /// <summary>
        /// Calculates total minutes for work assignments related to Courses for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalCourseMinutes()
        {
            int totalMinutes = 0;
            totalMinutes += CoordinatorOfCourses.Count() * settingsService.GetSettings().CoordinatorOfCourseMinuteValue;

            foreach (EmployeeCourse ec in EmployeeCourses)
            {
                switch (ec.Course.Type)
                {
                    case Course.CourseType.SAB:
                        totalMinutes += ec.Course.LectureAmount * settingsService.GetSettings().SabLessonHourValue;
                        break;
                    case Course.CourseType.SIB:
                        totalMinutes += ec.Course.LectureAmount * settingsService.GetSettings().SibLessonHourValue;
                        break;
                    case Course.CourseType.Standard:
                        totalMinutes += ec.Course.LectureAmount * settingsService.GetSettings().LessonHourValue;
                        break;
                }
            }

            return totalMinutes;
        }
        /// <summary>
        /// Calculates total minutes for work assignments related to supervisions for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalSupervisionMinutes()
        {
            int totalMinutes = 0;
            var groupSupervisionsResult = Groups.Where(g => g.Supervisor.Id == Id).Select(g => new {g.IsMasterThesis, g.MemberAmount});
            foreach (var anon in groupSupervisionsResult)
            {
                if (anon.IsMasterThesis)
                {
                    switch (anon.MemberAmount)
                    {
                        case 1:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourOneMemberMasters;
                            break;
                        case 2:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourTwoMemberMasters;
                            break;
                        case 3:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourThreeMemberMasters;
                            break;
                        case 4:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourFourMemberMasters;
                            break;
                        case 5:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourFiveMembersMasters;
                            break;
                        case 6:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourSixMembersMasters;
                            break;
                    }
                }
                else
                {
                    switch (anon.MemberAmount)
                    {
                        case 1:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourOneMember;
                            break;
                        case 2:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourTwoMember;
                            break;
                        case 3:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourThreeMember;
                            break;
                        case 4:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourFourMember;
                            break;
                        case 5:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourFiveMember;
                            break;
                        case 6:
                            totalMinutes += settingsService.GetSettings().SupervisionOfGroupHourSixMember;
                            break;
                    }
                }
            }

            foreach (GroupFacilitationTask gft in GroupFacilitationTasks)
            {
                totalMinutes += settingsService.GetSettings().GroupFacilitationBaseHour +
                                settingsService.GetSettings().GroupFacilitationHourDailyIncrement * gft.DaysSpan;
            }

            totalMinutes += Phds.Where(phd => phd.MainSupervisor.Id == Id).Select(phd => phd).Count() *
                            settingsService.GetSettings().PhdMainSupervisionHourWorth;

            totalMinutes += Phds.Where(phd => phd.SecondarySupervisor.Id == Id).Select(phd => phd).Count() *
                            settingsService.GetSettings().PhdSecondarySupervisionHourWorth;

            totalMinutes += AssistantProfessorSupervisions.Count *
                            settingsService.GetSettings().AssistantProfessorSupervisonMinuteValue;


            return totalMinutes;
        }
        /// <summary>
        /// Calculates total minutes for work assignments related to exams for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalExamMinutes()
        {
            int totalMinutes = 0;
            totalMinutes += Portfolios.Count * settingsService.GetSettings().PortfolioHourWorth;
            totalMinutes += Synopses.Count * settingsService.GetSettings().SynopsisHourWorth;
            totalMinutes += Groups.Where(g => g.InternalCensor.Id == Id).Select(g => g).Count() * settingsService.GetSettings().InternalCensorMinuteValue;
            return totalMinutes;
        }
        /// <summary>
        /// Calculates total minutes for work assignment related to misc tasks for an employee
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalMiscMinutes()
        {
            int totalMinutes = 0;
            totalMinutes += PhdCommittees.Count * settingsService.GetSettings().PhdCommitteeHourValue;

            totalMinutes += EmployeeHiringCommittees.Select(ehc =>
                ehc.HiringCommittee.PeopleToBeAssessed * settingsService.GetSettings().HourPerPersonHiringCommittee).Sum();

            totalMinutes += PromotionCommittees.Select(pc =>
                pc.PeopleToBeAssessed * settingsService.GetSettings().HourPerPersonPromotionCommittee).Sum();
            totalMinutes += EmployeeCustomCommittees.Select(ecc => ecc.CustomCommittee.MinuteWorth).Sum();
            totalMinutes += Phds.Where(phd => phd.EndEvaluator.Id == Id).Select(phd => phd).Count() *
                            settingsService.GetSettings().PhdEndEvalHourWorth;
            totalMinutes += settingsService.GetSettings().PedagogicalQualification;
            if (IsGroupLeader) totalMinutes += settingsService.GetSettings().GroupLeaderMinuteValue;
            return totalMinutes;
        }

        public int CalculateSavings()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateMinuteBalance()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateRedeemedMinutes()
        {
            return new Random().Next(0, 20) * 30;
        }

        public override ClaimsPrincipal GetClaimsPrinciple()
        {
            return null;
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
