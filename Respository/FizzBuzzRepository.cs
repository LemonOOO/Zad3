using Zad3.Data;
using Zad3.Models;
using Zad3.Interfaces;
using Zad3.Respository;

namespace Zad3.Respository
{
    public class FizzBuzzRepository : IFizzBuzzRepository
    {
        private readonly FizzBuzzContext _context;
        public FizzBuzzRepository(FizzBuzzContext context)
        {
            _context = context;
        }

        public IQueryable<FizzBuzz> GetAllEntries()
        {
            return _context.FizzBuzz;
        }

        public void AddToRepo(FizzBuzz fizzBuzz)
        {
            _context.FizzBuzz.Add(fizzBuzz);
            _context.SaveChanges();
        }
    }
    
}
