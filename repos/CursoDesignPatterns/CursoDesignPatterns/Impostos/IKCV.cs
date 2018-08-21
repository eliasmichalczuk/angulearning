using System;
using System.Linq;

namespace CursoDesignPatterns
{
    public class IKCV : TemplateDeImpostoCondicional
    {
        public IKCV(Imposto imposto) : base(imposto) { }
        public IKCV() : base() { }
        public override bool DeveUsarMaximaTax(Orcamento orcamento)
        {
            return orcamento.Valor > 500.0 && TemItemMaiorQueCem(orcamento) ;
        }

        public override double MaximaTax(Orcamento orcamento) => orcamento.Valor * 0.10 + CalculoOutroImposto(orcamento);
        public override double MinimaTax(Orcamento orcamento) => orcamento.Valor * 0.06 + CalculoOutroImposto(orcamento);
        private bool TemItemMaiorQueCem(Orcamento orcamento)
        {
            foreach(Item item in orcamento.Itens)
            {
                if (item.Valor > 100.0) return true;
            }
            return false;
        }
    }
}