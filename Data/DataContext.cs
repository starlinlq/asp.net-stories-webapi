using asp.net.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.net.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters {get;set;}
    }
}