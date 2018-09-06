using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1
{
    class Program
    {
        static void Main1(string[] args)
        {
            var generos = new List<Genero>
            {
                new Genero { Id = 1, Nome = "Rock" },
                new Genero { Id = 2, Nome = "Reggae" },
                new Genero { Id = 3, Nome = "Rock Progressivo" },
                new Genero { Id = 4, Nome = "Jazz" },
                new Genero { Id = 5, Nome = "Punk Rock" },
                new Genero { Id = 6, Nome = "Clássica" }
            };

            var query = from g in generos
                        where g.Nome.Contains("Rock")
                        select g;

            var query2 = from g in generos select g;

            foreach (var genero in query)
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            }

            List<Musica> musicas = new List<Musica>
            {
                new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
                new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2 },
                new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 6 }
            };

            Console.WriteLine();


            var musicaQuery
              = from m in musicas
                join g in generos on m.GeneroId equals g.Id
                select new { m, g };

            foreach (var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Nome, musica.m.Id, musica.g.Nome);
            }



            var q = from m in musicas where m.Nome.Contains("Shot") select m;

            var queryMusicas
                = from m in musicas
                  join g in generos on m.GeneroId equals g.Id
                  select new      //ao inves de select m,g  | select new objeto anonimo
                  {
                      MusicaId = m.Id,
                      Musica = m.Nome,
                      Genero = g.Nome
                  };

            //Crie uma consulta para listar os nomes das músicas cujo gênero tenha o nome "Reggae".
            var QRaggae = from m in musicas join g in generos on m.GeneroId equals g.Id 
                          where g.Nome.Contains("Reggae") select new { nome = m.Nome, genero = g.Nome };
            Console.WriteLine( "\n\nmusicas com genero reggae");
            foreach (var r in QRaggae)
            {
                Console.WriteLine($"Nome: {r.nome}, Genero: {r.genero}\n\n");
            }

            //Agora o resultado não fez muita diferença, porém ficou mais legível, o que é ótimo.
            //Podemos sempre transformar/projetar o resultado da nossa consulta da maneira que quisermos. O nome disso
            //é "Projeção de Dados" 

            //Agora varremos a nossa query, tabulando os dados conforme desejamos.

            foreach (var musicaEgenero in queryMusicas)
            {
                Console.WriteLine("{0}\t{1}\t{2}",
                    musicaEgenero.MusicaId,
                    musicaEgenero.Musica.PadRight(20),
                    musicaEgenero.Genero);
            }

            Console.ReadKey();
        }

        class Genero
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        class Musica
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int GeneroId { get; set; }
        }
    }

}
