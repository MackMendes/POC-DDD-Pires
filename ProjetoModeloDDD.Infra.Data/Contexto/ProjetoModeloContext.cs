using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Contexto 
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD")
        {

        }

        // Propriedades para criação de tabela, por CodeFirst.
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Removendo a Pluralidade da criação das Tabelas. Exem.: Vez de ser "Produtoes" será "Produtor", que forma eu foi indicado. (deixa fiel)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Removendo a opção de Deletar em castata quando tiver uma relação de um para muitos. (Not Delete Cascade)
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // Removendo a opção de Deletar em castata, quanto tiver uma relação de muitos para muitos. (Not Delete Cascade)
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Abaixou estou indicando ao EntityFramework que toda Propriedade que estiver com o Nome + "Id" (Ex.: ClienteId) é uma propriedade que deve ser
            // setada como PK (Primary Key)
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            // Abaixo estou indicando ao EntityFramework que toda Propriedade que for do tipo String, terá que ser criado no banco de dados como "varchar", 
            // ao invés de "nvarchar" que é o default.
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            // Abaixou ainda estou indicando ao EntityFramework que toda Propriedade que for do tipo String e não for setado nada, por default, vai ter 
            // o tamanho Máximo de 100 caracter (varchar(100));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            // Desta forma, eu indico ao EntityFramework utilizar essas configurações adicionais, quando for construir as tabelas
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        public override int SaveChanges()
        {
            // Dando uma foreach no "ChangeTracker" (Tracker de alguma mudança), quando a entidade estiver DataCadastro (Reflextion) e ela for diferente de nulo
            // Entidades que tiver a propriedade "DataCadastro"
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                // Quando estiver Adicionando essa entidade, o valor por default dela, será DateTime.Now.
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                // Quando estiver Alterando, não muda esse valor! Porque é a data Cadastro (Apenas uma vez).
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            // Reescrevendo o SaveChange da base
            return base.SaveChanges();
        }
    }
}
