using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class BaseSettings
    {
        /// <summary>
        /// Base values used to calculate hours for each employee
        /// </summary>
        #region Properties
        public int ID { get; set; } = 0;
        public int PedagogicalQualification { get; set; } = 0;
        public int BaseHoursForProfessor { get; set; } = 0;
        public int BaseHoursForAssociateProfessor { get; set; } = 0;
        public int BaseHoursForAssistantProfessor { get; set; } = 0;
        public int LessonHourValue { get; set; } = 0;
        public int CoordinatorOfCourseMinuteValue { get; set; } = 0;
        public int SabLessonHourValue { get; set; } = 0;
        public int SibLessonHourValue { get; set; } = 0;
        public int HourPerPersonHiringCommittee { get; set; } = 0;
        public int HourPerPersonPromotionCommittee { get; set; } = 0;
        public int PhdCommitteeHourValue { get; set; } = 0;
        public int GroupFacilitationBaseHour { get; set; } = 0;
        public int GroupFacilitationHourDailyIncrement { get; set; } = 0;
        public int PhdEndEvalHourWorth { get; set; } = 0;
        public int PhdMainSupervisionHourWorth { get; set; } = 0;
        public int PhdSecondarySupervisionHourWorth { get; set; } = 0;
        public int AssistantProfessorSupervisonMinuteValue { get; set; } = 0;
        public int InternalCensorMinuteValue { get; set; } = 0;
        public int GroupLeaderMinuteValue { get; set; } = 0;
        public int PortfolioHourWorth { get; set; } = 0;
        public int SynopsisHourWorth { get; set; } = 0;
        public int SupervisionOfGroupHourOneMember { get; set; } = 0;
        public int SupervisionOfGroupHourTwoMember { get; set; } = 0;
        public int SupervisionOfGroupHourThreeMember { get; set; } = 0;
        public int SupervisionOfGroupHourFourMember { get; set; } = 0;
        public int SupervisionOfGroupHourFiveMember { get; set; } = 0;
        public int SupervisionOfGroupHourSixMember { get; set; } = 0;
        public int SupervisionOfGroupHourOneMemberMasters { get; set; } = 0;
        public int SupervisionOfGroupHourTwoMemberMasters { get; set; } = 0;
        public int SupervisionOfGroupHourThreeMemberMasters { get; set; } = 0;
        public int SupervisionOfGroupHourFourMemberMasters { get; set; } = 0;
        public int SupervisionOfGroupHourFiveMembersMasters { get; set; } = 0;
        public int SupervisionOfGroupHourSixMembersMasters { get; set; } = 0;
        #endregion

    }
}
