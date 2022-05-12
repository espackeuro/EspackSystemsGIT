using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class CerPreModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "CerPre");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.CertificadosPremios;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
