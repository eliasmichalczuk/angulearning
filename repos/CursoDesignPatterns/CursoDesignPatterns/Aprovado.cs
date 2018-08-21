using System;

namespace CursoDesignPatterns
{
    public class Aprovado : EstadoDeUmOrcamento
    {
        private bool descontoAplicado = false;
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (!descontoAplicado)
            {
                orcamento.Valor -= orcamento.Valor * 0.02;
                descontoAplicado = true;
            }
            else
            {
                throw new Exception("Desconto já aplicado!");
            }
        }
        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("orcamento ja em estado de aprovacao");
        }
        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("já aprovado");
        }
        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }
    }
}