using Zad3.Models;

namespace Zad3.Interfaces
{
    public interface IFizzBuzzRepository
    {
        void AddToRepo(FizzBuzz fizzBuzz);
        IQueryable<FizzBuzz> GetAllEntries();
    }
}
