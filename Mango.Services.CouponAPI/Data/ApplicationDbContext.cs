using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(new Coupon { CouponId = 1, CouponCode = "10OFF", DiscountAmount = 10, MinAmount = 50 });
            modelBuilder.Entity<Coupon>().HasData(new Coupon { CouponId = 2, CouponCode = "20OFF", DiscountAmount = 20, MinAmount = 100 });
        }
    }

}
