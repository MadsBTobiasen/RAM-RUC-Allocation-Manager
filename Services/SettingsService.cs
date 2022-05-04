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
        private JSONFileService<BaseSettings> jsonFileService;
        #endregion

        #region Properties
        public BaseSettings Settings { get; set; }
        #endregion

        #region Methods
        public void LoadSettings()
        {

        }

        public void ApplySetting()
        {

        }

        public BaseSettings GetSettings()
        {
            return Settings;
        }
        #endregion

    }
}
