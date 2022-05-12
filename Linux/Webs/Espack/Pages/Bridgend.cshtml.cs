using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class BridgendModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "Bridgend");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.Bridgend;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
