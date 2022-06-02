using Microsoft.AspNetCore.Mvc.RazorPages;
using Zad3.Models;
using Zad3.Interfaces;
using Zad3.ViewModels;

namespace Zad3.Pages
{
    public class LastCheckedModel : PageModel
    {
        private readonly ILogger<LastCheckedModel> _logger;
        private readonly IFizzBuzzService _FizzBuzzService;
        public List<ListViewModel> List;

        public IList<FizzBuzz> FizzBuzzD { get; set; }
        public FizzBuzz FizzBuzz { get; set; }
        public LastCheckedModel(ILogger<LastCheckedModel> logger,  IFizzBuzzService service)
        {
            _FizzBuzzService = service;
            _logger = logger;
        }

        public void OnGet()
        {
            List = _FizzBuzzService.GetAllEntries();
        }
    }
}
