using Zad3.Models;
using Zad3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Zad3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public List<string>? list { get; set; }
        private readonly FizzBuzzContext _context;
        public IList<FizzBuzz> FizzBuzzData { get; set; }
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            FizzBuzzData = _context.FizzBuzz.ToList();
        }
        public IActionResult OnPost()
        {
            if (list == null)
            {
                list = new List<string>();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            FizzBuzz.Date = DateTime.Now;
            FizzBuzz.Result = " ";
            if (ModelState.IsValid)
            {
                
                if (FizzBuzz.getTypeOfYear())
                {
                    ViewData["Message"] = FizzBuzz.Name + " " + FizzBuzz.LastName + " urodził się w " + FizzBuzz.Year + " roku. To był rok przestępny";
                    FizzBuzz.Result = FizzBuzz.Name + " " + FizzBuzz.LastName + " urodził się w " + FizzBuzz.Year + " roku. To był rok przestępny";
                    list.Add(FizzBuzz.Name + " " + FizzBuzz.LastName + " urodził się w " + FizzBuzz.Year + " roku. To był rok przestępny");
                    ViewData["MessageClass"] = "success";
                }
                else
                {
                    ViewData["Message"] = FizzBuzz.Name + " " + FizzBuzz.LastName + " urodził się w " + FizzBuzz.Year + " roku. To nie był rok przestępny";
                    FizzBuzz.Result = FizzBuzz.Name + " " + FizzBuzz.LastName + " urodził się w " + FizzBuzz.Year + " roku. To nie był rok przestępny";
                    list.Add(FizzBuzz.Name + " " + FizzBuzz.LastName + " urodził się w " + FizzBuzz.Year + " roku. To nie był rok przestępny");
                    ViewData["MessageClass"] = "warning";
                }
                HttpContext.Session.SetString("Data",
                JsonConvert.SerializeObject(list));
                _context.FizzBuzz.Add(FizzBuzz);
                _context.SaveChanges();
            }
            else
            {
                ViewData["Message"] = "ModelState.IsValid jest == false *** " + errors;
                ViewData["MessageClass"] = "warning";
            }
            return Page();
        }
    }
}