using Microsoft.EntityFrameworkCore;

namespace JustGivingApi.Models
{
    public class JustGivingContext : DbContext
    {
        public JustGivingContext(DbContextOptions<JustGivingContext> options)
            : base(options)
        {
        }

        public DbSet<JustGivingItem> JGItems { get; set; }

    }
}
