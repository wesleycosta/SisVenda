using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPrima.RepositorioEF.Mapeamento
{
    using Dominio;

    public class VendaItemMapeamento : EntityTypeConfiguration<VendaItem>
    {
        public VendaItemMapeamento()
        {
            HasKey(p => p.Id);
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Produto)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(128);

            Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnType("INT");

            ToTable("VendaItem");
        }
    }
}
