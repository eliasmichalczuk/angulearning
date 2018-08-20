using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class CalculadorDeImpostos
    {
        //public void RealizaCalculoICMS(Orcamento orcamento)
        //{
        //   double icms = new ICMS().CalculaICMS(orcamento);
        //   Console.WriteLine(icms);
        //}

        //public void RealizaCalculoISS(Orcamento orcamento)
        //{
        //  double iss = new ISS().CalculaISS(orcamento);
        //  Console.WriteLine(iss);
        //}

        public void RealizaCalculo(Orcamento orcamento, Imposto imposto)
        {
            double imposto1 = imposto.Calcula(orcamento);
            Console.WriteLine(imposto1);
        }
    }
}
