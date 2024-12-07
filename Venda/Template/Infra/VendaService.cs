namespace VendaService.Services
{
    public class VendaService
    {
        private readonly HttpClient _httpClient;

        public VendaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RealizarVendaAsync(int produtoId, int quantidade)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "http://localhost:5001/api/estoque/remover",
                new { produtoId, quantidade });

            return response.IsSuccessStatusCode;
        }
    }
}
