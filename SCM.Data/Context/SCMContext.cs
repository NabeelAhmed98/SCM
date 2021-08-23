using SCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Data.Context
{
    public class SCMContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<EmailAddress> EmailAddresses { get; set; }

    }
}
