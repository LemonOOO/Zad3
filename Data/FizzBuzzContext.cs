using Zad3.Models;
using Microsoft.EntityFrameworkCore;
namespace Zad3.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext (DbContextOptions options) : base(options) { }
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}
