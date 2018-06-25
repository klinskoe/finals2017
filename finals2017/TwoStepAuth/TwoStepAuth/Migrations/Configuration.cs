namespace TwoStepAuth.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static TwoStepAuth.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<TwoStepAuth.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TwoStepAuth.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Username,
            new User
            {
                Username = "anti_entity_framework",
                Email = "heh@mail.ru",
                PasswordHash = GetHash("twitch_kruto"),
                Telephone = "88005553535",
                CodeGenerationDt = new DateTime(1999, 10, 10),
                Id = 1
            },
            new User
            {
                Username = "heh_mda",
                Email = "heh_mda@mail.ru",
                PasswordHash = GetHash("twitch_o4_kruto"),
                Telephone = "88005553535",
                CodeGenerationDt = new DateTime(1999,10,10),
                Id = 2
            }
            );
        }
    }
}
