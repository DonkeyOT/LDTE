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
    //[Authorize(Roles ="")]
    public class GroupsController : Controller
    {
        public LDTEEntities db = new LDTEEntities();

        // GET: Groups
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
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
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
            //return PartialView("_Create");
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
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
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
            return View(group);
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
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
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
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Index");
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
