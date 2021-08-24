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
        /**
         * <summary>The method takes <paramref name="id"/> as input and gets a list of emailAddress records that match the query
         * <param name="id">Foreign key of emailAddress record that is passed in. By default it is 0</param>
         * <example>
         * <code>
         * GetContactList()
         * </code>
         * results in all records in the EmailAddress table to return whereas
         * <code>
         * getContactList(1)
         * </code>
         * results in EmailAddress records with associated with Contact at id 1
         * </example>
         * <returns>A list of EmailAddress objects</returns>
         * </summary>
         */
        public static IEnumerable<Models.EmailAddress> GetEmails(int id = 0)
        {
            //initialize values
            SCMContext db = new SCMContext();

            IEnumerable<Models.EmailAddress> AddressList = new List<Models.EmailAddress>();

            //Depending on id value
            if (id == 0)
            {
                //Get all EmailAddress records in the db
                AddressList = db.EmailAddresses.ToArray();
            }
            else
            {
                //Get all EmailAddress records associated with the Contact id passed in
                AddressList = db.EmailAddresses.Where(c => c.Contact.ContactId == id).ToArray();
            }

           
            //return A list of emailAddress objects
            return AddressList;
        }
    }
}
