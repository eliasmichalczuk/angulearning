using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    class FilmeCategoriaConfiguration : IEntityTypeConfiguration<FilmeCategoria>
    {
        public void Configure(EntityTypeBuilder<FilmeCategoria> builder)
        {
            builder.ToTable("film_category");

            builder.Property<int>("film_id").IsRequired();//nao precisa required pois int nao  
            builder.Property<byte>("category_id").IsRequired(); //aceita valor nulo, mas fazer o que ne

            builder.Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getDate()");

            builder.HasKey("film_id", "category_id");

            builder
                .HasOne(fc => fc.Filme)
                .WithMany(f => f.Categorias)
                .HasForeignKey("filme_id");
            builder
                .HasOne(fc => fc.Categoria)
                .WithMany(c => c.Filmes)
                .HasForeignKey("category_id");

        }
    }

    //exercicio alura
    //public class Produto
    //{
    //    public int Id { get; set; }
    //    public string Nome { get; set; }
    //    public double Preco { get; set; }
    //    public Categoria Categoria { get; set; }
    //}

    //public class Categoria
    //{
    //    public int Id { get; set; }
    //    public string Descricao { get; set; }
    //}

    //public class LojaContexto : DbContext
    //{
    //    public DbSet<Produto> Produtos { get; set; }
    //    public DbSet<Categoria> Categorias { get; set; }

    //    //...outros códigos aqui
    //}
    //    O Entity vai reconhecer um relacionamento entre Produto e 
    //        Categoria do tipo 1 categoria para N produtos. S

    //O Entity vai criar implicitamente uma shadow property chamada 
    //            CategoriaId no mapeamento de produtos. S
}
