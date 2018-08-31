using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Infra.Transactions;
using YouLearn.Domain.Interfaces.Services;

namespace YouLearn.Api.Controllers
{
    public class CanalController : Base.ControllerBase
    {
        private readonly IServiceCanal _serviceCanal;

        public CanalController(IUnitOfWork unityOfWork, IServiceCanal serviceCanal) : base(unityOfWork)
        {
            _serviceCanal = serviceCanal;
        }

        [HttpGet]
        [Route("api/v1/CanalListar")]
        public async Task<IActionResult> Listar()
        {

        }
    }
}
