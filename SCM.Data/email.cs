using SCM.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Data
{
    public class email
    {
        public static IEnumerable<Models.EmailAddress> GetEmails(int id = 0)
        {
            SCMContext db = new SCMContext();

            IEnumerable<Models.EmailAddress> AddressList = new List<Models.EmailAddress>();

            if (id == 0)
            {
                AddressList = db.EmailAddresses.ToArray();
            }
            else
            {
                AddressList = db.EmailAddresses.Where(c => c.Contact.ContactId == id).ToArray();
            }

           

            return AddressList;
        }
    }
}
