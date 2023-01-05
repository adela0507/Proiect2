using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Expirations
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public DetailsModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

      public Expiration Expiration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Expiration == null)
            {
                return NotFound();
            }

            var expiration = await _context.Expiration.FirstOrDefaultAsync(m => m.ID == id);
            if (expiration == null)
            {
                return NotFound();
            }
            else 
            {
                Expiration = expiration;
            }
            return Page();
        }
    }
}
