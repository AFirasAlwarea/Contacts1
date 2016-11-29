using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class PeopleDB : DbContext
    {
        public DbSet<People> Person { get; set; }

    }
}