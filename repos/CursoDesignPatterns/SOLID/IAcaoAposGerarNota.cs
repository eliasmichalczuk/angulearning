using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Desconto
{
    interface IAcaoAposGerarNota
    {
        void Executa(NotaFiscal nf);
    }
}
