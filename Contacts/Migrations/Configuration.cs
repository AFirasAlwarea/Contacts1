namespace Contacts.Migrations
{
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
            for (int i = 1; i < 100; i++)
            {
                context.Person.AddOrUpdate(
                    P => P.Email,
                    new People
                    {
                        FirstName = "Unknown"+i,
                        LastName = "Somebody",
                        TelephoneNo = "0769876543"+i,
                        Email = i + "@gmail.com"
                    }
                    );
            }
        }
    }
}
