﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public DetailsModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

      public Testing Testing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Testing == null)
            {
                return NotFound();
            }

            var testing = await _context.Testing.FirstOrDefaultAsync(m => m.ID == id);
            if (testing == null)
            {
                return NotFound();
            }
            else 
            {
                Testing = testing;
            }
            return Page();
        }
    }
}
