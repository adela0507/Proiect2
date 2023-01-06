using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Testers
{
    public class CreateModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public CreateModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tester Tester { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tester.Add(Tester);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
