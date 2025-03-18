using Commerce.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure
{
    public class CommerceDbContext: DbContext
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) : base(options) { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VV2TGRL;Database=Commerce;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DAO.Product>(product =>
                {
                    string tableName = "Products";
                    product.ToTable(tableName);
                    product.HasKey(p => p.Id).HasName("PK_Products");
                    product.HasIndex(p => p.Reference).IsUnique();
                    product.Property(p => p.Id).UseIdentityColumn();
                    product.Property(p => p.Reference).IsRequired();
                    product.Property(p => p.Price).HasColumnType("decimal(19,4)");
                }
            );
            modelBuilder.Entity<DAO.Customer>(customer =>
            {
                string tableName = "Customers";
                customer.ToTable(tableName);
                customer.HasKey(c => c.Id).HasName("PK_Customers");
                customer.Property(c => c.Id).UseIdentityColumn();

            }
            );
            modelBuilder.Entity<CartItem>(
                cartItem =>
                {
                    string tableName = "CartItems";
                    cartItem.ToTable(tableName);
                    cartItem.HasKey(c => c.Id).HasName("PK_CartItems");
                    cartItem.Property(ci => ci.Id).UseIdentityColumn();
                    cartItem.Property(ci => ci.Quantity).HasColumnType("decimal(19,4)");
                    cartItem.Property(ci => ci.Price).HasColumnType("decimal(19,4)");
                    cartItem.Navigation(ci => ci.Cart);
                    cartItem.HasOne<Product>().WithMany().HasForeignKey(ci => ci.ProductId).IsRequired();
                });
            modelBuilder.Entity<DAO.Cart>(
                cart =>
                {
                    string tableName = "Carts";
                    cart.ToTable(tableName);
                    cart.HasKey(c => c.Id).HasName("PK_Carts");
                    cart.Property(c => c.Id).UseIdentityColumn();
                    cart.Property(c => c.Price).HasColumnType("decimal(19,4)");
                    cart.HasOne<DAO.Customer>().WithMany().HasForeignKey(c => c.CustomerId).IsRequired();

                });
            modelBuilder.Entity<Order>(
                order =>
                {
                    string tableName = "Orders";
                    order.ToTable(tableName);
                    order.HasKey(o => o.Id).HasName("PK_Orders");
                    order.Property(c => c.Id).UseIdentityColumn();
                    order.Property(c => c.Status).HasColumnType("tinyint");
                    order.HasOne<DAO.Cart>().WithOne().HasForeignKey<Order>(o => o.CartId).IsRequired();
                });

        }

        public DbSet<DAO.Product> Products { get; set; }
        public DbSet<DAO.Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<DAO.Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
