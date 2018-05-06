using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPrima.RepositorioEF.Mapeamento
{
    using Dominio;

    public class ClienteMapeamento : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapeamento()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(128);

            Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("DATE");

            Property(x => x.CPF)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);

            Property(x => x.Telefone)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            ToTable("Cliente");
        }
    }
}
