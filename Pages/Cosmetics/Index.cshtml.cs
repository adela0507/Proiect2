using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Cosmetics
{
    public class IndexModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public IndexModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        public IList<Beauty> Beauty { get;set; } = default!;
        public BeautyData BeautyD { get; set; }
        public int BeautyID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BeautyD = new BeautyData();

            BeautyD.Cosmetics = await _context.Beauty
            .Include(b => b.Brand)
            .Include(b => b.Expiration)
            .Include(b => b.BeautyCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                BeautyID = id.Value;
                Beauty beauty = BeautyD.Cosmetics
                .Where(i => i.ID == id.Value).Single();
                BeautyD.Categories = beauty.BeautyCategories.Select(s => s.Category);
            }
        }
    }
}
