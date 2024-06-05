using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.CouponAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Coupon> Products { get; set; }
    }
}
