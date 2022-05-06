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

        #region Constructor
        public SettingsService(JSONFileService<BaseSettings> json)
        {

            jsonFileService = json;
            LoadSettings();

            Console.WriteLine($"Found and loaded the settings file, with settings id: ({Settings.ID})");

        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that retrieves the settings from the settings file, and loads it into the Settings-property.
        /// </summary>
        private void LoadSettings()
        {

            Settings = jsonFileService.GetJsonObjects().SingleOrDefault();

        }

        /// <summary>
        /// Method that updates the setting-object, and saves the changes to the JSON file.
        /// </summary>
        /// <param name="updatedSettings"></param>
        public void ApplySetting(BaseSettings updatedSettings)
        {

            //Apply changes to settings
            Settings = updatedSettings;
            jsonFileService.SaveJsonObjects(new List<BaseSettings>() { Settings });

        }

        /// <summary>
        /// Method that returns the BaseSettings object.
        /// </summary>
        /// <returns>BaseSettings object.</returns>
        public BaseSettings GetSettings()
        {
            return Settings;
        }
        #endregion

    }
}
