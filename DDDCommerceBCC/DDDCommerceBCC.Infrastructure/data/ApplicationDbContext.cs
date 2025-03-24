using Microsoft.EntityFrameworkCore;
using DDDCommerceBCC.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Pedido> Pedidos { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseMySql(
    //             "Server=localhost;Database=ECommerceDB;User=root;Password=;", 
    //             new MySqlServerVersion(new Version(8, 0, 32))
    //         );
    //     }
    // }

}
