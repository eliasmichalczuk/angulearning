using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alura.Filmes.App
{
    class ProgramParaFilmes
    {
        static void Main3(string[] args)
        {
            
            using(var context = new AluraFilmesContexto())
            {
                context.LogSQLToConsole();

                //foreach(var filme in context.Filmes)
                //{
                //    Console.WriteLine(filme);
                //}


                //foreach (var elenco in context.Elenco)
                //{
                //    var entidade = context.Entry(elenco);
                //    var filmid = entidade.Property("film_id").CurrentValue;
                //    var actorid = entidade.Property("actor_id").CurrentValue;
                //    var lastUp = entidade.Property("last_update").CurrentValue;


                //    Console.WriteLine(elenco);
                //    Console.WriteLine($"Filme {filmid}, Ator {actorid}, lastup {lastUp}");
                //}

                var filme = context.Filmes
                    .Include(f => f.Atores)//join com tabela atores
                    .ThenInclude(fa => fa.Ator)
                    .First();
                //aqui foi apenas criado lista de atores em filme, nao foi criado lista de filme em atores
                //assim o ef core implicita que é relacionamento de muitos para 1
                //ao inves de n pra n
                //cria shadow property para 1 filme
                //necessario criarlista de filmeAtor 


                Console.WriteLine("Elenco: ");
                foreach(var ator in filme.Atores)
                {
                    Console.WriteLine(ator.Ator);
                }
            }
        }
    }

    //this
    //modelBuilder.Entity<Raca>()
    //.ToTable("lotr_races");

    //modelBuilder.Entity<Raca>()
    //.Property(r => r.Id)
    //.HasColumnName("race_id");

    //modelBuilder.Entity<Raca>()
    //.Property(r => r.Nome)
    //.HasColumnName("race_name")
    //.IsRequired();

    //same as this
    //[Table("lotr_races")]
    //public class Raca
    //{
    //    [Column("race_id")]
    //    public int Id { get; set; }
    //    [Required]
    //    [Column("race_name", TypeName = "varchar(60)")]
    //    public string Nome { get; set; }
    }