using System;

namespace CursoDesignPatterns
{
    public class Reprovado : EstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("orcamentos reprovados nao recebem desconto extra");
        }
        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("orcamento ja reprovado");
        }
        public void Reprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Reprovado();
        }
        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }
    }
}