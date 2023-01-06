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

namespace Proiect2.Pages.Testings
{
    public class EditModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public EditModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Testing Testing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Testing == null)
            {
                return NotFound();
            }

            var testing =  await _context.Testing.FirstOrDefaultAsync(m => m.ID == id);
            if (testing == null)
            {
                return NotFound();
            }
            Testing = testing;
           ViewData["BeautyID"] = new SelectList(_context.Beauty, "ID", "ID");
           ViewData["TesterID"] = new SelectList(_context.Tester, "ID", "ID");
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

            _context.Attach(Testing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestingExists(Testing.ID))
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

        private bool TestingExists(int id)
        {
          return _context.Testing.Any(e => e.ID == id);
        }
    }
}
