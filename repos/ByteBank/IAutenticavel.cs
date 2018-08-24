using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public interface IAutenticavel
    {
        public Autenticavel(double salario, string cpf) : base(salario, cpf)
        {
        }
        public string Senha { get; set; }

        bool Autenticar(string senha);
    }
}
