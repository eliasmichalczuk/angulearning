using AluraTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes
{
    class Program3
    {
        public static void Main(string[] args)
        {
            //necessário criar contexto pos esta usando ef

            using (var context = new AluraTunesServiceEntities())
            {
                var q = from g in context.Genero
                        select g;

                foreach (var g in q)
                {
                    Console.WriteLine($"{g.GeneroId}, {g.Nome}");
                }

                var feixaEGenero = from g in context.Genero
                                   join f in context.Faixa
                                   on g.GeneroId equals f.GeneroId
                                   select new { f, g };//trazendo muitos resultados
                feixaEGenero = feixaEGenero.Take(10);

                context.Database.Log = Console.WriteLine;

                foreach (var i in feixaEGenero)
                {
                    Console.WriteLine($"{i.f.Nome}, {i.g.Nome}");

                }

            }
            using (var contexto = new AluraTunesServiceEntities())
            {
                var query = from a in contexto.Artista
                            join alb in contexto.Album
                                on a.ArtistaId equals alb.ArtistaId
                            where a.Nome.Contains("Led")
                            select new
                            {
                                NomeArtista = a.Nome,
                                NomeAlbum = alb.Titulo

                            };

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
                }
                var query2 = from alb in contexto.Album
                             where alb.Artista.Nome.Contains("Led") //não é necessário usar join pois o ef identifica FK
                             select new
                             {
                                 NomeArtista = alb.Artista.Nome,
                                 NomeAlbum = alb.Titulo
                             };

                Console.WriteLine();
                foreach (var album in query2)
                {
                    Console.WriteLine("{0}\t{1}", album.NomeArtista, album.NomeAlbum);
                }

                //count por metodo e linq
                var q = from f in contexto.Faixa
                        where f.Album.Artista.Nome == "Led Zeppelin"
                        select f;

                var qq = contexto.Faixa.Count(x => x.Album.Artista.Nome.Equals("Led Zeppelin"));

                //consulta que calcule o total de vendas de um determinado artista.

                var newq = from inf in contexto.ItemNotaFiscal
                           where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                           select new
                           {
                               totalItem = inf.Quantidade * inf.PrecoUnitario
                           };
                var totalDoArtista = newq.Sum(a => a.totalItem);

                var newwq = from inf in contexto.ItemNotaFiscal
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            group inf by inf.Faixa.Album into agrupado
                            let vendasPorAlbum = agrupado.Sum(a => a.Quantidade * a.PrecoUnitario)
                            orderby vendasPorAlbum
                            descending
                            select new
                            {
                                TituloDoAlbum = agrupado.Key.Titulo,
                                TotalPorAlbum = vendasPorAlbum
                            };
                foreach (var agrupado in newwq)
                {

                    Console.WriteLine("{0}\t{1}",
                        agrupado.TituloDoAlbum.PadRight(40),
                        agrupado.TotalPorAlbum);
                }

                //para selecionar o maior,menor e medio valor de vendas
                var vendas = (from nf in contexto.NotaFiscal
                              group nf by 1 into agrupado
                              select new
                              {
                                  maiorVenda = agrupado.Max(nf => nf.Total),
                                  menorVenda = agrupado.Min(nf => nf.Total),
                                  vendaMedia = agrupado.Average(nf => nf.Total)
                              }).Single();
                //.single agrupa em um objeto

                Console.WriteLine("A maior venda é de R$ {0}", vendas.maiorVenda);
                Console.WriteLine("A menor venda é de R$ {0}", vendas.menorVenda);
                Console.WriteLine("A venda média é de R$ {0}", vendas.vendaMedia);


                var newquery =
                        from nf in contexto.NotaFiscal
                        select nf.Total; //select de graça

                var contagem = newquery.Count();

                //preciso ordenar a consulta antes de usar skip
                var queryOrdenada = query.OrderBy(total => total);
                //total ordenado por ele mesmo, ja que o newquery trouxe um objeto nf.total

                var elementoCentral = queryOrdenada.Skip(contagem / 2).First();


                //var query = from f in contexto.Faixa
                //            where f.Album.Artista.Nome.Contains(buscaArtista)
                //            && !(string.IsNullOrEmpty(buscaAlbum) ?
                //                 q.Album.Titulo.Contains(buscaAlbum) : true)
                //            orderby f.Album.Titulo, f.Nome
                //            select f;
                //modo de trazer o nome do album e nome do artista
                //veificando se o album foi passado como argumento e usando where inline
                //necessario usar where sempre antes do order by
                // por metodo

                //query = query.OrderBy(q => q. Album.Titulo).ThenBy(q => q.Nome);
                //ou query = query.OrderBy(q => q.Album.Titulo).ThenByDescending(q => q.Nome);

                Console.ReadKey();

                //SINTAXE DE MÉTODO
                //=================

                //var query
                //= context.Pacote
                //.Join(context.Conteiner, p => p.conteinerID, c => c.ID, (p, c) => new { p, c })
                //.Join(context.pacoteUsuario, pu => pu.p.ID, u => u.pacoteID, (pu, u) => new { pu.p, pu.c, u })
                //.Where(pcu => pcu.u.UsuarioID == "AlgumUsuarioID")
                //.Select(pcu => new
                //{
                //    pcu.p.ID,
                //    pcu.c.Nome,
                //    pcu.p.Code,
                //    pcu.p.Code2
                //});

                ////SINTAXE DE CONSULTA
                ////===================

                //var query2 = from pacote in context.Pacote
                //            join conteiner in context.Conteinere on pacote.conteinerID equals conteiner.ID
                //            join pacoteUsuario in context.pacoteUsuario on pacote.ID equals pacoteUsuario.pacoteID
                //            where pacoteUsuario.UsuarioID == "AlgumUsuarioID"
                //            select new
                //            {
                //                pacote.ID,
                //                conteiner.Nome,
                //                pacote.Code,
                //                pacote.Code2
                //            };
            }

        }
    }

    static class LinqExtension
    {
        public static decimal Mediana<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
        {

            var contagem = source.Count();

            var funcSelector = selector.Compile(); //compilar o seletor linq, transforma em funcao utilizavel

            var queryOrdenada = source.Select(funcSelector).OrderBy(total => total);

            var elementoCentral_1 = queryOrdenada.Skip(contagem / 2).First();

            var elementoCentral_2 = queryOrdenada.Skip(contagem / 2).First();

            var mediana = (elementoCentral_1 + elementoCentral_2) / 2;

            return mediana;
        }


        //public static TSource Second(this IEnumerable source)
        //{
        //    return source.Skip(1).First();
        //}
        //para pegar o segundo valor de uma lista, utilizando a assinatura do metodo .First()
        /*
         * public static TSource Second(this IEnumerable source)
        {
            return source.ElementAt(1);
        } usando metodo elementAt
        */

    }
}
