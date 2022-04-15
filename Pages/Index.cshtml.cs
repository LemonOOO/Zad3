using Zad3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Zad3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public List<string>? list { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if (list == null)
            {
                list = new List<string>();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                
                if (FizzBuzz.getTypeOfYear())
                {
                    ViewData["Message"] = FizzBuzz.Name + " urodził się w " + FizzBuzz.Year + " roku. To był rok przestępny";
                    list.Add(FizzBuzz.Name + " urodził się w " + FizzBuzz.Year + " roku. To był rok przestępny");
                    ViewData["MessageClass"] = "success";
                }
                else
                {
                    ViewData["Message"] = FizzBuzz.Name + " urodził się w " + FizzBuzz.Year + " roku. To nie był rok przestępny";
                    list.Add(FizzBuzz.Name + " urodził się w " + FizzBuzz.Year + " roku. To nie był rok przestępny");
                    ViewData["MessageClass"] = "warning";
                }
                HttpContext.Session.SetString("Data",
                JsonConvert.SerializeObject(list));
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