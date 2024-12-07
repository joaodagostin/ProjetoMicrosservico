using MicrosservicoCompras.DTO;

namespace MicrosservicoCompras.Servicos
{
    public class CompraSService
    {
        public void ProcessarCompra(CompraDto compraDto)
        {
            Console.WriteLine($"Processando compra do produto: {compraDto.Produto}, quantidade: {compraDto.Quantidade}");
        }
    }
}
