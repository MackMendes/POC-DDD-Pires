using System.Data.Entity.Migrations;

namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.ProjetoModeloContext>
    {
        public Configuration()
        {
            // A flag abaixo vai refleticar as altera��es ou cria��es no banco de dados, no decorrer das implementa��es.
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.ProjetoModeloContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
