using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Diretor : FuncionarioAutenticavel
    {
        public string Senha { get; set; }
        public Diretor(string cpf) : base(5000,cpf)
        {
            Console.WriteLine("criando diretor");
        }
        public bool Autenticar(string senha)
        {
            return true;
        }
        public override void AumentarSalario()
        {
            Salario *= 1.5;
        }
        public override double GetBonificacao()
        {
            return Salario * 0.5;
        }
    }
}
