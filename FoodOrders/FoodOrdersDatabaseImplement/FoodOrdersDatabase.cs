using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdersDatabaseImplement
{
    public class FoodOrdersDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-SINQU55\SQLEXPRESS;Initial Catalog=FoodOrdersDatabase3;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Dish> Dishes { set; get; }

        public virtual DbSet<DishComponent> DishComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Shop> Shops { set; get; }

        public virtual DbSet<ShopDish> ShopDishes { set; get; }

        public virtual DbSet<Client> Clients { set; get; }

        public virtual DbSet<Implementer> Implementers { set; get; }

        public virtual DbSet<MessageInfo> Messages { set; get; }
    }
}