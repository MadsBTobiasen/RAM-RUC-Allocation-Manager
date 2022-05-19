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

        public BaseSettings(int id, int pedagogicalQualification, int baseHoursForProfessor, int baseHoursForAssociateProfessor, int baseHoursForAssistantProfessor, int lessonHourValue, int coordinatorOfCourseMinuteValue, int sabLessonHourValue, int sibLessonHourValue, int hourPerPersonHiringCommittee, int hourPerPersonPromotionCommittee, int phdCommitteeHourValue, int groupFacilitationBaseHour, int groupFacilitationHourDailyIncrement, int phdEndEvalHourWorth, int phdMainSupervisionHourWorth, int phdSecondarySupervisionHourWorth, int assistantProfessorSupervisonMinuteValue, int internalCensorMinuteValue, int groupLeaderMinuteValue, int portfolioHourWorth, int synopsisHourWorth, int supervisionOfGroupHourOneMember, int supervisionOfGroupHourTwoMember, int supervisionOfGroupHourThreeMember, int supervisionOfGroupHourFourMember, int supervisionOfGroupHourFiveMember, int supervisionOfGroupHourSixMember, int supervisionOfGroupHourOneMemberMasters, int supervisionOfGroupHourTwoMemberMasters, int supervisionOfGroupHourThreeMemberMasters, int supervisionOfGroupHourFourMemberMasters, int supervisionOfGroupHourFiveMembersMasters, int supervisionOfGroupHourSixMembersMasters)
        {
            ID = id;
            PedagogicalQualification = pedagogicalQualification;
            BaseHoursForProfessor = baseHoursForProfessor;
            BaseHoursForAssociateProfessor = baseHoursForAssociateProfessor;
            BaseHoursForAssistantProfessor = baseHoursForAssistantProfessor;
            LessonHourValue = lessonHourValue;
            CoordinatorOfCourseMinuteValue = coordinatorOfCourseMinuteValue;
            SabLessonHourValue = sabLessonHourValue;
            SibLessonHourValue = sibLessonHourValue;
            HourPerPersonHiringCommittee = hourPerPersonHiringCommittee;
            HourPerPersonPromotionCommittee = hourPerPersonPromotionCommittee;
            PhdCommitteeHourValue = phdCommitteeHourValue;
            GroupFacilitationBaseHour = groupFacilitationBaseHour;
            GroupFacilitationHourDailyIncrement = groupFacilitationHourDailyIncrement;
            PhdEndEvalHourWorth = phdEndEvalHourWorth;
            PhdMainSupervisionHourWorth = phdMainSupervisionHourWorth;
            PhdSecondarySupervisionHourWorth = phdSecondarySupervisionHourWorth;
            AssistantProfessorSupervisonMinuteValue = assistantProfessorSupervisonMinuteValue;
            InternalCensorMinuteValue = internalCensorMinuteValue;
            GroupLeaderMinuteValue = groupLeaderMinuteValue;
            PortfolioHourWorth = portfolioHourWorth;
            SynopsisHourWorth = synopsisHourWorth;
            SupervisionOfGroupHourOneMember = supervisionOfGroupHourOneMember;
            SupervisionOfGroupHourTwoMember = supervisionOfGroupHourTwoMember;
            SupervisionOfGroupHourThreeMember = supervisionOfGroupHourThreeMember;
            SupervisionOfGroupHourFourMember = supervisionOfGroupHourFourMember;
            SupervisionOfGroupHourFiveMember = supervisionOfGroupHourFiveMember;
            SupervisionOfGroupHourSixMember = supervisionOfGroupHourSixMember;
            SupervisionOfGroupHourOneMemberMasters = supervisionOfGroupHourOneMemberMasters;
            SupervisionOfGroupHourTwoMemberMasters = supervisionOfGroupHourTwoMemberMasters;
            SupervisionOfGroupHourThreeMemberMasters = supervisionOfGroupHourThreeMemberMasters;
            SupervisionOfGroupHourFourMemberMasters = supervisionOfGroupHourFourMemberMasters;
            SupervisionOfGroupHourFiveMembersMasters = supervisionOfGroupHourFiveMembersMasters;
            SupervisionOfGroupHourSixMembersMasters = supervisionOfGroupHourSixMembersMasters;
        }

        public BaseSettings()
        {
            
        }

    }
}
