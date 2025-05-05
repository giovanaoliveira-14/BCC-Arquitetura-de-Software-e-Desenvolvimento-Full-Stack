using Microsoft.EntityFrameworkCore;
using MessageReceiverAPI.Models;

namespace MessageReceiverAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<GenericData> GenericData => Set<GenericData>();
}
