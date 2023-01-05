using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Cosmetics
{
    public class CreateModel : BeautyCategoriesPage
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public CreateModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList( "ID",
"Name");
            ViewData["ExpirationID"] = new SelectList(_context.Set<Expiration>(), "ID",
"ExpirationProductName");
            var beauty = new Beauty();
            beauty.BeautyCategories = new List<BeautyCategory>();
            PopulateAssignedCategoryData(_context, beauty);
            return Page();
        }

        [BindProperty]
        public Beauty Beauty { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBeauty = Beauty;
            if (selectedCategories != null)
            {
                newBeauty.BeautyCategories = new List<BeautyCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BeautyCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBeauty.BeautyCategories.Add(catToAdd);
                }
            }
            
            _context.Beauty.Add(newBeauty);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, newBeauty);
            return Page();
        }
    }
}
