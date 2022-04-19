using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zad3.Models;
using Zad3.Data;

namespace Zad3.Pages
{
    public class LastCheckedModel : PageModel
    {
        private readonly ILogger<LastCheckedModel> _logger;
        private readonly FizzBuzzContext _context;

        public IList<FizzBuzz> FizzBuzzD { get; set; }
        public FizzBuzz FizzBuzz { get; set; }
        public LastCheckedModel(ILogger<LastCheckedModel> logger,  FizzBuzzContext context)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            if (_context != null)
            {
                FizzBuzzD = _context.FizzBuzz.OrderByDescending(x => x.Date).Take(20).ToList();
            }
        }
        public IActionResult OnPostAsync(int id)
        {
            FizzBuzz = _context.FizzBuzz.Find(id);
            if (FizzBuzz != null)
            {
                _context.FizzBuzz.Remove(FizzBuzz);
                _context.SaveChanges();
            }
            if (_context != null)
            {
                FizzBuzzD = _context.FizzBuzz.OrderByDescending(x => x.Date).Take(20).ToList();
            }
            return Page();
        }
    }
}
