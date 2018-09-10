using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    class AluraFilmesContexto : DbContext
    {//o nome escolhido na propriedade será o nome da coluna
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<FilmeAtor> Elenco { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FilmeCategoria> FilmeCategoria { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)mssqllocaldb;Database=AluraFilmesTST;Trusted_connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //representa o mapeamento
        {//fluent api
            modelBuilder.ApplyConfiguration(new AtorConfiguration());
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
            modelBuilder.ApplyConfiguration(new FilmeAtorConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new FilmeCategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new IdiomaConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());



            //modelBuilder.Entity<Ator>()
            //    .ToTable("actor");
            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.Id)
            //    .HasColumnName("actor_id");
            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.PrimeiroNome)
            //    .HasColumnName("first_name")
            //    .HasColumnType("varchar(45)")
            //    .IsRequired();
            ////isola toda a configuração no OnModelCreating
            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.UltimoNome)
            //    .HasColumnName("last_name")
            //    .HasColumnType("varchar(45)")
            //    .IsRequired();
            ////shadow property, nao aparece na camada de negocio
            //modelBuilder.Entity<Ator>()
            //    .Property<DateTime>("last_update")
            //    .HasColumnType("datetime")
            //    .HasDefaultValueSql("getDate()");
            //nao aceita null tambem

            // todo o codigo acima foi jogado em AtorConfiguration

            //modelBuilder.Entity<Filme>()
            //    .ToTable("film");
            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Id)
            //    .HasColumnName("filme_id");
            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Titulo)
            //    .HasColumnName("title")
            //    .HasColumnType("varchar(255)")
            //    .IsRequired();
            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Descricao)
            //    .HasColumnName("description")
            //    .HasColumnType("text");
            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.AnoLancamento)
            //    .HasColumnName("release_year")
            //    .HasColumnType("varchar(4)");
            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Duracao)
            //    .HasColumnType("short")
            //    .HasColumnName("length");
            //modelBuilder.Entity<Filme>()
            //    .Property<DateTime>("last_update")
            //    .HasColumnType("datetime")
            //    .HasDefaultValueSql("getDate()")
            //    .IsRequired();
        }
    }
}
