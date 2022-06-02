using Zad3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zad3.ViewModels;
using Zad3.Interfaces;

namespace Zad3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFizzBuzzService _FizzBuzzService;
        public List<ListViewModel> List;
        public ListViewModel ListViewModel;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public List<string>? list { get; set; }
        
        public IndexModel(ILogger<IndexModel> logger, IFizzBuzzService service)
        {
            _FizzBuzzService = service;
            _logger = logger;
        }


        public void OnGet()
        {
            List = _FizzBuzzService.GetEntriesFromToday();
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
                _FizzBuzzService.AddEntry(FizzBuzz);
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