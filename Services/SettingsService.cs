using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.MockData;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class SettingsService
    {
        #region Fields
        private JSONFileService<BaseSettings> jsonFileService;
        private List<BaseSettings> BaseSettings;
        #endregion

        #region Properties
        #endregion

        public SettingsService(JSONFileService<BaseSettings> jsonFileService)
        {
            this.jsonFileService = jsonFileService;
            //BaseSettingsList = MockSettings.GetMocksBaseSettings();
            BaseSettings = jsonFileService.GetJsonObjects().ToList();
            //jsonFileService.SaveJsonObjects(BaseSettings);
        }

        #region Methods
        public List<BaseSettings> LoadSettings()
        {
            return BaseSettings;
        }

        /// <summary>
        /// Updates the value of all the properties in BaseSettings.
        /// </summary>
        /// <param name="baseSettings"></param>
        public void ApplySetting(BaseSettings baseSettings)
        {
            if (baseSettings != null)
            {
                foreach (BaseSettings b in BaseSettings)
                {
                    b.LessonHourValue = baseSettings.LessonHourValue;
                    b.HourPerPersonHiringCommittee = baseSettings.HourPerPersonHiringCommittee;
                    b.HourPerPersonPromotionCommittee = baseSettings.HourPerPersonHiringCommittee;
                    b.SupervisionOfGroupHourSixMemberMasters = baseSettings.SupervisionOfGroupHourSixMemberMasters;
                    b.SupervisionOfGroupHourSixMember = baseSettings.SupervisionOfGroupHourSixMember;
                    b.SupervisionOfGroupHourFiveMember = baseSettings.SupervisionOfGroupHourFiveMember;
                    b.SupervisionOfGroupHourFiveMemberMasters = baseSettings.SupervisionOfGroupHourFiveMemberMasters;
                    b.SupervisionOfGroupHourFourMember = baseSettings.SupervisionOfGroupHourFourMember;
                    b.SupervisionOfGroupHourFourMemberMasters = baseSettings.SupervisionOfGroupHourFourMemberMasters;
                    b.SupervisionOfGroupHourThreeMember = baseSettings.SupervisionOfGroupHourThreeMember;
                    b.SupervisionOfGroupHourThreeMemberMasters = baseSettings.SupervisionOfGroupHourThreeMemberMasters;
                    b.SupervisionOfGroupHourTwoMember = baseSettings.SupervisionOfGroupHourTwoMember;
                    b.SupervisionOfGroupHourTwoMemberMasters = baseSettings.SupervisionOfGroupHourTwoMemberMasters;
                    b.SupervisionOfGroupHourOneMember = baseSettings.SupervisionOfGroupHourOneMember;
                    b.SupervisionOfGroupHourOneMemberMasters = baseSettings.SupervisionOfGroupHourOneMemberMasters;
                    b.BaseHoursForAssistantProfessor = baseSettings.BaseHoursForAssistantProfessor;
                    b.BaseHoursForAssociateProfessor = baseSettings.BaseHoursForAssociateProfessor;
                    b.BaseHoursForProfessor = baseSettings.BaseHoursForProfessor;
                    b.GroupFacilitationBaseHour = baseSettings.GroupFacilitationBaseHour;
                    b.GroupFacilitationHourDailyIncrement = baseSettings.GroupFacilitationHourDailyIncrement;
                    b.HourPerPersonHiringCommittee = baseSettings.HourPerPersonHiringCommittee;
                    b.HourPerPersonPromotionCommittee = baseSettings.HourPerPersonPromotionCommittee;
                    b.PedagogicalQualification = baseSettings.PedagogicalQualification;
                    b.PhdCommitteeHourValue = baseSettings.PhdCommitteeHourValue;
                    b.PhdEndEvalHourWorth = baseSettings.PhdEndEvalHourWorth;
                    b.PhdMainSupervisionHourWorth = baseSettings.PhdMainSupervisionHourWorth;
                    b.PhdSecondarySupervisionHourWorth = baseSettings.PhdSecondarySupervisionHourWorth;
                    b.PortfolioHourWorth = baseSettings.PortfolioHourWorth;
                    b.SynopsisHourWorth = baseSettings.SynopsisHourWorth;
                    b.SabLessonHourValue = baseSettings.SabLessonHourValue;
                    b.SibLessonHourValue = baseSettings.SibLessonHourValue;
                    b.AssistantProfessorSupervisonMinuteValue = baseSettings.AssistantProfessorSupervisonMinuteValue;
                    b.GroupLeaderMinuteValue = baseSettings.GroupLeaderMinuteValue;
                    b.InternalCensorMinuteValue = baseSettings.InternalCensorMinuteValue;
                    b.CoordinatorOfCourseMinuteValue = baseSettings.CoordinatorOfCourseMinuteValue;
                }
                jsonFileService.SaveJsonObjects(BaseSettings);
            }
        }

        /// <summary>
        /// Gets the value of the properties in BaseSettings.
        /// </summary>
        /// <returns></returns>
        public BaseSettings GetSettings()
        {
            foreach (BaseSettings settings in BaseSettings)
            {
                return settings;
            }
            return null;
        }
        #endregion
    }
}
