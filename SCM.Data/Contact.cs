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
        

        public static IEnumerable<Models.Contact> GetContactList(int id = 0)
        {
            SCMContext db = new SCMContext();

            IEnumerable<Contact> ContactList = new List<Contact>();

            if (id == 0)
            {
                ContactList = db.Contacts.ToArray();
            }
            else {
                ContactList = db.Contacts.Where(c => c.ContactId == id);
            }

            foreach (Models.Contact Contact in ContactList)
            {
                IEnumerable<Models.EmailAddress> EmailList = db.EmailAddresses.Where(e => e.Contact.ContactId == Contact.ContactId);
                Contact.EmailAddresses = EmailList.ToArray();
            }

            return ContactList;
        }

        public static void Add(Contact contact, ref bool isSuccess)
        {
            try
            {
                SCMContext db = new SCMContext();
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            catch (Exception e) {
                isSuccess = false;

            }
            
        }

        public static void Update(Contact contact, ref bool isSuccess)
        {
            try
            {
                SCMContext db = new SCMContext();
                //db.Contacts.AddOrUpdate(contact);
                //db.SaveChanges();
                db.Entry(contact).State = EntityState.Modified;
                foreach (EmailAddress email in contact.EmailAddresses) {
                    if (db.EmailAddresses.Where(e => e.EmailAddressId == email.EmailAddressId).Count() > 0)
                    {
                        db.Entry(email).State = EntityState.Modified;
                    }
                    else {
                        db.EmailAddresses.Add(email);
                    }
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                isSuccess = false;

            }
        }
    }
}
