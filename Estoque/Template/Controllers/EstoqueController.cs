using MicrosservicoEstoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicrosservicoEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueServices _servico;

        public EstoqueController(EstoqueServices servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult GetEstoque()
        {
            return Ok(_servico.ObterInformacoesEstoque());
        }
    }
}
