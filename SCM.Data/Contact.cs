using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCM.Data.Context;
using SCM.Data.Models;

namespace SCM.Data
{
    public class contact
    {

        /**
         * <summary>The method takes <paramref name="id"/> as input and gets a list of contact records that match the query
         * <param name="id">Primary key of contact record that is passed in. By default it is 0</param>
         * <example>
         * <code>
         * GetContactList()
         * </code>
         * results in all records in the Contacts table, and their associated emails, to return whereas
         * <code>
         * getContactList(1)
         * </code>
         * results in Contact record with id 1, and its associated emails to return
         * </example>
         * <returns>A list of Contact objects</returns>
         * </summary>
         */
        public static IEnumerable<Models.Contact> GetContactList(int id = 0)
        {
            //initializing values
            SCMContext db = new SCMContext();

            
            IEnumerable<Contact> ContactList = new List<Contact>();

            //Depending on id value
            if (id == 0)
            {
                //Return all Contact records
                ContactList = db.Contacts.ToArray();
            }
            else {
                //Returns only Contact records where the id matches (should only be one)
                ContactList = db.Contacts.Where(c => c.ContactId == id);
            }

            //Loops through ContactList
            foreach (Models.Contact Contact in ContactList)
            {
                //Gets all Email Addresses where the Contact id matches
                IEnumerable<Models.EmailAddress> EmailList = db.EmailAddresses.Where(e => e.Contact.ContactId == Contact.ContactId);
                //Sets the Email List to the Collection property in the Contact object
                Contact.EmailAddresses = EmailList.ToArray();
            }
            //Return list
            return ContactList;
        }

        /**
         * <summary>This method takes a <paramref name="contact"/> object and tries to insert it into the database.
         * Depending on the success the <paramref name="isSuccess"/> value is updated
         * <param name="isSuccess"/>Boolean that is referenced, indicating the success of the operation
         * <param name="contact">Contact object that is being inserted</param>
         * <example>
         * A null <paramref name="contact"/> object will not be inserted and <paramref name="isSuccess"/> will be false
         * Wheras a proper <paramref name="contact"/> object will be inserted and <paramref name="isSuccess"/> will be true
         * </example>
         * </summary>
         */
        public static void Add(Contact contact, ref bool isSuccess)
        {
            try
            {
                //Initializing values
                SCMContext db = new SCMContext();
                //Add the Contact object to the db
                db.Contacts.Add(contact);
                //Save changes
                db.SaveChanges();
            }
            catch (Exception e) {
                //set isSuccess to false
                isSuccess = false;

            }
            
        }

        /**
         * <summary>This method takes a <paramref name="contact"/> object and tries to update it in the database.
         * Depending on the success the <paramref name="isSuccess"/> value is updated
         * <param name="isSuccess"/>Boolean that is referenced, indicating the success of the operation
         * <param name="contact">Contact object that is being updated</param>
         * <example>
         * A null <paramref name="contact"/> object will not be updated and <paramref name="isSuccess"/> will be false
         * Wheras a proper <paramref name="contact"/> object will be updated and <paramref name="isSuccess"/> will be true
         * </example>
         * </summary>
         */
        public static void Update(Contact contact, ref bool isSuccess)
        {
            try
            {
                //initialize values
                SCMContext db = new SCMContext();
                //set the Contact object state to modified, and update it in db
                db.Entry(contact).State = EntityState.Modified;
                //loop through emails in the Contact object
                foreach (EmailAddress email in contact.EmailAddresses) {
                    //if the email is already in the db
                    if (db.EmailAddresses.Where(e => e.EmailAddressId == email.EmailAddressId).Count() > 0)
                    {
                        //update the email object in the db
                        db.Entry(email).State = EntityState.Modified;
                    }
                    else {
                        //add the email object to the db
                        db.EmailAddresses.Add(email);
                    }
                }
                //save changes
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
