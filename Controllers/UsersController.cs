using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LDTE_Web.Models;

namespace LDTE_Web.Controllers
{
    public class UsersController : Controller
    {
        public LDTEEntities db = new LDTEEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //// GET: Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Email,Password,PhoneWork,PhoneMobile")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Email,Password,PhoneWork,PhoneMobile")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddEditRecord(int? id)
        {
            if (Request.IsAjaxRequest())
            {
                if (id != null)
                {
                    ViewBag.IsUpdate = true;
                    User student = db.Users.Where(m => m.UserID == id).FirstOrDefault();
                    return PartialView("_UserData");
                }
                ViewBag.IsUpdate = false;
                return PartialView("_StudentData");
            }
            else
            {
                if (id != null)
                {
                    ViewBag.IsUpdate = true;
                    User student = db.Users.Where(m => m.UserID == id).FirstOrDefault();
                    return PartialView("UserData");
                }
                ViewBag.IsUpdate = false;
                return View("UserData");
            }
        }

        [HttpPost]
        public ActionResult AddEditRecord(User user, string cmd)
        {
            if (ModelState.IsValid)
            {
                if (cmd == "Save")
                {
                    try
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        User us = db.Users.Where(m => m.UserID == user.UserID).FirstOrDefault();
                        if (us != null)
                        {
                            us.FirstName = user.FirstName;
                            us.LastName = user.LastName;
                            us.Email = user.Email;
                            us.Password = user.Password;
                            us.PhoneWork = user.PhoneWork;
                            us.PhoneMobile = user.PhoneMobile;
                            db.SaveChanges();
                        }
                        return RedirectToAction("Index");
                    }
                    catch { }
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_UserData", user);
            }
            else
            {
                return View("UserData", user);
            }
        }

        public ActionResult DeleteRecord(int id)
        {
            User user = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            if (user != null)
            {
                try
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                catch { }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            User user = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            if (user != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_StudentDetails", user);
                }
                else
                {
                    return View("StudentDetails", user);
                }
            }
            return View("Index");
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
