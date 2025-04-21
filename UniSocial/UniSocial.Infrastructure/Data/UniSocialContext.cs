using Microsoft.EntityFrameworkCore;
using UniSocial.Domain.Entities;

namespace UniSocial.Infrastructure.Context
{
    public class UniSocialContext : DbContext
    {
        public UniSocialContext(DbContextOptions<UniSocialContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Bloqueio> Bloqueios { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Seguidores)
                .WithMany()
                .UsingEntity(j => j.ToTable("UsuarioSeguidores"));

            modelBuilder.Entity<Curtida>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comentario>()
                .HasKey(c => c.Id);
        }
    }
}
