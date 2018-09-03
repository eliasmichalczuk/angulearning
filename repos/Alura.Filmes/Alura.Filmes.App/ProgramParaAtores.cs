using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alura.Filmes.App
{
    class ProgramParaAtores
    {
        static void Main2(string[] args)
        {
            
            using(var context = new AluraFilmesContexto())
            {
                context.LogSQLToConsole();
                //chama o metodo de logar o sql do entity
                //foreach (var ator in context.Atores)
                //{
                //    System.Console.WriteLine($"ator: {ator}");
                //}
                var ator = new Ator();
                ator.PrimeiroNome = "Tom";
                ator.UltimoNome = "Hanks";
                //como setar valor de uma shaddow property se nao é definido no builder
                //context.Entry(actor).Property("last_update").CurrentValue = DateTime.Now;
                context.Atores.Add(ator);
                context.SaveChanges();
                //recuperar valores de shadow properties
                Console.WriteLine(context.Entry(ator).Property("last_update"));

                //listar os dez primeiros atores ordenados por last update de forma decrescente
                var atores = context.Atores//query em cima do conjunto de atores
                    .OrderByDescending(a => EF.Property<DateTime>(a, "last_update"))
                    .Take(10);
                foreach(var ator1 in atores)
                {
                    Console.WriteLine(ator1 + " " + context.Entry(ator1).Property("last_update").CurrentValue);
                }
                //para atribuir:
                //contexto.Entry(aluno)
                //    .Property("nota_inicial")
                //    .CurrentValue = 8;

                //para recuperar:
                //var nota = contexto.Entry(aluno)
                //    .Property("nota_inicial")
                //    .CurrentValue;


            }
        }
    }
}