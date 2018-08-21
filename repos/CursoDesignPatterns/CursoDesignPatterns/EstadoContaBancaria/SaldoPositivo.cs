using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class SaldoPositivo : IEstadoDeContaBancaria
    {
        public void Deposito(Conta conta, double valor)
        {
            Console.WriteLine($"Depositados 98% = {conta.Saldo*0.98}");
            conta.Deposita(valor * 0.98);
            if (conta.Saldo < 0) conta.Estado = new SaldoNegativo();
        }
        public void Saque(Conta conta, double valor)
        {
            
        }
    }
}
