using MicrosservicoEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace MicrosservicoEstoque.Infra
{
    public class DatabaseContexts : DbContext
    {
        public DatabaseContexts(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Medicamentos> Medicamentos { get; set; }
    }
}
