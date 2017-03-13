using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkoutBuilder.Data;
using WorkoutBuilder.Models;

namespace WorkoutBuilder.Controllers
{
    public class RepSetsController : Controller
    {
        private Context db = new Context();

        // GET: RepSets
        public ActionResult Index()
        {
            var repset = Repository.GetRepSet();

            return View(repset);
        }

        // GET: RepSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepSet repset = db.RepSets.Find(id);
            if (repset == null)
            {
                return HttpNotFound();
            }
            return View(repset);
        }

        // GET: RepSets/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepSets/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, Sets, Reps")] RepSet repset)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RepSets.Add(repset);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)

            {
                ModelState.AddModelError("", "Unable to save changes.  Try again");
            }
            return View(repset);
        }

        // GET: RepSets/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepSet repset = db.RepSets.Find(id);
            if (repset == null)
            {
                return HttpNotFound();
            }
            return View(repset);
        }

        // POST: RepSets/Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, RepSet repset)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var repSetToUpdate = db.RepSets.Find(id);
            if (TryUpdateModel(repSetToUpdate, "", new string[] { "Name", "Sets", "Reps" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (System.Data.DataException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes.  Try again.");
                }
            }
            return View(repSetToUpdate);

        }

        // POST: Exercises/Edit/5
        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "Name, Description")] Exercise exercise)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(exercise).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch
        //    {
        //        return View(exercise);
        //    }
        //}

        // GET: RepSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepSet repset = db.RepSets.Find(id);
            if (repset == null)
            {
                return HttpNotFound();
            }
            return View(repset);
        }

        // POST: Repsets/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RepSet repset = db.RepSets.Find(id);
            db.RepSets.Remove(repset);
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