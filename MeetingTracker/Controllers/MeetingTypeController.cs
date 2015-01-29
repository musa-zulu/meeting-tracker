using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MeetingTracker.Models;
using MeetingTracker.Context;

namespace MeetingTracker.Controllers
{
    public class MeetingTypeController : Controller
    {
        private MeetingContext db = new MeetingContext();

        // GET: /MeetingType/
        public ActionResult Index()
        {
            return View(db.MeetingTypes.ToList());
        }

        // GET: /MeetingType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingType meetingtype = db.MeetingTypes.Find(id);
            if (meetingtype == null)
            {
                return HttpNotFound();
            }
            return View(meetingtype);
        }

        // GET: /MeetingType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MeetingType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeetingTypeId,MeetingTypeDescription")] MeetingType meetingtype)
        {
            if (ModelState.IsValid)
            {
                db.MeetingTypes.Add(meetingtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetingtype);
        }

        // GET: /MeetingType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingType meetingtype = db.MeetingTypes.Find(id);
            if (meetingtype == null)
            {
                return HttpNotFound();
            }
            return View(meetingtype);
        }

        // POST: /MeetingType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeetingTypeId,MeetingTypeDescription")] MeetingType meetingtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetingtype);
        }

        // GET: /MeetingType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingType meetingtype = db.MeetingTypes.Find(id);
            if (meetingtype == null)
            {
                return HttpNotFound();
            }
            return View(meetingtype);
        }

        // POST: /MeetingType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingType meetingtype = db.MeetingTypes.Find(id);
            db.MeetingTypes.Remove(meetingtype);
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
