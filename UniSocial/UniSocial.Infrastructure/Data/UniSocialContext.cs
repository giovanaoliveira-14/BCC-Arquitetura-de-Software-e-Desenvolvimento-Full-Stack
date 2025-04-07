using Microsoft.EntityFrameworkCore;
using UniSocial.Domain.Entities;

namespace UniSocial.Infrastructure.Data
{
    public class UniSocialContext : DbContext
    {
        public UniSocialContext(DbContextOptions<UniSocialContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }       // <-- ADICIONA ESSA LINHA
        public DbSet<Comentario> Comentarios { get; set; } // <-- E ESSA TAMBÉM

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento de seguidores (auto-relacionamento muitos-para-muitos)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Seguidores)
                .WithMany()
                .UsingEntity(j => j.ToTable("UsuarioSeguidores"));

            // Curtidas
            modelBuilder.Entity<Curtida>()
                .HasKey(c => c.Id);

            // Comentários
            modelBuilder.Entity<Comentario>()
                .HasKey(c => c.Id);
        }
    }
}
