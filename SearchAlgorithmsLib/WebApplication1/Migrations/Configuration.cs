namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.dataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.dataContext context)
        {
            context.DbInfoes.AddOrUpdate(
    new Models.DbInfo { Username = "dan", Password = "123", Email = "inb@gmail.com", Losses = 1, Wins = 2 },
            new Models.DbInfo { Username = "sara", Password = "124", Email = "inb@gmail.com", Losses = 1, Wins = 3 });
        }
    }
}
