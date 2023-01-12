using ApiClientes.DTOs;
using ApiClientes.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private ICustomerService _customerService;
        public ClientesController(ICustomerService customerService) => this._customerService = customerService;

        [HttpPost("/api/Novedad")]
        public IActionResult Novedad(NovedadDTO novedad)
        {
            this._customerService.Novedad(novedad);
            return (IActionResult)this.Ok();
        }
    }
}
