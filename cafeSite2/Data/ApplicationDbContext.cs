using cafeSite2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cafeSite2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<menus> Menus { get; set; }
        public DbSet<rezervasyon> rezervasyon { get; set; }
        public DbSet<Galeri> Galleri { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<blog> Blog { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<iletisim> iletisim { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }






    }
}
