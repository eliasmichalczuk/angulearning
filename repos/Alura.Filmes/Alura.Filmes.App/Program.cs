using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {

                contexto.LogSQLToConsole();

                //var ator1 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                //var ator2 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                //contexto.Atores.AddRange(ator1, ator2);
                //contexto.SaveChanges();
                //objetivo é não ser possível adicionar dois atores com mesmo nome
                //utilizando alternate key no ator config

                var emmaWatson = contexto.Atores
                    .Where(a => a.PrimeiroNome == "Emma" && a.UltimoNome == "Watson");
                Console.WriteLine($"Total de atores encontrados: {emmaWatson.Count()}.");

                contexto.LogSQLToConsole();

                var idioma = new Idioma { Nome = "English" };

                var filme = new Filme();
                    filme.Titulo = "Cassino Royale";
                    filme.Duracao = 120;
                    filme.AnoLancamento = "2000";
                    filme.Classificacao = ClassificacaoIndicativa.MaioresQue14;
                    filme.IdiomaFalado = idioma;
                    contexto.Entry(filme).Property("last update").CurrentValue = DateTime.Now;
                //objetivo é nao ser possível adicionar filme com classificao com string qualquer
                var filmess = contexto.Filmes.First(f => f.Titulo == "Cassino Royale");
                Console.WriteLine(filmess.Classificacao.ParaString());

                //teste de conversao de e para enumerados
                var m10 = ClassificacaoIndicativa.MaioresQue18;
                Console.WriteLine(m10.ParaString());

                Console.WriteLine("G".ParaValor());
            }

            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                Console.WriteLine("Clientes");
                foreach (var cliente in contexto.Clientes)
                {
                    Console.WriteLine(cliente);
                }

                Console.WriteLine("\nFuncionários");
                foreach (var func in contexto.Funcionarios)
                {
                    Console.WriteLine(func);
                }
            }

            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                var atoresMaisAtuantes = contexto.Atores
                                        .Include(a => a.Filmografia)
                                        .OrderByDescending(a => a.Filmografia.Count)
                                        .Take(5);

                var sql = @"select top 5 a.first_name, a.last_name, count(*) as total
                            from actor a
                                inner join film_actor fa on fa.actor_id = a.actor_id
                            group by a.first_name, a.last_name
                            order by total desc";
                atoresMaisAtuantes = contexto.Atores.FromSql(sql);

                foreach (var ator in atoresMaisAtuantes)
                {
                    Console.WriteLine($"{ator.PrimeiroNome} {ator.Filmografia} filmes");
                }
            }
        }
    }
    
}
