using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.MasterFruta
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp1.Data.WebApp1Context _context;

        public DeleteModel(WebApp1.Data.WebApp1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public WebApp1.Models.MasterFruta MasterFruta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MasterFruta = await _context.MasterFruta.FirstOrDefaultAsync(m => m.Fruta_Id == id);

            if (MasterFruta == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MasterFruta = await _context.MasterFruta.FindAsync(id);

            if (MasterFruta != null)
            {
                _context.MasterFruta.Remove(MasterFruta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
