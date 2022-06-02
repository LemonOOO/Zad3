using Zad3.Models;
using Zad3.ViewModels;
    
namespace Zad3.Interfaces
{
    
    public interface IFizzBuzzService
    {
        public List<ListViewModel> GetEntriesFromToday();
        public List<ListViewModel> GetAllEntries();
        public void AddEntry(FizzBuzz newItem);
        
    }
}
