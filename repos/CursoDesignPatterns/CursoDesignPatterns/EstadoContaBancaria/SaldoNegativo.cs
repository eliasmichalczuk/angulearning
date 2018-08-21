using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class SaldoNegativo : IEstadoDeContaBancaria
    {
        public void Saque(Conta conta, double valor)
        {
            Console.WriteLine($"Nao é possível sacar");
        }

        public void Deposito(Conta conta, double valor)
        {
            Console.WriteLine($"Depositados 95% = {conta.Valor * 0.95}");
            conta.Deposita(valor * 0.95);
            if (conta.Saldo > 0) conta.Estado = new SaldoPositivo();
        }
    }
}
