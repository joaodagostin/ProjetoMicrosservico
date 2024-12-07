using CompraService.Infra;

namespace MicrosservicoCompras.Infra
{
    public class EstoqueClient
    {
        public void AdicionarProdutoEstoque(Produto produto)
        {
            // Simulação de comunicação HTTP com o Microsserviço de Estoque
            Console.WriteLine($"Produto {produto.Nome} adicionado ao estoque.");
        }
    }
}
