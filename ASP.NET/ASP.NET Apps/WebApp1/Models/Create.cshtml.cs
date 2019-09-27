using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.Data;

namespace WebApp1.Models
{
    public class CreateModel : PageModel
    {
        private readonly WebApp1.Data.WebApp1Context _context;

        public CreateModel(WebApp1.Data.WebApp1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MasterFruta MasterFruta { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MasterFruta.Add(MasterFruta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}