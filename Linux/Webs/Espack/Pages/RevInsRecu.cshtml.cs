using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class RevInsRecuModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "RevInsRecu");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.RevInspRecu;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
