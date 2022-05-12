using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebEspackLinux.Pages
{
    
    public class PonIdiomaModel : PageModel
    {
        public IActionResult OnGet(string Lengua = null)
        {
            if (Lengua != null)
            {
                Clases.IdiomaCheck(Lengua);
                HttpContext.Session.SetString("lengua", Lengua);            
            }
            return Redirect(HttpContext.Session.GetString("web").ToString());
        }
    }
}
