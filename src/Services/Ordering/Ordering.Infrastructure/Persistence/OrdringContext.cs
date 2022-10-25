using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entites;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrdersDetails { get; set; } = null!;
    }
}
