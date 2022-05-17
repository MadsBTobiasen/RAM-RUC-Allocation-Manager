using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAM___RUC_Allocation_Manager.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class EmailService
    {

        #region Fields
        private JSONFileService<EmailTemplate> emailTemplateJSONFileService;
        #endregion

        #region Properties
        public List<EmailTemplate> EmailTemplates { get; set; }

        #endregion

        #region Constructor
        public EmailService(JSONFileService<EmailTemplate> etjfs)
        {

            emailTemplateJSONFileService = etjfs;
            EmailTemplates = emailTemplateJSONFileService.GetJsonObjects().ToList();

        }
        #endregion

        #region Methods

        #endregion

    }
}
