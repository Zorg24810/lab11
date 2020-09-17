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
    public class IndexModel : PageModel
    {
        private readonly WebLabsV05.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebLabsV05.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Auto> Auto { get;set; }

        public async Task OnGetAsync()
        {
            Auto = await _context.Autos
                .Include(a => a.Group).ToListAsync();
        }
    }
}
