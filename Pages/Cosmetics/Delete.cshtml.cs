using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Cosmetics
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public DeleteModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Beauty Beauty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beauty == null)
            {
                return NotFound();
            }

            var beauty = await _context.Beauty.FirstOrDefaultAsync(m => m.ID == id);

            if (beauty == null)
            {
                return NotFound();
            }
            else 
            {
                Beauty = beauty;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Beauty == null)
            {
                return NotFound();
            }
            var beauty = await _context.Beauty.FindAsync(id);

            if (beauty != null)
            {
                Beauty = beauty;
                _context.Beauty.Remove(Beauty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
