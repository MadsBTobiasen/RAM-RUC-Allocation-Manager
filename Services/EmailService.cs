using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using RAM___RUC_Allocation_Manager.Models;
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
        private JSONFileService<EmailConfiguration> emailConfigurationJSONFileService;
        #endregion

        #region Properties
        public List<EmailTemplate> EmailTemplates { get; set; }
        private EmailConfiguration EmailConfiguration { get; set; }
        #endregion

        #region Constructor
        public EmailService(JSONFileService<EmailTemplate> etjfs, JSONFileService<EmailConfiguration> ecjfs)
        {

            emailTemplateJSONFileService = etjfs;
            EmailTemplates = emailTemplateJSONFileService.GetJsonObjects().ToList();

            emailConfigurationJSONFileService = ecjfs;
            EmailConfiguration = emailConfigurationJSONFileService.GetJsonObjects().ToList()[0];

        }

        #endregion

        #region Methods
        /// <summary>
        /// Method that tries to match an email template, with the list of email templates.
        /// </summary>
        /// <param name="selectListTemplateOption"></param>
        /// <returns>Email template object.</returns>
        public EmailTemplate GetEmailTemplateByShortName(string selectListTemplateOption)
        {
            return EmailTemplates.Where(et => et.ShortName == selectListTemplateOption).FirstOrDefault();
        }

        /// <summary>
        /// Method that tries to send the MimeMessage passed.
        /// </summary>
        /// <param name="message"></param>
        public void SendMail(MimeMessage message)
        {

            using (var client = new SmtpClient())
            {

                client.Connect("smtp.simply.com", 587, false);
                client.Authenticate(EmailConfiguration.Username, EmailConfiguration.Password);

                client.Send(message);
                client.Disconnect(true);

            }

        }
        #endregion

    }
}
