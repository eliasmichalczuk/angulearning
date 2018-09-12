using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_ENCAPSULAMENTO
{
    public class Fatura
    {
        public string Cliente { get; private set; }
        public double Valor { get; set; }
        public List<Pagamento> Pagamentos { get; private set; }
        public bool Pago { get; set; }

        public Fatura(string cliente, double valor)
        {
            this.Cliente = cliente;
            this.Valor = valor;
            this.Pagamentos = new List<Pagamento>();
            this.Pago = false;
        }
        public void AdicionaPagamento(Pagamento pagamento)
        {
            Pagamentos.Add(pagamento);
            if(valorTotalDosPagamentos() >= Valor)
            {
                this.Pago = true;
            }
        }

        public double valorTotalDosPagamentos()
        {
            double total = 0;
            foreach(Pagamento pagamento in Pagamentos)
            {
                total += pagamento.Valor;
            }
            return total;
        }
    }
}
