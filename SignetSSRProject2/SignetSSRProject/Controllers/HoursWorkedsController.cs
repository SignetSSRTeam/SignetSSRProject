using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignetSSRProject.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SignetSSRProject.Controllers
{
    
    public class HoursWorkedsController : Controller
    {
        private ISC567_SSRS_DatabaseEntities db = new ISC567_SSRS_DatabaseEntities();
        

        //// GET: HoursWorkeds
        public ActionResult Index()
        {
            var hoursWorkeds = db.HoursWorkeds.Include(h => h.Employee).Include(h => h.ItemNumber).Include(h => h.Job);
            return View(hoursWorkeds.ToList());
        }

        //GET: HoursWorked



        //public ContentResult HoursWorkedData()
        //{
        //    var hoursWorkeds = db.HoursWorkeds.Include(h => h.Employee).Include(h => h.ItemNumber).Include(h => h.Job);
        //    var hoursWorkedsData = (from hrs in hoursWorkeds)
                                   // select new
                                   // {
                                    
                                   // }
            
            //db.Configuration.ProxyCreationEnabled = false;
            //JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            //string output = jsonSerializer.Serialize(db.HoursWorkeds.ToList());
            //return Json(Content(output, "application/json"), JsonRequestBehavior.AllowGet);
            
        }

        // GET: HoursWorkeds/Details/5

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
        //    if (hoursWorked == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hoursWorked);
        //}

        //// GET: HoursWorkeds/Create
        //public ActionResult Create()
        //{
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
        //    ViewBag.ItemNumberID = new SelectList(db.ItemNumbers, "ItemNumberID", "Description");
        //    ViewBag.JobID = new SelectList(db.Jobs, "JobID", "JobNumber");
        //    return View();
        //}

        //// POST: HoursWorkeds/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "HoursWorkedID,EmployeeID,JobID,ItemNumberID,Date,HoursWorkedRT,HoursWorkedOT")] HoursWorked hoursWorked)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.HoursWorkeds.Add(hoursWorked);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", hoursWorked.EmployeeID);
        //    ViewBag.ItemNumberID = new SelectList(db.ItemNumbers, "ItemNumberID", "Description", hoursWorked.ItemNumberID);
        //    ViewBag.JobID = new SelectList(db.Jobs, "JobID", "JobNumber", hoursWorked.JobID);
        //    return View(hoursWorked);
        //}

        //// GET: HoursWorkeds/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
        //    if (hoursWorked == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", hoursWorked.EmployeeID);
        //    ViewBag.ItemNumberID = new SelectList(db.ItemNumbers, "ItemNumberID", "Description", hoursWorked.ItemNumberID);
        //    ViewBag.JobID = new SelectList(db.Jobs, "JobID", "JobNumber", hoursWorked.JobID);
        //    return View(hoursWorked);
        //}

        //// POST: HoursWorkeds/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "HoursWorkedID,EmployeeID,JobID,ItemNumberID,Date,HoursWorkedRT,HoursWorkedOT")] HoursWorked hoursWorked)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(hoursWorked).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", hoursWorked.EmployeeID);
        //    ViewBag.ItemNumberID = new SelectList(db.ItemNumbers, "ItemNumberID", "Description", hoursWorked.ItemNumberID);
        //    ViewBag.JobID = new SelectList(db.Jobs, "JobID", "JobNumber", hoursWorked.JobID);
        //    return View(hoursWorked);
        //}

        //// GET: HoursWorkeds/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
        //    if (hoursWorked == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hoursWorked);
        //}

        //// POST: HoursWorkeds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
        //    db.HoursWorkeds.Remove(hoursWorked);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
   // }
}
