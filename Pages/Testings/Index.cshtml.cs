using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Testings
{
    public class IndexModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public IndexModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        public IList<Testing> Testing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Testing != null)
            {
                Testing = await _context.Testing
                .Include(t => t.Beauty)
                .ThenInclude(b=>b.BeautyCategories)
                .Include(t => t.Tester).ToListAsync();
            }
        }
    }
}
