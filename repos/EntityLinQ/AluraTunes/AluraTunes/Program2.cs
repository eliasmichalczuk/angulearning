using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AluraTunes
{
    class Program2
    {
        static void Main2(string[] args)
        {
            System.Xml.Linq.XElement raiz = System.Xml.Linq.XElement.Load(@"Data\AluraTunes.xml");
            XElement root = XElement.Load(@"Data\AluraTunes.xml");

            var qxml = from g in root.Element("Generos").Elements("Genero")
                       select g;

            foreach(var g in qxml)
            {//genero é um no que possui subnoes
                Console.WriteLine($"id do genero: {g.Element("GeneroId").Value}," +
                    $"nome do genero: {g.Element("Nome").Value}");
            }

            var q = from g in root.Element("Generos").Elements("Genero")
                    join m in root.Element("Musica").Elements("Musica")
                    on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                    select new
                    {
                        Musica = m.Element("Nome").Value,
                        Genero = g.Element("Nome").Value
                    };
            Console.WriteLine();


            Console.ReadKey();



            XElement automoveis = XElement.Load(@"Data\Automoveis.xml");
            var queryFabricantes =
            from f in automoveis.Element("Fabricantes").Elements("Fabricante")
            select new
            {
                Id = f.Element("FabricanteId").Value,
                Nome = f.Element("Nome").Value
            };

            //var query = from f in automoveis.Element("Fabricantes").Elements("Fabricante")
            //            join m in automoveis.Element("Modelos").Elements("Modelo")
            //                on f.Element("FabricanteId").Value equals m.Element("FabricanteId").Value
            //            select new
            //            {
            //                ModeloId = m.Element("ModeloId").Value,
            //                Modelo = m.Element("Nome").Value,
            //                Fabricante = f.Element("Nome").Value
            //            };

        }

        //Com base nesse arquivo XML, qual alternativa representa a o código 
        //adequado para retornar uma lista contendo o Id e o Nome dos fabricantes? ^^ XMLFILE1 no projetos
    }
}
