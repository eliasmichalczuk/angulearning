using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class DescontoPorVendaCasada : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            if (verificarItem("Lapis", orcamento) && verificarItem("Caneta", orcamento))
            {
                return orcamento.Valor * 0.05;
            }
            return Proximo.Desconta(orcamento);
        }

        private bool verificarItem(String nome, Orcamento orcamento)
        {
            foreach(Item item in orcamento.Itens)
            {
                if (item.Nome.Equals(nome)) return true;
            }
            return false;
        }
    }
}
