namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataModels;

    internal sealed class Configuration : DbMigrationsConfiguration<Sistema_Academico.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sistema_Academico.Models.ApplicationDbContext";
        }

        protected override void Seed(Sistema_Academico.Models.ApplicationDbContext context)
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

            context.Carreras.AddOrUpdate(
                x => x.CarreraId,
                new Carrera { Titulo = "Ingenieria en sistemas", CreditosRequeridos = 260 },
                new Carrera { Titulo = "Ingenieria de Software", CreditosRequeridos = 252 },
                new Carrera { Titulo = "Ingenieria Industial", CreditosRequeridos = 248 }
                );
        }
    }
}
