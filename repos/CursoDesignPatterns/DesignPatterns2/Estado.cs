using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    public class Estado
    {
        public Estado(Contrato contrato)
        {
            Contrato = contrato;
        }

        public Contrato Contrato { get; set; }

    }
}
