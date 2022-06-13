using System.ComponentModel.DataAnnotations;

namespace Zad3.ViewModels
{
    public class ListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Imię i nazwisko")]
        public string FullName { get; set; }

        [Display(Name = "Rok")]
        public int Year { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime Date { get; set; }

        [Display(Name = "Wynik")]
        public string? Result { get; set; }
        public int? UserId { get; internal set; }
    }
}
