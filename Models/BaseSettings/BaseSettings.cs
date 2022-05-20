using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int PedagogicalQualification { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int BaseHoursForProfessor { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int BaseHoursForAssociateProfessor { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int BaseHoursForAssistantProfessor { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int LessonHourValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int CoordinatorOfCourseMinuteValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SabLessonHourValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SibLessonHourValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int HourPerPersonHiringCommittee { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int HourPerPersonPromotionCommittee { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int PhdCommitteeHourValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int GroupFacilitationBaseHour { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int GroupFacilitationHourDailyIncrement { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int PhdEndEvalHourWorth { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int PhdMainSupervisionHourWorth { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int PhdSecondarySupervisionHourWorth { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int AssistantProfessorSupervisonMinuteValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int InternalCensorMinuteValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int GroupLeaderMinuteValue { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int PortfolioHourWorth { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SynopsisHourWorth { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourOneMember { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourTwoMember { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourThreeMember { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourFourMember { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourFiveMember { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourSixMember { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourOneMemberMasters { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourTwoMemberMasters { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourThreeMemberMasters { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourFourMemberMasters { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourFiveMemberMasters { get; set; } = 0;
        [Required] [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")] public int SupervisionOfGroupHourSixMemberMasters { get; set; } = 0;
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
            SupervisionOfGroupHourFiveMemberMasters = supervisionOfGroupHourFiveMembersMasters;
            SupervisionOfGroupHourSixMemberMasters = supervisionOfGroupHourSixMembersMasters;
        }

        public BaseSettings()
        {
            
        }

    }
}
