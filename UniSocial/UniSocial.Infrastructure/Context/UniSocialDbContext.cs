using Microsoft.EntityFrameworkCore;
using UniSocial.Domain.Entities;

namespace UniSocial.Infrastructure.Context
{
    public class UniSocialDbContext : DbContext
    {
        public UniSocialDbContext(DbContextOptions<UniSocialDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}
