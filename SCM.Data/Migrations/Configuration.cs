namespace SCM.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SCM.Data.Context.SCMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SCM.Data.Context.SCMContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Contacts.AddOrUpdate(
               new Models.Contact()
               {
                   FirstName = "Test",
                   LastName = "Test",
                   EmailAddresses = new List<Models.EmailAddress> {
                        new Models.EmailAddress { EmailType = Models.EmailType.Personal, Email = "test@test.com" },
                        new Models.EmailAddress { EmailType = Models.EmailType.Business, Email = "testbusiness@test.com" },
                   }
               }
               );

            context.Contacts.AddOrUpdate(
               new Models.Contact()
               {
                   FirstName = "Tester",
                   LastName = "Tester",
                   EmailAddresses = new List<Models.EmailAddress> {
                        new Models.EmailAddress { EmailType = Models.EmailType.Personal, Email = "tester@tester.com" },
                        new Models.EmailAddress { EmailType = Models.EmailType.Business, Email = "testerbusiness@test.com" },
                   }
               }
               );
        }
    }
}
