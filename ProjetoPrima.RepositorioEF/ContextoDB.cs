using System.Data.Entity;

namespace ProjetoPrima.RepositorioEF
{
    using Dominio;
    using Mapeamento;

    public class ContextoDB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        public ContextoDB() : base(ConfiguracaoDB.StringDeConexao) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMapeamento());
            modelBuilder.Configurations.Add(new VendaMapeamento());
            modelBuilder.Configurations.Add(new VendaItemMapeamento());
        }
    }
}
