namespace WarehouseApp.Data
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Приклад початкових даних (необов'язково, але корисно для тестування)
            // modelBuilder.Entity<Product>().HasData(
            //     new Product { Id = 1, Name = "Ноутбук Dell", Quantity = 10, UnitOfMeasure = "шт." },
            //     new Product { Id = 2, Name = "Мишка Logitech", Quantity = 50, UnitOfMeasure = "шт." }
            // );
        }
    }

}
