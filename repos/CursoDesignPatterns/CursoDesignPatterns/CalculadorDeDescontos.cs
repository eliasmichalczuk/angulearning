using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class CalculadorDeDescontos
    {
        public double Calcula(Orcamento orcamento)
        {
            //regra mais de 5 itens
            //if(orcamento.Itens.Count > 5)
            //{
            //    return orcamento.Valor * 0.1;
            //}
            //else if(orcamento.Valor > 500.0)
            //{
            //    return orca   mento.Valor * 0.07;
            //}

            Desconto d1 = new DescontoPorCincoItens();
            Desconto d2 = new DescontePorMaisDeQuinhentos();
            Desconto d3 = new DescontoPorVendaCasada();
            Desconto d4 = new SemDesconto();
            d1.Proximo = d2;
            d2.Proximo = d3;
            d3.Proximo = d4;
            return d1.Desconta(orcamento);
        }
    }
}
