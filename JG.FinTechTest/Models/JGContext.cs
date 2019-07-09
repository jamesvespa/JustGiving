using Microsoft.EntityFrameworkCore;

namespace JustGivingApi.Models
{
    public interface IJustGivingContext
    {
        void AddItem(JustGivingItem item);
        int SaveChanges();
    }

    public class JustGivingContext : DbContext, IJustGivingContext
    {
        public JustGivingContext(DbContextOptions<JustGivingContext> options)
            : base(options)
        {
        }

        public virtual void AddItem(JustGivingItem item)
        {
            JGItems.Add(item);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<JustGivingItem> JGItems { get; set; }
    }
}
