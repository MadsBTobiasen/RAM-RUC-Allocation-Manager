using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;

namespace RAM___RUC_Allocation_Manager.MockData
{
    public class MockBaseSettings
    {
        private BaseSettings baseSettings = new BaseSettings();

        public BaseSettings GetBaseSettings()
        {
            return baseSettings;
        }
    }
}
