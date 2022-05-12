using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class LogEmpaquetadoModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "LogEmpaquetado");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.LogEmpaquetado;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
