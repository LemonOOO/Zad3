using System.ComponentModel.DataAnnotations;
namespace Zad3.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Imię")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "W imieniu powinny być tylko litery")]
        [StringLength(100, ErrorMessage = "Maksymalna długość to 100")]
        [Required(ErrorMessage = "Pole jest obowiązkowe!")]
        public string? Name { get; set; }
        
        [Display(Name = "Rok urodzenia")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        [Required(ErrorMessage = "Pole jest obowiązkowe!")]
        public int? Year { get; set; }

        public bool getTypeOfYear()
        {
            if (Year % 4 == 0 && (Year % 100 != 0 || Year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}