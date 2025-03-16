using Microsoft.EntityFrameworkCore;
namespace Restaurant_Management.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<booking> Booking { get; set; }
        public DbSet<AddtoCart> AddtoCart { get; set; }
        public DbSet<NewItems> NewItems { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
