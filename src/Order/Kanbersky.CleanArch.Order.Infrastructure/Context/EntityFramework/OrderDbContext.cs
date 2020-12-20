using Microsoft.EntityFrameworkCore;

namespace Kanbersky.CleanArch.Order.Infrastructure.Context.EntityFramework
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Order> Orders { get; set; }
    }
}
