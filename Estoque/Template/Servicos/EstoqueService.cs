namespace EstoqueService.Services
{
    public class EstoqueServices
    {
        private static List<Produto> _estoque = new();

        public List<Produto> ListarEstoque()
        {
            return _estoque;
        }

        public bool AdicionarProduto(int produtoId, string nome, int quantidade)
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

            return true;
        }

        public bool RemoverProduto(int produtoId, int quantidade)
        {
            var produto = _estoque.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto == null || produto.Quantidade < quantidade)
                return false;

            produto.Quantidade -= quantidade;

            if (produto.Quantidade == 0)
                _estoque.Remove(produto);

            return true;
        }
    }

    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
