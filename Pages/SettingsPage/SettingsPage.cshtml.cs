using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.SettingsPage
{
    public class SettingsPageModel : PageModel
    {
        
        public Programme NewProgramme { get; set; }
        [BindProperty]
        public string ProgrammeName { get; set; }
        public LeaderProgramme NewLeaderProgramme { get; set; }
        [BindProperty]
        public Leader Leader { get; set; }

        public DbService<LeaderProgramme> dbService { get; set; }

        public SettingsPageModel(DbService<LeaderProgramme> dbservice)
        {
            dbService = dbservice;
        }

        public IActionResult OnPostCreateProgramme()
        {
            NewProgramme = new Programme();
            NewProgramme.Name = ProgrammeName;
            
            NewLeaderProgramme = new LeaderProgramme();
            NewLeaderProgramme.Leader = Leader;
            NewLeaderProgramme.Programme = NewProgramme;
            dbService.AddObjectAsync(NewLeaderProgramme);

            return Page();
        }
        public void OnGet()
        {
        }
    }
}
