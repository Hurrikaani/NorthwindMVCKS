using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthwindMVCKS.Models;
using NorthwindMVCKS.ViewModels;

namespace NorthwindMVCKS.Controllers
{
    public class ContactController : Controller
    {
        private northwindEntities db = new northwindEntities();

        // GET: Contact
        public ActionResult Index()
        {
            List<ContactViewModel> model = new List<ContactViewModel>();
            northwindEntities entities = new northwindEntities();
            try
            {
                List<Contacts> contact = entities.Contacts.OrderBy(Contacts => Contacts.ContactID).ToList();
                foreach (Contacts cont in contact)
                {
                    ContactViewModel view = new ContactViewModel();
                    view.ContactID = cont.ContactID;
                    view.ContactType = cont.ContactType;
                    view.CompanyName = cont.CompanyName;
                    view.ContactName = cont.ContactName;
                    view.ContactTitle = cont.ContactTitle;
                    view.Address = cont.Address;
                    view.City = cont.City;
                    view.Region = cont.Region;
                    view.PostalCode = cont.PostalCode;
                    view.Country = cont.Country;
                    view.Phone = cont.Phone;
                    view.Extension = cont.Extension;
                    view.Fax = cont.Fax;
                    view.HomePage = cont.HomePage;
                    view.PhotoPath = cont.PhotoPath;
                    view.Photo = cont.Photo;
                    model.Add(view);
                }
  
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,ContactType,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Extension,Fax,HomePage,PhotoPath,Photo")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contacts);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,ContactType,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Extension,Fax,HomePage,PhotoPath,Photo")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacts contacts = db.Contacts.Find(id);
            db.Contacts.Remove(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
