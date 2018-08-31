using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;
using YouLearn.Infra.Persistencia.EF.Map;
using YouLearn.Shared;

namespace YouLearn.Infra.Persistencia.EF
{
    public class YouLearnContext : DbContext
    {
        public DbSet<Canal> Canais { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Video> Videos  { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ignorar classes
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Nome>();
            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapCanal());
            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapVideo());
            modelBuilder.ApplyConfiguration(new MapPlayList());
            base.OnModelCreating(modelBuilder);
        }
    }
}
