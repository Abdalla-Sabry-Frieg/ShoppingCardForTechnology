using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable 
    {
        IRepository<Category> Categories { get; }
        IRepository<Item> Items { get; }
        IRepository<ItemType> ItemsTypes { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Cart> Carts { get; }
        IRepository<CartItem> CartItems { get; }
        IRepository<Address> Address { get; }
        IRepository<subCategory> subCategories { get; }


        int commitChanges();
    }
}
