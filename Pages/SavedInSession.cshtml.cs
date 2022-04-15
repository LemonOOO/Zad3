using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zad3.Models;
using Zad3.Pages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Zad3.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<string> list { get; set; }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                list = JsonConvert.DeserializeObject<List<string>>(Data);
                HttpContext.Session.SetString("Data", Data);
            }
        }
    }
}
