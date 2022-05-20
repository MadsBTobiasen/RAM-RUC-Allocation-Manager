using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.EditSettingsProgramme
{
    [Authorize(Roles = "Adminstrator")]
    public class EditSettingsProgrammeModel : PageModel
    {
        
        public DbService<LeaderProgramme> dbService { get; set; }
        public IEnumerable<LeaderProgramme> LeaderProgrammes { get; set; }

        public EditSettingsProgrammeModel(DbService<LeaderProgramme> dbservice)
        {
            dbService = dbservice;
        }
        public async void OnGet()
        { 
           //MockData.MockLeaderProgrammes.CreateMockData();
           LeaderProgrammes = await dbService.GetObjectsAsync();
           //LeaderProgrammes = MockData.MockLeaderProgrammes.GetMockLeaderProgrammes();

        }
    }
}
