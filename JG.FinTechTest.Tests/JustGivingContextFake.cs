using JustGivingApi.Models;
using Microsoft.EntityFrameworkCore;

public class JustGivingContextFake : JustGivingContext
{
    int Id;
    public JustGivingContextFake(DbContextOptions<JustGivingContext> options)
    : base(options)
    {
        Id = 1;
    }

    public override void AddItem(JustGivingItem item)
    {
        item.Id = Id++;
    }

    public override int SaveChanges()
    {
        return 0;
    }
}
