using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq;      // imported to enable usage of ToList() function 
using System.Threading.Tasks;   // imported to allow asynchronous operation
using System.Web;
using System.Web.Mvc;
using CrudMVCCodeFirst.Data;
using CrudMVCCodeFirst.Models;

namespace CrudMVCCodeFirst.Controllers
{
    public class LaunchController : Controller
    {
        private readonly LaunchContext db = new LaunchContext();    // made 'db' immutable 

        // GET: Launch
        public ActionResult Index()
        {
            var Launches = db.Launches.ToList();    // improved readability
            return View(Launches);
        }

        // GET: Launch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaunchEntry launchEntry = db.Launches.Find(id);
            if (launchEntry == null)
            {
                return HttpNotFound();
            }
            return View(launchEntry);
        }

        //// GET: Launch/Create
        public ActionResult Create()
        {
            var user = this.User;
            return View();
        }

        // POST: Launch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LaunchInfo,PostedByUserName")] LaunchEntry launchEntry)
        {
            // launchEntry.PostedByUserName = this.User.Identity.Name;

            if (ModelState.IsValid)
            {
                SetPostedByUserName(launchEntry);
                db.Launches.Add(launchEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(launchEntry);
        }

        // GET: Launch/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // asynchronously retrieve the launch entry rather than lauching into memory and iterating
            var launchEntry = await db.Launches.FindAsync(id);

            if (launchEntry == null)
            {
                return HttpNotFound();
            }

            return View(launchEntry);
        }

        // POST: Launch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LaunchInfo,PostedByUserName")] LaunchEntry launchEntry)
        {

            if (ModelState.IsValid)
            {
                SetPostedByUserName(launchEntry);
                db.Entry(launchEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(launchEntry);
        }

        // GET: Launch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaunchEntry launchEntry = null;

            foreach(var launch in  db.Launches)
            {
                if (launch.Id == id)
                    launchEntry = launch;

            }


            return View(launchEntry);
        }

        // POST: Launch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            LaunchEntry launchEntry = db.Launches.Find(id);
            db.Launches.Remove(launchEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Private method to set PostedByUserName based on current user's identity
        private void SetPostedByUserName(LaunchEntry launchEntry)
        {
            launchEntry.PostedByUserName = User.Identity.Name;
        }


        // GET: Launch
        // This is a new feature that allows the searching the launches
        public ActionResult IndexForSearch(string searchTerm)
        {
            var launches = db.Launches.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                launches = launches.Where(l => l.LaunchInfo.Contains(searchTerm) || l.PostedByUserName.Contains(searchTerm));
            }

            return View(launches.ToList());
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
