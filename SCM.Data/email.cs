using SCM.Data.Context;
using SCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        /**
        * <summary>This method takes a <paramref name="email"/> object and tries to delete it from the database.
        * Depending on the success the <paramref name="isSuccess"/> value is updated
        * <param name="isSuccess"/>Boolean that is referenced, indicating the success of the operation
        * <param name="email">Email Address object that is being Deleted</param>
        * <example>
        * A null <paramref name="email"/> object will not be deleted and <paramref name="isSuccess"/> will be false
        * Wheras a proper <paramref name="email"/> object will be deleted and <paramref name="isSuccess"/> will be true
        * </example>
        * </summary>
        */
        public static void DeleteEmail(EmailAddress email, ref bool isSuccess)
        {
            try
            {
                //Initializing values
                SCMContext db = new SCMContext();
                //Delete the Email Address object in the db
                db.Entry(email).State = EntityState.Deleted;
                //Save changes
                db.SaveChanges();
            }
            catch (Exception e)
            {
                //set isSuccess to false
                isSuccess = false;

            }

        }
    }
}
