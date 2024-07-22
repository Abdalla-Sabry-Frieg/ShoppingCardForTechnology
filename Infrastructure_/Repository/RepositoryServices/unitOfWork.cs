using Domin.Models;
using Infrastructure_.DataBase;
using Infrastructure_.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.Repository.RepositoryServices
{
    public class unitOfWork : IUnitOfWork
    {
        private readonly ShoppingCardDbContext _context;

        public unitOfWork(ShoppingCardDbContext context)
        {
            _context = context;
            Categories = new Repository<Category>(_context);
            Items = new Repository<Item>(_context);
            ItemsTypes = new Repository<ItemType>(_context);
            Orders = new Repository<Order>(_context);
            OrderItems = new Repository<OrderItem>(_context);
            Carts = new Repository<Cart>(_context);
            CartItems = new Repository<CartItem>(_context);
            Address = new Repository<Address>(_context);
            subCategories= new Repository<subCategory>(_context);
        }
        public IRepository<Category> Categories { get; private set; }

        public IRepository<Item> Items { get; private set; }

        public IRepository<ItemType> ItemsTypes { get; private set; }

        public IRepository<Order> Orders { get; private set; }

        public IRepository<OrderItem> OrderItems { get; private set; }

        public IRepository<Cart> Carts  { get; private set; }

        public IRepository<CartItem> CartItems { get; private set; }

        public IRepository<Address> Address { get; private set; }

        public IRepository<subCategory> subCategories { get; private set; }

        public int commitChanges()
        {
          return _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
