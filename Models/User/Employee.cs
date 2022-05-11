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
        public virtual ICollection<EmployeeCourse> EmployeeCourses { get; set; }
        public virtual ICollection<Course> CoordinatorOfCourses { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<GroupFacilitationTask> GroupFacilitationTasks { get; set; }
        public virtual ICollection<Phd> Phds { get; set; }
        public virtual ICollection<AssistantProfessorSupervision> AssistantProfessorSupervisions { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Synopsis> Synopses { get; set; }
        public virtual ICollection<EmployeeProgramme> EmployeeProgrammes { get; set; }
        public virtual ICollection<Redemption> Redemptions { get; set; }
        public virtual ICollection<PromotionCommittee> PromotionCommittees { get; set; }
        public virtual ICollection<PhdCommittee> PhdCommittees { get; set; }
        public virtual ICollection<EmployeeHiringCommittee> EmployeeHiringCommittees { get; set; }
        public virtual ICollection<EmployeeCustomCommittee> EmployeeCustomCommittees { get; set; }
        #endregion

        #region Constructors
        
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
            totalMinutes += CoordinatorOfCourses.Count() * baseSettings.CoordinatorOfCourseMinuteValue;

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
            var groupSupervisionsResult = Groups.Where(g => g.Supervisor.Id == Id).Select(g => new {g.IsMasterThesis, g.MemberAmount});
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

            totalMinutes += Phds.Where(phd => phd.MainSupervisor.Id == Id).Select(phd => phd).Count() *
                            baseSettings.PhdMainSupervisionHourWorth;

            totalMinutes += Phds.Where(phd => phd.SecondarySupervisor.Id == Id).Select(phd => phd).Count() *
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
            totalMinutes += Groups.Where(g => g.InternalCensor.Id == Id).Select(g => g).Count() * baseSettings.InternalCensorMinuteValue;
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
            totalMinutes += Phds.Where(phd => phd.EndEvaluator.Id == Id).Select(phd => phd).Count() *
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
