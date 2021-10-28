using System;
using Microsoft.Exchange.WebServices.Data;
using System.Text.RegularExpressions;

public class ExchangeAttachments
{
	public static void  DownloadFromExchange(string UserEmail,string PasswordEmail, string PathDownload, string Subject, string Filter,string Sender)
	{
        //cargar credenciales
        string Asunto;
        string _stage = "";
        bool _isRead;
        EmailMessage message;

        ExchangeService exchange = new ExchangeService
        {
            Credentials = new WebCredentials(UserEmail, PasswordEmail)
        };
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        exchange.Url = new System.Uri("https://exchange.espackeuro.com/ews/exchange.asmx");
        if (exchange != null)
        {
            //El filtro de búsqueda para obtener correos electrónicos no leídos
            SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
            ItemView view = new ItemView(50);
            // Se Activa la consulta de los elementos no leídos
            // Este método obtiene el resultado de la llamada FindItem a EWS. Con los correos sin leer
            FindItemsResults<Item> findResults = exchange.FindItems(WellKnownFolderName.Inbox, sf, view);

            // Recorremos los correos no leídos 
            foreach (Item item in findResults)
            {
                try
                {

                    // Recorrer los mensajes
                    _stage = "Find in messages";
                    message = EmailMessage.Bind(exchange, item.Id);        // se carga el "message" busca por Id
                    Asunto = message.Subject.ToString();                                // sacamos el Subject
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}]: {ex.Message}");
                    continue;
                }

                try
                {

                    if (Regex.IsMatch(message.From.ToString(), Sender) || Sender == "")
                    {
                        Console.WriteLine($"-> Checking sender: {message.From}");
                        if (Asunto.Contains(Subject) || Subject == "")    // se comprueba en los correos no leídos el asunto
                        {
                            Console.WriteLine($"  -> Checking subject: {Asunto}");
                            _isRead = false;
                         
                            //
                            foreach (Attachment att in message.Attachments)
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

                                        if (!_isRead)
                                        {
                                            _stage = "Message update is read";
                                            message.IsRead = true;                              // lo marcamos como leído
                                            message.Update(ConflictResolutionMode.AutoResolve); // Se envía al servidor el cambio realizado
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
        return;
    }
}
