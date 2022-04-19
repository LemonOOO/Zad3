using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zad3.Models;
using Zad3.Data;

namespace Zad3.Pages
{
    public class LastCheckedModel : PageModel
    {
        private readonly FizzBuzzContext _context;
        public IList<FizzBuzz> FizzBuzz { get; set; }
        

        public void OnGet()
        {
            if (_context != null)
            {
                FizzBuzz = _context.FizzBuzz.ToList();
            }
        }
    }
}
