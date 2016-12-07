namespace Contacts.Migrations
{
    using Lexicon.CSharp.InfoGenerator;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contacts.Models.PeopleDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Contacts.Models.PeopleDB context)
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
            context.Person.AddOrUpdate(
                P => P.Email,
                new People {
                    FirstName ="Firas",
                    LastName="Alwarea",
                    TelephoneNo="0762620287",
                    Email="firas.wira@gmail.com"
                },
                new People
                {
                    FirstName = "Husam",
                    LastName = "Jammal",
                    TelephoneNo = "076222222",
                    Email = "husam.jammal@gmail.com"
                },
                new People
                {
                    FirstName = "Shadi",
                    LastName = "Jbawi",
                    TelephoneNo = "0767777777",
                    Email = "shadi.jbawil@homtail.com"
                }
                );

            InfoGenerator rndInfo = new InfoGenerator(DateTime.Now.Ticks.GetHashCode());
            for (int i = 1; i < 10; i++)
            {
                context.Person.AddOrUpdate(
                    P => P.Email,
                    new People
                    {
                        FirstName = rndInfo.NextFirstName(),
                        LastName = rndInfo.NextLastName(),
                        TelephoneNo = "076"+rndInfo.Next(1,10000),
                        Email = FirstName +"."LastName + "@gmail.com"
                    }
                    );
            }
        }
    }
}
