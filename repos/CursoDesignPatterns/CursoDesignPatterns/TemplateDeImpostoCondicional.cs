namespace CursoDesignPatterns
{
    public abstract class TemplateDeImpostoCondicional : Imposto
    {
        public TemplateDeImpostoCondicional(Imposto imposto) : base(imposto) { }
        public TemplateDeImpostoCondicional() : base() { }
        public override double Calcula(Orcamento orcamento)
        {
            if (DeveUsarMaximaTax(orcamento)) return MaximaTax(orcamento);
            return MinimaTax(orcamento);
        }

        public abstract bool DeveUsarMaximaTax(Orcamento orcamento);
        public abstract double MaximaTax(Orcamento orcamento);
        public abstract double  MinimaTax(Orcamento orcamento);

    }
}