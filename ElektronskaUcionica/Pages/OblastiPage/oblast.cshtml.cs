using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;

using DatabaseEntityLib;

namespace ElektronskaUcionica.Pages.PredmetiPage
{
    public class LukaModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public LukaModel(DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Oblasti> Oblasti { get; set; }

        public async Task OnGetAsync()
        {
            Oblasti = await _context.Oblasti.ToListAsync();
        }
    }
}
