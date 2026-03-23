using Microsoft.EntityFrameworkCore;
using GFDWeb.Models; // Models klasöründeki tablolarımıza erişmek için

namespace GFDWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}