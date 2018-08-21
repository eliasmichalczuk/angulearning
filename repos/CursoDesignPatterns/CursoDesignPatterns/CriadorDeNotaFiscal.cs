using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class CriadorDeNotaFiscal
    {
        public String RazaoSocial { get; set; }
        public String Cnpj{ get; set; }
        public String Observacoes { get; set; }
        public DateTime Data{ get; set; }
        
        private double valorTotal;
        private double impostos;
        private IList<ItemDaNota> todosItens = new List<ItemDaNota>();
        public IList<AcaoAposGerarNota> todasAcoes = new List<AcaoAposGerarNota>();
        public NotaFiscal Constroi()
        {
            NotaFiscal nf = new NotaFiscal("d",Cnpj,Data,valorTotal,impostos,todosItens, Observacoes);
            
            foreach(AcaoAposGerarNota acao in todasAcoes)
            {
                acao.Executa(nf);
            }
            return nf;
        }
        public CriadorDeNotaFiscal()
        {
            this.Data = DateTime.Now;
            this.todasAcoes = new List<AcaoAposGerarNota>();
        }

        public CriadorDeNotaFiscal ParaEmpresa(String razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
            return this;
        }
        public void AdicionaAcao(AcaoAposGerarNota novaAcao)
        {
            this.todasAcoes.Add(novaAcao);
        }
        public CriadorDeNotaFiscal ComObservacoes(String observacoes)
        {
            Observacoes = observacoes;
            return this;
        }
        public CriadorDeNotaFiscal NaDataAtual()
        {
            Data = DateTime.Now;
            return this;
        }
        public CriadorDeNotaFiscal ComCnpj(String cnpj)
        {
            this.Cnpj = cnpj;
            return this;
        }

        public CriadorDeNotaFiscal Com(ItemDaNota item)
        {
            todosItens.Add(item);
            valorTotal += item.Valor;
            impostos += item.Valor * 0.05;
            return this;
        }

        internal void AdicionaAcao(EnviadorDeEmail enviadorDeEmail)
        {
            throw new NotImplementedException();
        }
    }
}
