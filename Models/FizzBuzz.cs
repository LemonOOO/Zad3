using System.ComponentModel.DataAnnotations;
namespace Zad3.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}."), Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int? Number { get; set; }
        public (string, string) getOutput()
        {
            string outMessage = "FizzBuzz";
            string outMethod = "success";
            if (Number % 3 == 0 && Number % 5 == 0)
            {
                return (outMessage, outMethod);
            }
            else if (Number % 3 == 0)
            {
                outMessage = "Fizz";
                outMethod = "success";
                return (outMessage, outMethod);
            }
            else if (Number % 5 == 0)
            {
                outMessage = "Buzz";
                outMethod = "success";
                return (outMessage, outMethod);
            }
            else
            {
                outMessage = ("Liczba: " + Number + " nie spełnia kryteriów FizzBuzz");
                outMethod = "warning";
                return (outMessage, outMethod);
            }

        }
    }
}