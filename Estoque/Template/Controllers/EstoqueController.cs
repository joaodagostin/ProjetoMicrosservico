using Microsoft.AspNetCore.Mvc;

namespace EstoqueService.Controllers
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }

    [ApiController]
    [Route("api/estoque")]
    public class EstoqueController : ControllerBase
    {
        private static List<Produto> _estoque = new();

        [HttpPost("adicionar")]
        public IActionResult AdicionarProduto(int produtoId, string nome, int quantidade)
        {
            var produto = _estoque.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto != null)
            {
                produto.Quantidade += quantidade;
            }
            else
            {
                _estoque.Add(new Produto { ProdutoId = produtoId, Nome = nome, Quantidade = quantidade });
            }

            return Ok(_estoque);
        }

        [HttpPost("remover")]
        public IActionResult RemoverProduto(int produtoId, int quantidade)
        {
            var produto = _estoque.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto == null || produto.Quantidade < quantidade)
                return BadRequest("Estoque insuficiente ou produto inexistente.");

            produto.Quantidade -= quantidade;
            if (produto.Quantidade == 0)
                _estoque.Remove(produto);

            return Ok(_estoque);
        }

        [HttpGet]
        public IActionResult GetEstoque() => Ok(_estoque);
    }
}
