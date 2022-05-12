using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class MonPreConModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "MonPreCon");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.Montajespreparaconjuntos;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
