using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebEspackLinux.Pages
{
    public class DistribucionModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("web", "Distribucion");    
            if (HttpContext.Session.GetString("lengua") != null)
            {
                Clases.IdiomaCheck(HttpContext.Session.GetString("lengua").ToString());              
            }
            ViewData["Title"] = Idiomas.Distribucnacionalinter;
            ViewData["web"]= HttpContext.Session.GetString("web").ToString();
        }
    }
}
