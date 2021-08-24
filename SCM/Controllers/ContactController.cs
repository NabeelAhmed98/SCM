using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCM.Data;

namespace SCM.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult List() {

            IEnumerable<Data.Models.Contact> ContactList = Data.contact.GetContactList();

            return View(ContactList);
        }

        public ActionResult Create() {
            Data.Models.Contact newContact = new Data.Models.Contact();

            
            return PartialView("_Create", newContact);
        }

        public ActionResult Edit(int ContactId)
        {
            Data.Models.Contact newContact = Data.contact.GetContactList(ContactId).FirstOrDefault();


            return PartialView("_Edit", newContact);
        }

        [HttpPost]
        
        public JsonResult Insert(Data.Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = true;
                Data.contact.Add(contact, ref isSuccess);

                return Json(new { Success = isSuccess });
            }
            else {
                return Json(new { Success = false });
            }

            
        }

        [HttpPost]

        public JsonResult Update(Data.Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = true;
                Data.contact.Update(contact, ref isSuccess);

                return Json(new { Success = isSuccess });
            }
            else
            {
                return Json(new { Success = false });
            }


        }


        public JsonResult getEmails(int ContactId)
        {
            IEnumerable<Data.Models.EmailAddress> emails = Data.email.GetEmails(ContactId);
            return Json(emails, JsonRequestBehavior.AllowGet);
        }
    }
}