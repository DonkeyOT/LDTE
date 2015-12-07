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
       [Authorize]
        public ActionResult ManageGroup ()
        {
            return View(db.Groups.ToList());
        }


        //public ActionResult loadPartial()
        //{

        //    return PartialView("Parital");
        //}

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
        public ActionResult CreateGroup(string formView)
        {
            var dto = new Group { FormView = formView };
            return PartialView("_Create", dto);
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup([Bind(Include = "GroupID,GroupName,GroupCode,GroupAlias,GroupDescription")] Group group)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Groups.Add(group);
                    db.SaveChanges();
                   // return RedirectToAction("ManageGroup");
                    return Content("SUCCESS");
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult EditGroup(int? id, string formView)
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
        public ActionResult EditGroup([Bind(Include = "GroupID,GroupName,GroupCode,GroupAlias,GroupDescription")] Group group)
        {
            if (ModelState.IsValid)
            {
                    db.Entry(group).State = EntityState.Modified;
                    db.SaveChanges();
                    return Content("SUCCESS");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult DeleteGroup(int? id, string formView)
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
        [HttpPost, ActionName("DeleteGroup")]
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
            return PartialView("_UserManage", group);
        }


        [HttpGet]
        public ActionResult AddUsers(int id)//GroupID GET Action
        {
            Group group = db.Groups.Find(id);
            return View(group);
        }

        [HttpPost]
        public ActionResult AddUsers(Group group, int[] inid)
        {
            try
            {
                if (inid != null)
                {
                    foreach (int i in inid)
                    {
                        var usergroup = new UserGroup { UserID = i, GroupID = group.GroupID };
                        db.UserGroups.Add(usergroup);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("AddUsers", new { id = group.GroupID });
            }
            catch (Exception ex)
            {
                Group dto = db.Groups.Find(group.GroupID);
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View(dto);
            }
        }

        [HttpPost]
        public ActionResult DeleteUserGroup(int groupid, int[] outid)
        {
            Group group = db.Groups.Find(groupid);
            try {
                if (outid != null)
                {
                    foreach (int i in outid)
                    {
                        var ug = db.UserGroups.Find(i);
                        db.UserGroups.Remove(ug);
                        db.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                Group dto = db.Groups.Find(group.GroupID);
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View(dto);
            }
            return RedirectToAction("AddUsers", new { id = groupid});
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
