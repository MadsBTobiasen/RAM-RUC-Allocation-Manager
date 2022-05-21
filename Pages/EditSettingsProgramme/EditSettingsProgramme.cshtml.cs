using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.MockData;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.EditSettingsProgramme
{
    [Authorize(Roles = "Adminstrator")]
    public class EditSettingsProgrammeModel : PageModel
    {

        private UserService userService;
        public DbService<LeaderProgramme> dbService { get; set; }
        public ICollection<Programme> Programmes { get; set; }

        public EditSettingsProgrammeModel(DbService<LeaderProgramme> dbservice, UserService userService)
        {
            dbService = dbservice;
            this.userService = userService;
        }
        public void OnGet()
        {
            FalkesMockdata falkesMockdata = new FalkesMockdata();
            falkesMockdata.CreateMockData();
            Programmes = falkesMockdata.GetProgrammes();

        }
    }
}
