using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
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
                client.Authenticate("RAM-system.noreply@Tier1TCG.dk", "Tier1MTG");

                client.Send(message);
                client.Disconnect(true);

            }

        }
        #endregion

    }
}
