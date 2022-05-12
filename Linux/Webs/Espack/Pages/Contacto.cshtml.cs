using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using System.Net.Mail;

namespace WebEspackLinux.Pages
{
    public class ContactoModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Nombre { get; set; }

            [Required]
            public string Asunto { get; set; }
            [Required]
            public string Email { get; set; }

            [Required]
            public string Mensaje { get; set; }
            [Required]
            public string Robot { get; set; }
        }

        public IActionResult OnPost(string Nombre, string Asunto, string Email, string Mensaje, string Robot)
      //  public void OnGet()
        {
            HttpContext.Session.SetString("web", "Contacto");
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());
            }
            ViewData["Title"] = Idiomas.Contacto;
            ViewData["web"] = HttpContext.Session.GetString("web").ToString();
            if (Robot != "1") { ViewData["Mensaje"] = "ERROR: No has pulsado la casilla de No Soy Robot"; return Page(); }
            string _Subject = Asunto;
            string _Body = "IP: " + HttpContext.Connection.RemoteIpAddress.ToString() + ", Usuario Sistema Operativo: "+ Environment.UserName + "<br/><br/>" + Nombre + " con Email: " + Email + " Remitió el siguiente Mensaje: <br/><br/>" + Mensaje;
            string _SendTo = "jbelenguer@espackeuro.com";
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(_SendTo);
            msg.From = new MailAddress("itespackeuro@gmail.com", "Espack Eurologística", System.Text.Encoding.UTF8);
            msg.Subject = _Subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = _Body;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("itespackeuro", "*Espack321*");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
                ViewData["Mensaje"] = "Mensaje Enviado Correctamente. Gracias por contactar con Espack Eurologística";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                ViewData["Mensaje"] = "ERROR: " + ex.Message;
            }
            return Page();
        }

    }
}
