using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class CastleBromwichModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "CastleBromwich");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.CastleBromwich;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
