using System.Data.Entity.Migrations;

namespace $safeprojectname$.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Repositories.OrderExRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(Repositories.OrderExRepository context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
