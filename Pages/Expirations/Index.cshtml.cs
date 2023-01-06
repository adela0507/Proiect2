using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;
using Proiect2.Models.ViewModels;

namespace Proiect2.Pages.Expirations
{
    public class IndexModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public IndexModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        public IList<Expiration> Expiration { get; set; } = default!;

        public ExpirationIndexData ExpirationData { get; set; }
        public int ExpirationID { get; set; }
        public int BeautyID { get; set; }
        public async Task OnGetAsync(int? id, int? beautyID)
        {
            ExpirationData = new ExpirationIndexData();
            ExpirationData.Expirations = await _context.Expiration
                   .Include(i => i.Cosmetics)
                   .ThenInclude(c => c.BeautyCategories)
                   .OrderBy(i => i.ExpirationProductName)
                   .ToListAsync();
            if (id != null)
            {
                ExpirationID = id.Value;
                Expiration expiration = ExpirationData.Expirations
                .Where(i => i.ID == id.Value).Single();
                ExpirationData.Cosmetics = expiration.Cosmetics;
            }
        }
    }
}
