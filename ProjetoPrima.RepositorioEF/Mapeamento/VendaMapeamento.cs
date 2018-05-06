using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPrima.RepositorioEF.Mapeamento
{
    using Dominio;

    public class VendaMapeamento : EntityTypeConfiguration<Venda>
    {
        public VendaMapeamento()
        {
            HasKey(p => p.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NumeroDoPedido)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(128);

            Property(x => x.Data)
                .IsRequired()
                .HasColumnType("DATE");

            ToTable("Venda");
        }
    }
}
