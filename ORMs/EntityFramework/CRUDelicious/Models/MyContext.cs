using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options){}
        public DbSet<Dish>Dishes{get;set;}
    }
}