using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class LogSeleccionModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "LogSeleccion");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.LogSeleccion;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
