using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataBaseContext;
using DatabaseEntityLib;

namespace ElektronskaUcionica.Pages.OblastiPage
{
    public class CreateModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public CreateModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Oblasti Oblasti { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Oblasti == null || Oblasti == null)
            {
                return Page();
            }

            _context.Oblasti.Add(Oblasti);
            await _context.SaveChangesAsync();

            return RedirectToPage("./oblast");
        }
    }
}
