using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.Email
{
    public class Email
    {

        #region Fields
        private string _bodySubmittedByUser;
        #endregion

        #region Properties
        public EmailTemplate Template { get; }
        public string EmailBody => GenerateEmailBody();
        public User Recepient { get; }
        public User Sender { get; }
        #endregion

        #region Constructor
        public Email(EmailTemplate template, User rec, User send, string body)
        {
            Template = template;
            Recepient = rec;
            Sender = send;
            _bodySubmittedByUser = body;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that generates the body for the email, by replacing the template data,
        /// with the properties for the email.
        /// </summary>
        /// <returns></returns>
        private string GenerateEmailBody()
        {
            return "";
        }
        #endregion

    }
}
