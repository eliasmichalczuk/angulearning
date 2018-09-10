using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Desconto
{
    class GeradorDeNotaFiscal()
    {

        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes)
        {
        this.acoes = acoes;
        }

        public NotaFiscal Gera(Fatura fatura)
        {

            double valor = fatura.ValorMensal;

            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobreO(valor));
            
            foreach(IAcaoAposGerarNota acao in acoes)
            {
            acao.Executa();
            }
        return nf;
        }

        private double ImpostoSimplesSobreO(double valor)
        {
            return valor * 0.06;
        }
    }
}
