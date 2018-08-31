using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpPost]
        
        public object Versao()
        {
            return new { Desenvolvedor = "Elias" };
        }
    }
}
