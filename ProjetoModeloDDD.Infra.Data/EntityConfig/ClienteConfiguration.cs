using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        // Fliente API
        // Mostrando as configurações da Tabela Cliente
        public ClienteConfiguration()
        {
            // Indicando que essa propriedade ClienteId é Key(PK)
            HasKey(c => c.ClienteId);

            // Indicando que essa propriedade é Requerida e têm no máximo 150 caracteres.
            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            // Indicando que essa propriedade é Requerida e têm no máximo 150 caracteres.
            Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);

            // Indicando que essa propriedade é Requerida.
            Property(c => c.Email).IsRequired();
        }
    }
}
