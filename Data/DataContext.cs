using asp.net.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.net.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //this is how we tell entity how to set up our db

        public DbSet<Character> Characters {get;set;}
    }
}