using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    internal class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> builder)
        {
            builder
                .ToTable("language");
            builder
                .Property(i => i.Id)
                .HasColumnName("language_id");
            builder
                .Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(20)")
                .IsRequired();
            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getDate()")
                .IsRequired();
        }
    }
}