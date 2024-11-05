using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<FornecedorModel> Fornecedores { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<VendasModel> Vendas { get; set; }
    }
}
