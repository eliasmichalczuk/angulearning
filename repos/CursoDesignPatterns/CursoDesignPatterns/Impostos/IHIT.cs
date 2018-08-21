using System;
using System.Collections.Generic;

namespace CursoDesignPatterns
{
    class IHIT : TemplateDeImpostoCondicional
    {
        public override bool DeveUsarMaximaTax(Orcamento orcamento)
        {
            IList<String> noOrcamento = new List<String>();
            foreach(Item item in orcamento.Itens){
                if (noOrcamento.Contains(item.Nome)) return true;
                noOrcamento.Add(item.Nome);
            }
            return false;
        }

        public override double MaximaTax(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13 + 100.0;
        }

        public override double MinimaTax(Orcamento orcamento)
        {
            return orcamento.Valor * (0.01 * orcamento.Itens.Count);
        }
    }
}