using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.OrderAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<OrderDetail> Details { get; set;}
        public DbSet<OrderHeader> Headers { get; set;}
        
    }
}
