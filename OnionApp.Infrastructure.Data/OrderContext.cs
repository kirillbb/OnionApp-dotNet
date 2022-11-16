using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Core;

namespace OnionApp.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
