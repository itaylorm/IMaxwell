using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMaxwell.UI.Mvc.Views.Contact;
using MvcPaging;

namespace IMaxwell.UI.Mvc.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        public ActionResult Index(int? page)
        {
            var contacts = ContactService.GetContacts();
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(contacts.ToPagedList(currentPageIndex, 15));
        }

        //
        // GET: /Contact/Details/5
        public ActionResult Details(int id)
        {
            var contact = ContactService.GetContact(id);
            return View(contact);
        }

        //
        // GET: /Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var contact = ContactService.GetContact(id);
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
