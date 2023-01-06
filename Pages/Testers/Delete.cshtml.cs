using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Testers
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public DeleteModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Tester Tester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tester == null)
            {
                return NotFound();
            }

            var tester = await _context.Tester.FirstOrDefaultAsync(m => m.ID == id);

            if (tester == null)
            {
                return NotFound();
            }
            else 
            {
                Tester = tester;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tester == null)
            {
                return NotFound();
            }
            var tester = await _context.Tester.FindAsync(id);

            if (tester != null)
            {
                Tester = tester;
                _context.Tester.Remove(Tester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
