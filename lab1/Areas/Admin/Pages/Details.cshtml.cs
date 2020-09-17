using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLabsV05.DAL.Data;
using WebLabsV05.Entities;

namespace lab1
{
    public class DetailsModel : PageModel
    {
        private readonly WebLabsV05.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WebLabsV05.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Auto Auto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Auto = await _context.Autos
                .Include(a => a.Group).FirstOrDefaultAsync(m => m.AutoId == id);

            if (Auto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
