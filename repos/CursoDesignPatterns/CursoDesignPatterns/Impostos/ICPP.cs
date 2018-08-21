namespace CursoDesignPatterns
{
    class ICPP : TemplateDeImpostoCondicional
    {
        public override bool DeveUsarMaximaTax(Orcamento orcamento)
        {
          return orcamento.Valor > 500.0;
        }
        public override double MaximaTax(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }
        public override double MinimaTax(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }
}