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
    public class CreateModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public CreateModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var beautyList = _context.Beauty
               .Include(b => b.BeautyCategories)
               .Select(x => new
               {
                   x.ID,
                   BeautyFullName = x.Name + " - " + x.BeautyCategories
               });
            ViewData["BeautyID"] = new SelectList(beautyList, "ID", "ID");
        ViewData["TesterID"] = new SelectList(_context.Tester, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Testing Testing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Testing.Add(Testing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
