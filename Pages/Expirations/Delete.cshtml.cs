using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Expirations
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public DeleteModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Expiration Expiration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Expiration == null)
            {
                return NotFound();
            }

            var expiration = await _context.Expiration.FirstOrDefaultAsync(m => m.ID == id);

            if (expiration == null)
            {
                return NotFound();
            }
            else 
            {
                Expiration = expiration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Expiration == null)
            {
                return NotFound();
            }
            var expiration = await _context.Expiration.FindAsync(id);

            if (expiration != null)
            {
                Expiration = expiration;
                _context.Expiration.Remove(Expiration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
