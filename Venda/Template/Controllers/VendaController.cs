using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace VendaService.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public VendaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarVenda(int produtoId, int quantidade)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "http://localhost:5001/api/estoque/remover",
                new { produtoId, quantidade });

            if (response.IsSuccessStatusCode)
            {
                return Ok("Venda concluída com sucesso.");
            }

            return BadRequest("Estoque insuficiente.");
        }
    }
}
