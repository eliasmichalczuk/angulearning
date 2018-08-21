using System;

namespace CursoDesignPatterns
{
    class Finalizado : EstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("orcamentos finalizados nao recebem desconto extra");
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