using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Cosmetics
{
    public class EditModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public EditModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Beauty Beauty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beauty == null)
            {
                return NotFound();
            }

            var beauty =  await _context.Beauty.FirstOrDefaultAsync(m => m.ID == id);
            if (beauty == null)
            {
                return NotFound();
            }
            Beauty = beauty;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beauty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeautyExists(Beauty.ID))
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

        private bool BeautyExists(int id)
        {
          return _context.Beauty.Any(e => e.ID == id);
        }
    }
}
