using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome).IsRequired().HasMaxLength(250);

            Property(p => p.Valor).IsRequired();

            // Estou indicando que tem um relacionamento do Produto com MUITOS Cliente, e esse relacionamento (FK) faz com a propriedade ClienteId
            HasRequired(p => p.Cliente).WithMany().HasForeignKey(p => p.ClienteId);
        }

    }
}
