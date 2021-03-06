﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.MasterFruta
{
    public class EditModel : PageModel
    {
        private readonly WebApp1.Data.WebApp1Context _context;

        public EditModel(WebApp1.Data.WebApp1Context context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MasterFruta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterFrutaExists(MasterFruta.Fruta_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasterFrutaExists(int id)
        {
            return _context.MasterFruta.Any(e => e.Fruta_Id == id);
        }
    }
}
