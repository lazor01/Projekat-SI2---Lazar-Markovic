using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace ElektronskaUcionica.Pages.TestoviPage
{
    public class TestModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public TestModel(DB_Context_Class context)
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
