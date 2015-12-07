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
    //[Authorize(Roles ="")]
    public class GroupsController : Controller
    {
        public LDTEEntities db = new LDTEEntities();

        // GET: Groups
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }


        public ActionResult loadPartial()
        {
           
            // return View();
            return PartialView("Parital");
        }
        // GET: Groups/Details/5
        public ActionResult Details(int? id, string formView)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
           
            if (group == null)
            {
                return HttpNotFound();
            }
            else
            {
                group.FormView = formView;
            }
            return PartialView("_Details", group);
        }

        // GET: Groups/Create
        public ActionResult Create(string formView)
        {
            var dto = new Group { FormView = formView };
            // return View();
            return PartialView("_Create",dto);
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Groups.Add(group);
                    db.SaveChanges();
                    return Content("SUCCESS");
                    // return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    { 
                       foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0}",  error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                    return Content("Please fix the following errors: \r\n " + sb.ToString());
                }
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id, string formView)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            group.FormView = formView;
           
            return PartialView("_Edit", group);
          
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(group).State = EntityState.Modified;
                    db.SaveChanges();
                    return Content("SUCCESS");
                   // return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0}", error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                    return Content("Please fix the following errors: \r\n " + sb.ToString());
                }
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id,string formView)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            group.FormView = formView;
            return PartialView("_Delete", group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Group group = db.Groups.Find(id);
                db.Groups.Remove(group);
                db.SaveChanges();
                return Content("SUCCESS");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        public ActionResult ShowUsers(int id)
        {
            Group group = db.Groups.Find(id);
            return PartialView("_UserManage",group);
        }


        [HttpGet]
        public ActionResult AddUsers(int id)//GroupID GET Action
        {
            Group group = db.Groups.Find(id);
            return View(group);
        }
    
        [HttpPost]
        public ActionResult AddUsers(Group group)
        {
            try {
                var usergroup = new UsersGroup { UserID = group.UserID, GroupID = group.GroupID };
                db.UsersGroups.Add(usergroup);
                db.SaveChanges();
                return RedirectToAction("AddUsers", new { id = group.GroupID });
            }
            catch(Exception ex)
            {
                Group dto = db.Groups.Find(group.GroupID);
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View(dto);   
            } 
        }

        public ActionResult DeleteUserGroup(int id)
        {
            var ugr = db.UsersGroups.Where(ug => ug.UsersGroupsID == id).FirstOrDefault();
            try
            {
               
                db.UsersGroups.Remove(ugr);
                db.SaveChanges();

                return RedirectToAction("AddUsers", new { id = ugr.GroupID });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View("AddUsers", ugr.Group);
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
