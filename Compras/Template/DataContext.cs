using Microsoft.EntityFrameworkCore;

namespace CompraService.Infra
{
    public class DataContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
