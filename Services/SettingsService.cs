using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class SettingsService
    {

        #region Fields
        private JSONFileService<Setting> jsonFileService;
        #endregion

        #region Properties
        public List<Setting> Settings { get; set; }
        #endregion

        #region Methods
        public void LoadSettings()
        {

        }

        public void ApplySetting(Setting setting)
        {

        }
        #endregion

    }
}
