using System;


namespace ConsoleTools
{
    public class cEmail:IDisposable
    {

        public cConnDetails ConnDetails;

        public string Server { get { return ConnDetails.Server; } set { ConnDetails.Server = value; } }
        public string User { get { return ConnDetails.User; } set { ConnDetails.User = value; } }
        public string Password { get { return ConnDetails.Password; } set { ConnDetails.Password = value; } }
        
        public string Recipients, Subject, Body, Attachment, EmptyMessage;
        public bool Error;

        public cEmail(cConnDetails connDetails, string recipients = null, string subject = null, string body = null, string attachment = null, string emptyMessage = null, bool error = false)
        {
            ConnDetails = connDetails;
            Recipients = recipients;
            Subject = subject;
            Body = body;
            Attachment = attachment;
            EmptyMessage = emptyMessage;
            Error = error;
        }
        public cEmail(string server, string user, string password, string recipients = null, string subject = null, string body = null, string attachment = null, string emptyMessage = null, bool error = false) : this(new cConnDetails(server, user, password), recipients, subject, body, attachment, emptyMessage, error)
        {

        }

        public void Send()
        {
            string _stage = "", _subject, _body;
            try
            {
                //
                _stage = "Checkings";
                if (ConnDetails == null || String.IsNullOrEmpty(Server) || String.IsNullOrEmpty(User) || String.IsNullOrEmpty(Password))
                    throw new Exception("There are no connection details set");
                if(String.IsNullOrEmpty(Recipients))
                    throw new Exception("There are no recipients set");
                if (String.IsNullOrEmpty(Subject))
                    throw new Exception("There is no subject set");
                if (String.IsNullOrEmpty(Body) && String.IsNullOrEmpty(Attachment))
                    throw new Exception("There is nothing to send: without body message and attachment");

                //
                _stage = "Connecting to email server";
                ExchangeAttachments _email = new ExchangeAttachments();
                _email.Connect(ConnDetails);

                //
                _subject = (Error ? "ERROR on " : "") + $"ALARM {Subject}";
                _body = !String.IsNullOrEmpty(Body) ? (String.IsNullOrEmpty(Attachment) ? Body : "<html><body><b>Message sent automatically.</b><br><i>Mensaje enviado automáticamente.</i></body></html>") : $"<html><body>{(!String.IsNullOrEmpty(EmptyMessage) ? EmptyMessage : "<b>No results found.</b><br><i>No se encontraron resultados.</i>")}</body></html>";
                
                //
                _stage = "Sending email";
                if (!_email.SendEmail(Recipients, $"{_subject} {DateTime.Now.ToString("dd/MM/yyyy")}", _body, Attachment))
                    throw new Exception("Could not send the email");
            }
            catch (Exception ex)
            {
                throw new Exception($"[cEmail/Send#{_stage}] {ex.Message}");
            }

        }
        public void Dispose()
        {

        }
    }
}
