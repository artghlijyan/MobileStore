using AspNetMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvc.DbRepo
{
    public class MobileContext: DbContext
    {

        DbSet<Phone> Phones { get; set; }
        DbSet<Order> Orders { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
