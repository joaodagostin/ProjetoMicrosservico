using MicrosservicoEstoque.Models;
using MicrosservicoEstoque.Infra;
using Microsoft.EntityFrameworkCore;

namespace MicrosservicoEstoque.Services
{
    public class EstoqueServices
    {
        private readonly DatabaseContext _context;

        public EstoqueServices(DatabaseContext context)
        {
            _context = context;

        }

        public async Task<List<ProdutoEstoque>> ObterInformacoesEstoque()
        {
            return await _context.ProdutoEstoque.ToListAsync();
        }

        public async Task AdicionarMedicamentoAsync(Medicamentos medicamento)
        {
            var produtoExistente = await _context.Medicamentos.FindAsync(medicamento.Id);

            if (produtoExistente != null)
            {
                produtoExistente.Quantidade += medicamento.Quantidade;
                _context.Medicamentos.Update(produtoExistente);
            }
            else
            {
                await _context.Medicamentos.AddAsync(medicamento);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoverMedicamentoAsync(int id, int quantidade)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null || medicamento.Quantidade < quantidade)
            {
                return false; // Não há estoque suficiente ou medicamento inexistente
            }

            medicamento.Quantidade -= quantidade;

            if (medicamento.Quantidade == 0)
            {
                _context.Medicamentos.Remove(medicamento);
            }
            else
            {
                _context.Medicamentos.Update(medicamento);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
