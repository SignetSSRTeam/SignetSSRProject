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
using System.Data.Entity.SqlServer;

namespace SignetSSRProject.Controllers
{
    
    public class HoursWorkedsController : Controller
    {
        private ISC567_SSRS_DatabaseEntities db = new ISC567_SSRS_DatabaseEntities();
        

        //// GET: HoursWorkeds
        public ActionResult Index()
        {
            var jobs = db.Jobs;
            var jobNum = (from j in jobs
                          select new
                          {
                              j.JobID,
                              j.JobNumber
                          }).ToList();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string jobNumbers = jsonSerializer.Serialize(jobNum);
            ViewBag.jobNumbers = jobNumbers;

            var employees = db.Employees;
            var empNames = (from emp in employees
                          select new
                          {
                              emp.EmployeeID,
                              EmployeeName = emp.FirstName + " " + emp.LastName
                          }).ToList();
            string employeeNames = jsonSerializer.Serialize(empNames);
            ViewBag.employeeNames = employeeNames;

            var hoursWorkeds = db.HoursWorkeds.Include(h => h.Employee).Include(h => h.Job);
            return View(hoursWorkeds.ToList());
        }

        //GET: HoursWorked



        public ContentResult HoursWorkedsData()
        {
            var hoursWorkeds = db.HoursWorkeds.Include(h => h.Employee).Include(h => h.Job);
            var hoursWorkedsData = (from hrs in hoursWorkeds
                                 select new
                                 {
                                     hrs.HoursWorkedID,
                                     EmployeeID = hrs.Employee.EmployeeID,
                                     JobID = hrs.Job.JobID,
                                     hrs.ItemNumber,
                                     Date = SqlFunctions.DateName("mm", hrs.Date) + " " +  SqlFunctions.DateName("day", hrs.Date) + ", " + SqlFunctions.DateName("year", hrs.Date),
                                     hrs.HoursWorkedRT,
                                     hrs.HoursWorkedOT,
                                     hrs.JobDescription
                                 }).ToList();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(hoursWorkedsData);
            return Content(output, "application/json");
        }

        //POST: /HoursWorked/InsertHoursWorkedData
        [HttpPost]
        public ContentResult InsertHoursWorkedsData(HoursWorked hoursWorked)
        {
            TryValidateModel(hoursWorked); //Hack to ignore empty employee and job fields 

            var wageHistoryID = db.WageHistories.Where(x => x.EmployeeID == hoursWorked.EmployeeID && x.IsCurrent == true).Select(x => x.WageHistoryID).FirstOrDefault();
            hoursWorked.WageHistoryID = wageHistoryID;

            if (ModelState.IsValid)
            {
                db.HoursWorkeds.Add(hoursWorked);
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + " \n" + err.ErrorMessage;
                    }
                }
                return Content("", "application/json");
            }

            //Form the hours worked data again for a single row and include the data conversions
            var hoursWorkeds = db.HoursWorkeds.Include(h => h.Employee).Include(h => h.Job);
            var hoursWorkedsData = (from hrs in hoursWorkeds
                                    where hrs.HoursWorkedID == hoursWorked.HoursWorkedID
                                    select new
                                    {
                                        hrs.HoursWorkedID,
                                        EmployeeID = hrs.Employee.EmployeeID,
                                        JobID = hrs.Job.JobID,
                                        hrs.ItemNumber,
                                        Date = SqlFunctions.DateName("mm", hrs.Date) + " " + SqlFunctions.DateName("day", hrs.Date) + ", " + SqlFunctions.DateName("year", hrs.Date),
                                        hrs.HoursWorkedRT,
                                        hrs.HoursWorkedOT,
                                        hrs.JobDescription
                                    }).SingleOrDefault();
            
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(hoursWorkedsData);
            return Content(output, "application/json");

        }

        //POST: /HoursWorked/UpdateHoursWorkedData
        [HttpPost]
        public ContentResult UpdateHoursWorkedsData(HoursWorked hoursWorked)
        {
            var wageHistoryID = db.WageHistories.Where(x => x.EmployeeID == hoursWorked.EmployeeID && x.IsCurrent == true).Select(x => x.WageHistoryID).FirstOrDefault();
            hoursWorked.WageHistoryID = wageHistoryID;

            if (ModelState.IsValid)
            {
                db.Entry(hoursWorked).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + " \n" + err.ErrorMessage;
                    }
                }
                return Content("", "application/json");
            }

            //Form the hours worked data again for a single row and include the data conversions
            var hoursWorkeds = db.HoursWorkeds.Include(h => h.Employee).Include(h => h.ItemNumber).Include(h => h.Job);
            var hoursWorkedsData = (from hrs in hoursWorkeds
                                    where hrs.HoursWorkedID == hoursWorked.HoursWorkedID
                                    select new
                                    {
                                        hrs.HoursWorkedID,
                                        EmployeeID = hrs.Employee.EmployeeID,
                                        JobID = hrs.Job.JobID,
                                        hrs.ItemNumber,
                                        Date = SqlFunctions.DateName("mm", hrs.Date) + " " + SqlFunctions.DateName("day", hrs.Date) + ", " + SqlFunctions.DateName("year", hrs.Date),
                                        hrs.HoursWorkedRT,
                                        hrs.HoursWorkedOT,
                                        hrs.JobDescription
                                    }).SingleOrDefault();

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(hoursWorkedsData);
            return Content(output, "application/json");

        }

        //POST: /HoursWorked/DeleteHoursWorkedData
        [HttpPost]
        public ContentResult DeleteHoursWorkedData(HoursWorked hoursWorked)
        {
            var hoursWorkedsData = db.HoursWorkeds.Include(h => h.Employee).Include(h => h.ItemNumber).Include(h => h.Job);
            HoursWorked removeHrsWorked = db.HoursWorkeds.Find(hoursWorked.HoursWorkedID);

            if (ModelState.IsValid)
            {
                db.HoursWorkeds.Remove(removeHrsWorked);
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + " \n" + err.ErrorMessage;
                    }
                }
                return Content("", "application/json");
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(removeHrsWorked);
            return Content(output, "application/json");

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
