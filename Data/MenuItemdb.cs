using DERrestaurant3.Models;
using Microsoft.EntityFrameworkCore;

namespace DERrestaurant3.Data
{
    public class MenuItemdb : DbContext
    {
        public MenuItemdb(DbContextOptions<MenuItemdb> options) : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }

    }
}
