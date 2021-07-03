using Microsoft.EntityFrameworkCore;
namespace SimpleLoginRegistration.Models
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options){}
        public DbSet<Registration>Users{get;set;}
    }
}