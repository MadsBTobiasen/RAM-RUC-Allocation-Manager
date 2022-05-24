using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Email Email { get; set; }

        public List<EmailTemplate> Templates => emailService.EmailTemplates;
        public List<Leader> EmployeeLeaders => userService.GetEmployeeLeaders(Employee.Id);
        public Employee Employee => (Employee)userService.GetUserWithNavPropById(LoggedInUserId).Result;
        public int LoggedInUserId => Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        
        [BindProperty] 
        [Required]
        [StringLength(511, MinimumLength = 10)]
        public string MailBody { get; set; }

        #region SelectLists
        public List<SelectListItem> SelectListTemplateOptions
        {
            get
            {
                if (selectListTemplateOptions == null)
                {
                    selectListTemplateOptions = new List<SelectListItem>() { new SelectListItem() { Text = "Vælg et emne..", Value = "" } };
                    selectListTemplateOptions.AddRange(Templates.Select(et => new SelectListItem() { Value = et.ShortName, Text = et.Name }).ToList());
                }
                return selectListTemplateOptions;
            }
        }
        public List<SelectListItem> SelectListEmployeeLeaders
        {
            get
            {
                if (selectListEmployeeLeaders == null)
                {
                    selectListEmployeeLeaders = new List<SelectListItem>() { new SelectListItem() { Text = "Vælg en modtager..", Value = "" } };
                    selectListEmployeeLeaders.AddRange(userService.GetEmployeeLeaders(Employee.Id).Select(leader => new SelectListItem() { Value = $"{leader.Id}:{leader.Email}", Text = leader.Name }).ToList());
                }
                return selectListEmployeeLeaders;
            }
        }

        /// <summary>
        /// Both the outputs of the SelectedList values, has to be bigger than one. SInce the default "pick a (type)..", will have an empty value, and thusly be an invalid input.
        /// </summary>
        [BindProperty]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string SelectListTemplateOption { get; set; }
        [BindProperty]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string SelectListEmployeeLeader { get; set; }
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

            if (!ModelState.IsValid) return Page();

            EmailTemplate et = emailService.GetEmailTemplateByShortName(SelectListTemplateOption);

            User recepient = userService.GetUserByID(
                Convert.ToInt32(SelectListEmployeeLeader.Split(":")[0])
            );

            Email = new Email(et, recepient, Employee, MailBody);

            emailService.SendMail(Email.MimeMessageRecepient);
            emailService.SendMail(Email.MimeMessageSender);
            
            return Page();

        }
        #endregion
    }
}
