using DomainModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase
{
    public class ShoppingCardDbContext : DbContext
    {
        public ShoppingCardDbContext(DbContextOptions<ShoppingCardDbContext> options ) : base(options)
        {
        }
         
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> itemTypes { get; set; }  
        public DbSet<Order> orders   { get; set; }  
        public DbSet<OrderItem> orderItems   { get; set; }  
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> cartItems  { get; set; }
        public DbSet<PaymentDetails> paymentDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            //builder.Entity<Item>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            //builder.Entity<ItemType>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            //builder.Entity<Order>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            //builder.Entity<OrderItem>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            builder.Entity<Cart>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            //builder.Entity<CartItem>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            //builder.Entity<PaymentDetails>().Property(x => x.Id).HasDefaultValueSql("(newid())");
            //builder.Entity<Address>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        }


    }
}
