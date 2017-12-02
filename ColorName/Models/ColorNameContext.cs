using Microsoft.EntityFrameworkCore;

namespace ColorName.Models
{
    public class ColorNameContext : DbContext
    {
        public ColorNameContext(DbContextOptions<ColorNameContext> options) : base(options)
        {
        }

        public DbSet<NamedColor> NamedColors { get; set; }
    }
}