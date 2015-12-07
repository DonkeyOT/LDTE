using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LDTE_Web.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace LDTE_Web.Controllers
{
    public class UsersController : Controller
    {
        public LDTEEntities db = new LDTEEntities();

        // GET: Users
        public ActionResult ManageUser()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
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
            return PartialView("_Details", user);
        }

        // GET: Users/Create
        public ActionResult CreateUser(string formView)
        {
            var dto = new User { FormView = formView };
            // return View();
            return PartialView("_Create", dto);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "UserID,PrefixName,FirstName,LastName,MiddleName,SuffixName,DateOfBirth,Login,Password,SecurityHint,SecurityAnswer,PasswordDate,LockoutFlag,InactiveDate")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Content("SUCCESS");
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult EditUser(int? id, string formView)
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
            user.FormView = formView;

            return PartialView("_Edit", user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "UserID,PrefixName,FirstName,LastName,MiddleName,SuffixName,DateOfBirth,Login,Password,SecurityHint,SecurityAnswer,PasswordDate,LockoutFlag,InactiveDate")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Content("SUCCESS");
            }
            return View(user);































































































































        }

        // GET: Users/Delete/5
        public ActionResult DeleteUser(int? id, string formView)
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
            user.FormView = formView;
            return PartialView("_Delete", user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return Content("SUCCESS");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
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
