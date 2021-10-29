using System;
using Microsoft.Exchange.WebServices.Data;
using System.Text.RegularExpressions;

public class ExchangeAttachments : IDisposable
{

    public ExchangeService pExchange;
    private string pBody = $"Results:<br><br>";
    private string pSubject = $"Capture report - {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}";

    public bool Connect(string UserEmail, string PasswordEmail)
    {
        string _stage = "";
        
        try
        {
            //
            _stage = "Creating credentials";
            pExchange = new ExchangeService
            {
                Credentials = new WebCredentials(UserEmail, PasswordEmail)
            };
            //
            _stage = "Using credentials";
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            //
            _stage = "Connecting to exchange";
            pExchange.Url = new System.Uri("https://exchange.espackeuro.com/ews/exchange.asmx");
        }
        catch(Exception ex)
        {
            throw new Exception($"[Connect#{_stage}] {ex.Message}");
        }
        return true;
    }


	public bool DownloadFromExchange(string PathDownload, string Subject, string Filter,string Sender)
	{
        //cargar credenciales
        string Asunto;
        string _stage = "";
        bool _isRead;
        bool _attachmentFound = false;
        EmailMessage _message;


        if (pExchange != null)
        {
            //El filtro de búsqueda para obtener correos electrónicos no leídos
            SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
            ItemView view = new ItemView(50);
            // Se Activa la consulta de los elementos no leídos
            // Este método obtiene el resultado de la llamada FindItem a EWS. Con los correos sin leer
            FindItemsResults<Item> findResults = pExchange.FindItems(WellKnownFolderName.Inbox, sf, view);

            // Recorremos los correos no leídos 
            foreach (Item item in findResults)
            {
                try
                {

                    // Recorrer los mensajes
                    _stage = "Find in messages";
                    _message = EmailMessage.Bind(pExchange, item.Id);        // se carga el "message" busca por Id
                    Asunto = _message.Subject.ToString();                                // sacamos el Subject
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}]: {ex.Message}");
                    continue;
                }

                try
                {

                    if (Regex.IsMatch(_message.From.ToString(), Sender) || Sender == "")
                    {
                        Console.WriteLine($"-> Checking sender: {_message.From}");
                        if (Asunto.Contains(Subject) || Subject == "")    // se comprueba en los correos no leídos el asunto
                        {
                            Console.WriteLine($"  -> Checking subject: {Asunto}");
                            _isRead = false;

                            //
                            foreach (Attachment att in _message.Attachments)
                            {
                                // Recorrer los adjuntos
                                _stage = "Find in messages";
                                if (att is FileAttachment)
                                {
                                    FileAttachment fileAttachment = att as FileAttachment;
                                    // Carga el archivo adjunto en un archivo
                                    //if (Filter == fileAttachment.Name.Substring((fileAttachment.Name.ToString().Length - 3), 3))
                                    if (Regex.IsMatch(fileAttachment.Name.ToString(), Filter) || Filter == "")
                                    {
                                        
                                        Console.Write($"    -> Checking attachment: {fileAttachment.Name} ...");

                                        // Que guarda en la dirección indicada
                                        _stage = "Save File";
                                        fileAttachment.Load(PathDownload + fileAttachment.Name);
                                        Console.WriteLine($" Downloaded OK!!");
                                        _attachmentFound = true;

                                        pBody += $"- File {fileAttachment.Name.ToString()} found and stored.<br>";

                                        if (!_isRead)
                                        {
                                            _stage = "Message update is read";
                                            _message.IsRead = true;                              // lo marcamos como leído
                                            _message.Update(ConflictResolutionMode.AutoResolve); // Se envía al servidor el cambio realizado
                                            _isRead = true;
                                            Console.WriteLine($"  -> Marked as read.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("-> No matches");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}]: {ex.Message}");
                    continue;
                }
            }
        }
        return _attachmentFound;
    }

    public bool SendEmail(string SendTo, string Subject="",string Body="")
    {
        string _stage = "";

        if (pExchange != null)
        {
            try
            {
                //
                Subject = (Subject != "" ? Subject : pSubject);
                Body = (Body != "" ? Body : pBody);

                // 
                _stage = "Preparing message";
                EmailMessage _message = new EmailMessage(pExchange);
                _message.Subject = Subject;
                _message.Body = Body;
                _message.ToRecipients.Add(SendTo);

                _stage = "Saving message";
                _message.Save();

                _stage = "Sending message";
                _message.SendAndSaveCopy();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception($"[SendEmail#{_stage}] {ex.Message}");
            }
        }

        return false;
    }
    public void Dispose()
    {
        string _stage = "";

        try
        {
            //
            _stage = "Checkings";
            if (pExchange != null)
                pExchange = null;
        }
        catch (Exception ex)
        {
            throw new Exception($"[Dispose#{_stage}] {ex.Message}");
        }
    }
}
