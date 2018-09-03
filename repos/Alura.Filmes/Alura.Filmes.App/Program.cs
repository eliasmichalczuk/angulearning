using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using(var context = new AluraFilmesContexto())
            {
                context.LogSQLToConsole();
                //chama o metodo de logar o sql do entity
                foreach (var ator in context.Atores)
                {
                    System.Console.WriteLine($"ator: {ator}");
                }
            }
        }
    }
}