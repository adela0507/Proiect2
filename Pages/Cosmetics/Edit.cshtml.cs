using Proiect2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using System.Collections.Specialized;

namespace Proiect2.Pages.Cosmetics
{
    public class EditModel : BeautyCategoriesPage
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
            Beauty = await _context.Beauty
            .Include(b => b.Expiration)
            .Include(b => b.BeautyCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Beauty == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Beauty);
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID",
            "BrandName");
            ViewData["ExpirartionID"] = new SelectList(_context.Expiration, "ID",
           "ExpirationProdcutName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beautyToUpdate = await _context.Beauty
            .Include(i => i.Expiration)
            .Include(i => i.BeautyCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (beautyToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Beauty>(
            beautyToUpdate,
            "Beauty",
            i => i.Name, i => i.BeautyCategories,
            i => i.Price, i => i.Brand, i => i.Brand))
            {
                UpdateBeautyCategories(_context, selectedCategories, beautyToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
         UpdateBeautyCategories(_context, selectedCategories, beautyToUpdate);
            PopulateAssignedCategoryData(_context, beautyToUpdate);
            return Page();
        }

    }
}
