using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class BaseSettings
    {

        #region Properties
        public int ID { get; set; }
        public int PedagogicalQualification { get; set; }
        public int BaseHoursForProfessor { get; set; }
        public int BaseHoursForAssociateProfessor { get; set; }
        public int BaseHoursForAssistantProfessor { get; set; }
        public int LessonHourValue { get; set; }
        public int SabLessonHourValue { get; set; }
        public int SibLessonHourValue { get; set; }
        public int HourPerPersonHiringCommittee { get; set; }
        public int HourPerPersonPromotionCommittee { get; set; }
        public int PhdCommitteeHourValue { get; set; }
        public int GroupFacilitationBaseHour { get; set; }
        public int GroupFacilitationHourDailyIncrement { get; set; }
        public int PhdEndEvalHourWorth { get; set; }
        public int PhdMainSupervisionHourWorth { get; set; }
        public int PhdSecondarySupervisionHourWorth { get; set; }
        public int PortfolioHourWorth { get; set; }
        public int SynopsisHourWorth { get; set; }
        public int SupervisionOfGroupHourOneMember { get; set; }
        public int SupervisionOfGroupHourTwoMember { get; set; }
        public int SupervisionOfGroupHourThreeMember { get; set; }
        public int SupervisionOfGroupHourFourMember { get; set; }
        public int SupervisionOfGroupHourFiveMember { get; set; }
        public int SupervisionOfGroupHourOneMemberMasters { get; set; }
        public int SupervisionOfGroupHourTwoMemberMasters { get; set; }
        public int SupervisionOfGroupHourThreeMemberMasters { get; set; }
        public int SupervisionOfGroupHourFourMemberMasters { get; set; }
        public int SupervisionOfGroupHourFiveMembersMasters { get; set; }
        public int SupervisionOfGroupHourSixMembersMasters { get; set; }
        
        #endregion

    }
}
