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
    public class RandomModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public RandomModel(DB_Context_Class context)
        {
            _context = context;
        }

        [BindProperty]
        public List<int> PitanjaIDs { get; set; }

        public List<Zadaci> Pitanja { get; set; }

        public int? TacniOdgovori { get; set; }
        public int BrojPitanja { get; set; }

        public async Task OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                var predmet = await _context.Predmeti.Include(p => p.pitanje).FirstOrDefaultAsync(p => p.ID == id);
                if (predmet != null && predmet.pitanje.Any())
                {
                    Pitanja = predmet.pitanje.OrderBy(_ => Guid.NewGuid()).Take(3).ToList();
                }
            }


        }

        public IActionResult OnPost(Dictionary<int, string> Odgovori)
        {
            if (Odgovori != null && Odgovori.Any())
            {
                var pitanjaIDs = Odgovori.Keys.ToList();

                if (pitanjaIDs != null)
                {
                 
                    int tacniOdgovori = 0;

                    foreach (var pitanjeID in pitanjaIDs)
                    {
                        Odgovori.TryGetValue(pitanjeID, out var odgovorKorisnika);
                        if (ProveriTacnostOdgovora(pitanjeID, odgovorKorisnika))
                        {
                            tacniOdgovori++;
                        }
                    }

                    TacniOdgovori = tacniOdgovori;
                    BrojPitanja = pitanjaIDs.Count;
                }


                return RedirectToPage("./Rezultat", new { tacniOdgovori=TacniOdgovori, brojPitanja=BrojPitanja });
            }
            else
            {
                
                return RedirectToPage("./Neuspeh");
            }


        }
        private bool ProveriTacnostOdgovora(int pitanjeID, string odgovorKorisnika)
        {
            var pravilanOdgovor = _context.Zadaci
                .Where(z => z.ID == pitanjeID)
                .Select(z => z.Odgovor)
                .FirstOrDefault();

            if (pravilanOdgovor == null)
                return false;

            return odgovorKorisnika?.Trim().ToLower() == pravilanOdgovor.Trim().ToLower();
        }

    }
}
