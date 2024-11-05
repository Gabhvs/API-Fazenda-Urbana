using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Services.Cliente;
using APIFazendaUrbana.Services.Login;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginInterface;
        public LoginController(ILoginService loginInterface)
        {
            _loginInterface = loginInterface;
        }

        /// <summary>
        /// Obrigatório
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login(ClienteCriacaoDto cliente)
        {
            var resultado = await _loginInterface.Login(cliente);
            if(resultado.Status)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }
    }
}
