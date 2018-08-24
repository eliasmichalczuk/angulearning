using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public static int TotalDeFuncionarios {get;set;}

        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("criando funcionario");
            CPF = cpf;
            Salario = salario;
            TotalDeFuncionarios++;
        }
        public abstract void AumentarSalario();
        public abstract double GetBonificacao();
    }
}
