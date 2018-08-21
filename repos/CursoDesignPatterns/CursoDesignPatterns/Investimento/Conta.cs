using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public class Conta
    {

        public IEstadoDeContaBancaria Estado { get; set; }
        public string Nome { get; set; }

        public double Saldo { get; private set; }
        public string Numero { get; internal set; }
        public string Agencia { get; internal set; }
        public int Valor { get; internal set; }
        public DateTime DataAbertura { get; internal set; }
        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public Conta(double Saldo)
        {

            if (Valor >= 0)
            {
                Estado = new SaldoPositivo();
            }
            else { Estado = new SaldoNegativo(); }
        }

        public void Saque(double valor)
        {
            Estado.Saque(this, valor);
        }

        public void Deposito(double valor)
        {
            Estado.Deposito(this, valor);
        }
    }
}
