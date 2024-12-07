using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace CompraService.Controllers
{
    [ApiController]
    [Route("api/compra")]
    public class CompraController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CompraController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProdutoNoEstoque(int produtoId, string nome, int quantidade)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "http://localhost:5001/api/estoque/adicionar",
                new { produtoId, nome, quantidade });

            if (response.IsSuccessStatusCode)
            {
                return Ok("Produto adicionado ao estoque com sucesso.");
            }

            return BadRequest("Erro ao adicionar produto no estoque.");
        }
    }
}
