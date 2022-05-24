using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAM___RUC_Allocation_Manager.MockData;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.Email;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.Test
{
    public class AddProgramModel : PageModel
    {

        private UserService userService;

        public ICollection<Programme> Programmes { get; set; }
        public ICollection<EmployeeProgramme> EmployeeProgrammes { get; set; }
        public ICollection<LeaderProgramme> LeaderProgrammes { get; set; }

        [BindProperty]
        public Programme Programme { get; set; }

        public List<User> Users { get; set; }
        public List<Leader> Leaders { get; set; }
        public Leader Leader { get; set; }

        public AddProgramModel(UserService userService)
        {
            this.userService = userService;
            FalkesMockdata falkesMockdata = new FalkesMockdata();
            //falkesMockdata.CreateMockData();
            Programmes = falkesMockdata.GetProgrammes();
            Leaders = falkesMockdata.GetLeaders();
            EmployeeProgrammes = falkesMockdata.GetEmployeeProgrammes();
            LeaderProgrammes = falkesMockdata.GetLeaderProgrammes();
            Console.WriteLine();
        }

        public IActionResult OnGet()
        {
            return Page(); 
        }

        public IActionResult OnPost()
        {
            Programmes.Add(Programme);
            return RedirectToPage("/LeaderLandingPage/LeaderLandingPage");
        }
    }
}
