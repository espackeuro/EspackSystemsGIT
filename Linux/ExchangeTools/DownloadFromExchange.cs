using System;
using Microsoft.Exchange.WebServices.Data;
public class Clase
{
	public static string  DownloadFromExchange(string UserEmail,string PasswordEmail, string PathDownload, string Subject, string Extension)
	{
        //cargar credenciales
        string Asunto;
        string TXT="";
        bool Adjunto;
        string _stage = "";
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
                    Adjunto = false;
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

                    _stage = "Message update is read";
                    message.IsRead = true;                              // lo marcamos como leído
                    message.Update(ConflictResolutionMode.AutoResolve); // Se envía al servidor el cambio realizado

                    if (Asunto.Contains(Subject) || Subject == "")    // se comprueba en los correos no leídos el asunto
                    {
                        TXT += Asunto + "\n";
                        foreach (Attachment att in message.Attachments)
                        {
                            Adjunto = true;
                            // Recorrer los adjuntos
                            _stage = "Find in messages";
                            if (att is FileAttachment)
                            {
                                FileAttachment fileAttachment = att as FileAttachment;
                                // Carga el archivo adjunto en un archivo
                                if (Extension == fileAttachment.Name.Substring((fileAttachment.Name.ToString().Length - 3), 3))
                                {
                                    // Que guarda en la dirección indicada
                                    _stage = "Save File";
                                    TXT += "Attachment with extension: " + fileAttachment.Name.Substring((fileAttachment.Name.ToString().Length - 3), 3) + "\n";
                                    fileAttachment.Load(PathDownload + fileAttachment.Name);

                                    TXT += "Copy File attachment name: " + fileAttachment.Name + " and mark as read email \n";
                                }
                                else
                                {
                                    TXT += "Extension not " + Extension + "\n";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}]: {ex.Message}");
                    continue;
                }

                if (!Adjunto) { TXT += "NO Attachment"; }


            }
        }
        return TXT;
    }
}
