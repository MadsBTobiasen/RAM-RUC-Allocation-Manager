using MimeKit;
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
        private EmailTemplate Template { get; }
        private string SubjectRecepient => GenerateSubject(false);
        private string SubjectSender => GenerateSubject(true);
        public string EmailBodyRecepient => GenerateEmailBody(false);
        public string EmailBodySender => GenerateEmailBody(true);
        public MimeMessage MimeMessageRecepient => GenerateRecepientMimeMessage();
        public MimeMessage MimeMessageSender => GenerateSenderMimeMessage();
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
        /// Method that generates the body for the email, where it's possible to include a copy heading, to send to the sender.
        /// </summary>
        /// <param name="copy">Bool to indicate whether or not a "copy" string should be included.</param>
        /// <returns></returns>
        private string GenerateEmailBody(bool addCopy)
        {

            string copy = "<h2>Denne mail er en kopi, og kan ikke besvares.</h2>";
            string heading = $"<h3>Klage ({Template.Name}) indsendt af {Sender.Name}:</h3>";
            string body = _bodySubmittedByUser;
            string footer = $"Denne email kan ikke besvares.";

            if (!addCopy) footer += $"<br>Dit svar skal sendes til: <a href='mailto:{Sender.Email}' target='_blank'>{Sender.Email}</a>";
            else footer += $"<br>Din mail blev sendt til: <a href='mailto:{Recepient.Email}' target='_blank'>{Recepient.Email}</a>";

            if(addCopy) return $"{copy}<br>{heading}<br><br>{body}<br><br>{footer}";
            return $"{heading}<br><br>{body}<br><br>{footer}";

        }

        /// <summary>
        /// Method that generates the subject line to the mail, it's possible to add a copy heading, to send to the sender.
        /// </summary>
        /// <param name="addCopy">Bool to indicate whether or not a "copy" string should be included.</param>
        /// <returns></returns>
        private string GenerateSubject(bool addCopy)
        {
            if(addCopy) return $"[Kopi] Klage indsendt af dig: {Template.Name}";
            return $"Klage Indsendt: {Template.Name} [{Sender.Name}]";
        }

        /// <summary>
        /// Method that generates the MimeMessage for MailKit to be sent to the recipient.
        /// </summary>
        /// <returns>MimeMessage object to send.</returns>
        private MimeMessage GenerateRecepientMimeMessage()
        {

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("RAM NoReply", "RAM-system.noreply@Tier1TCG.dk"));
            message.To.Add(new MailboxAddress(Recepient.Name, Recepient.Email));
            message.Subject = SubjectRecepient;
            message.Body = new TextPart("html") { Text = EmailBodyRecepient };

            return message;

        }

        /// <summary>
        /// Method that generates the MimeMessage for MailKit to be sent to the sender.
        /// </summary>
        /// <returns>MimeMessage object to send.</returns>
        private MimeMessage GenerateSenderMimeMessage()
        {

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("RAM NoReply", "RAM-system.noreply@Tier1TCG.dk"));
            message.To.Add(new MailboxAddress(Sender.Name, Sender.Email));
            message.Subject = SubjectSender;
            message.Body = new TextPart("html") { Text = EmailBodySender };

            return message;

        }

        public override string ToString()
        {
            return $"Email: S:{Sender.Email} R:{Recepient.Email} Sub:{GenerateSubject(false)}";
        }
        #endregion

    }
}
