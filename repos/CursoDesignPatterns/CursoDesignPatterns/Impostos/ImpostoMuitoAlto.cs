using System;

namespace CursoDesignPatterns
{

    class ImpostoMuitoAlto : Imposto
    {
        public ImpostoMuitoAlto(Imposto imposto) : base(imposto) { }
        public ImpostoMuitoAlto() : base() { }
        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.2 + CalculoOutroImposto(orcamento);
        }
    }
}