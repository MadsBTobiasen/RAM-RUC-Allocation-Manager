using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.Email;
using RAM___RUC_Allocation_Manager.Services;

namespace RAM___RUC_Allocation_Manager.Pages.ComplaintPage
{

    [Authorize(Roles = "Employee")]
    public class ComplaintPageModel : PageModel
    {

        #region Fields
        private EmailService emailService;
        private UserService userService;

        private List<SelectListItem> selectListTemplateOptions;
        private List<SelectListItem> selectListEmployeeLeaders;
        #endregion

        #region Properties
        public List<EmailTemplate> Templates => emailService.EmailTemplates;
        public List<Leader> EmployeeLeaders => userService.GetEmployeeLeaders(Employee.Id);
        public Employee Employee => (Employee)userService.GetUserByID(LoggedInUserId);
        public int LoggedInUserId => Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

        #region SelectLists
        public List<SelectListItem> SelectListTemplateOptions
        { 
            get 
            {
                if (selectListTemplateOptions == null) selectListTemplateOptions = Templates.Select(et => new SelectListItem() { Value = et.ShortName, Text = et.Name }).ToList();
                return selectListTemplateOptions;
            }
        }
        public List<SelectListItem> SelectListEmployeeLeaders 
        { 
            get 
            {
                if (selectListEmployeeLeaders == null) selectListEmployeeLeaders = userService.GetEmployeeLeaders(Employee.Id).Select(leader => new SelectListItem() { Value = $"{leader.Id}:{leader.Email}", Text = leader.Name }).ToList();
                return selectListEmployeeLeaders;
            } 
        }
        [BindProperty] public SelectListItem SelectListTemplateOption { get; set; }
        [BindProperty] public SelectListItem SelectListEmployeeLeader { get; set; }
        #endregion

        #endregion

        #region Constructor
        public ComplaintPageModel(EmailService es, UserService us)
        {

            emailService = es;
            userService = us;
           
        }
        #endregion

        #region Methods
        public void OnGet()
        {
        }

        /// <summary>
        /// Method that constructs the email-object and tries to send it.
        /// </summary>
        public IActionResult OnPostSendMail()
        {
            return Page();
        }
        #endregion
    }
}
