using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseEntityLib;
using DataBaseContext;

namespace ElektronskaUcionica.Pages.TestoviPage
{
    public class RezultatModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public RezultatModel(DB_Context_Class context)
        {
            _context = context;
        }

        public int? TacniOdgovori { get; set; }
        public int BrojPitanja { get; set; }

        public async Task OnGetAsync(int tacniOdgovori, int brojPitanja)
        {

                TacniOdgovori = tacniOdgovori;
            BrojPitanja = brojPitanja;
            
        
        }

        
    }
}
