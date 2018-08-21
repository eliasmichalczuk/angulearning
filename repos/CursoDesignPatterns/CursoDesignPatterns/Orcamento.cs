using System;
using System.Collections.Generic;

namespace CursoDesignPatterns
{
    public class Orcamento
    {

        public EstadoDeUmOrcamento EstadoAtual { get; set; }
        public double Valor { get; set; }
        public IList<Item> Itens { get; private set; }
        private int Qtd {get;  set; }
        public Orcamento(double valor)
        {
            this.Valor = valor;
            this.Itens = new List<Item>();
            this.EstadoAtual = new EmAprovacao();
        }
        public void AdicionaItem(Item item)
        {
            Itens.Add(item);
        }
        public void AplicaDescontoExtra()
        {
            if (Qtd > 0) throw new  SystemException();
            EstadoAtual.AplicaDescontoExtra(this);
            Qtd++;

        }
        public void Aprova()
        {
            EstadoAtual.Aprova(this);
        }
        public void Reprova()
        {
            EstadoAtual.Reprova(this);
        }
        public void Finaliza()
        {
            EstadoAtual.Finaliza(this);
        }
    }
}
