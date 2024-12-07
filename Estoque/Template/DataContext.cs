using Microsoft.EntityFrameworkCore;
using MicrosservicoEstoque.Models;

namespace MicrosservicoEstoque.Infra
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Medicamentos> Medicamentos { get; set; }
        public DbSet<ProdutoEstoque> ProdutoEstoque { get; set; }
    }
    public class ProdutoEstoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
