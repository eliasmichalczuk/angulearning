using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConaBancaria
{
    class RespostaEmCsv : Resposta
    {
        public Resposta OutraResposta { get; set; }
        public RespostaEmCsv(Resposta outra)
        {
            OutraResposta = outra;
        }
        public void Responde(Requisicao req, Conta conta)
        {
            if (req.Formato == Formato.CSV)
            {
                Console.WriteLine(conta.Titular + ";" + conta.Saldo);
            }
            else
            {
                OutraResposta.Responde(req, conta);
            }
        }
    }
}
