using Zad3.Interfaces;
using Zad3.Models;
using Zad3.ViewModels;

namespace Zad3.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IFizzBuzzRepository _FizzBuzzRepo;
        public FizzBuzzService(IFizzBuzzRepository FizzBuzzRepo)
        {
            _FizzBuzzRepo = FizzBuzzRepo;
        }

        public List<ListViewModel> GetAllEntries()
        {
            var EntriesList = _FizzBuzzRepo.GetAllEntries();
            List<ListViewModel> Data = new List<ListViewModel>();
            foreach (var entry in EntriesList)
            {
                var VM = new ListViewModel()
                {
                    Id = entry.Id,
                    FullName = entry.Name + " " + entry.LastName,
                    Year = entry.Year,
                    Date = entry.Date,
                    Result = entry.Result,
                };
                Data.Add(VM);
            }
            return Data;
        }
        public void AddEntry(FizzBuzz newItem)
        {
            _FizzBuzzRepo.AddToRepo(newItem);
        }
        public List<ListViewModel> GetEntriesFromToday()
        {
            var EntriesList = _FizzBuzzRepo.GetAllEntries().Where(item => 
                item.Date.Date == DateTime.Today
            );
            List<ListViewModel> Data = new List<ListViewModel>();
            foreach (var entry in EntriesList)
            {
                var VM = new ListViewModel()
                {
                    Id = entry.Id,
                    FullName = entry.Name + " " + entry.LastName,
                    Year = entry.Year,
                    Date = entry.Date,
                    Result = entry.Result,
                };
                Data.Add(VM);
            }
            return Data;
        }
    }
}
