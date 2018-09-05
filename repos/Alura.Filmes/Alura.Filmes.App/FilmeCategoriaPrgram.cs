using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App
{
    class FilmeCategoriaPrgram
    {
        //public void test()
        //{
        //    using (var contexto = new AluraFilmesContexto())
        //    {
        //        contexto.StartLogSqlToConsole();

        //        var categorias = contexto.Categorias
        //            .Include(c => c.Filmes)
        //            .ThenInclude(fc => fc.Filme);

        //        foreach (var c in categorias)
        //        {
        //            Console.WriteLine("");
        //            Console.WriteLine($"Filmes da categoria {c}:");
        //            foreach (var fc in c.Filmes)
        //            {
        //                Console.WriteLine(fc.Filme);
        //            }
        //        }

        //    }
        //}

        public void Main(string[] args)
        {
            byte? idade = null;

            using(var context = new AluraFilmesContexto())
            {

                var idiomas = context.Idiomas
                    .Include(i => i.FilmesFalados);

                context.LogSQLToConsole();
                foreach(var idioma in idiomas)
                {
                    Console.WriteLine(idioma);
                    foreach (var filme in idioma.FilmesFalados)
                    {
                        Console.WriteLine(filme);

                    }
                    Console.WriteLine("\n");
                }
                //ESSE JOIN PODE DAR ERRO CASO O A COLUNA ORIGINAL LANGUAGE FOR NULL
                //PELA CONVERSAO DE NULIDADE, BYTE, NAO PTERMITE NULL, MAS A COLUNA
                //NO BANCO LEGADO É NULL
            }
        }
    }
}
