using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;

using DatabaseEntityLib;

namespace ElektronskaUcionica.Pages.PredmetiPage
{
    public class PitanjeModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public PitanjeModel(DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Predmeti> Predmeti { get; set; }

        public async Task OnGetAsync()
        {
            Predmeti = await _context.Predmeti.ToListAsync();
        }
    }
}
