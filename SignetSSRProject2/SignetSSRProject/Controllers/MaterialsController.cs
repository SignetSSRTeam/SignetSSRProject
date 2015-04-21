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

namespace SignetSSRProject.Controllers
{
    public class MaterialsController : Controller
    {
        private ISC567_SSRS_DatabaseEntities db = new ISC567_SSRS_DatabaseEntities();
        

        // GET: /Materials/
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

            var materialsexpenses = db.MaterialsExpenses.Include(m => m.ItemNumber).Include(m => m.Job);
            
            return View(materialsexpenses.ToList());
        }

        // GET: /Materials/MaterialsData
        public ContentResult MaterialsData()
        {
            var materialsExpenses = db.MaterialsExpenses.Include(m => m.ItemNumber).Include(m => m.Job);
            var materialsData = (from mat in materialsExpenses
                                 select new
                                 {
                                     mat.MaterialsExpenseID,
                                     mat.Expense,
                                     JobID = mat.Job.JobID,
                                     mat.ItemNumberID,
                                     mat.ExpenseDescription,
                                     mat.PONumber,
                                     mat.InvoiceNumber,
                                     mat.TaxIncluded,
                                     mat.TaxPercentage,
                                     mat.MarkupPercentage
                                 }).ToList();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(materialsData);
            return Content(output, "application/json");
        }

        //POST: /Materials/MaterialsData
        [HttpPost]
        public ContentResult InsertMaterialsData(MaterialsExpense materials)
        {
            var materialsExpenses = db.MaterialsExpenses.Include(m => m.Job);
            var job = db.Jobs;
            materials.ItemNumberID = 1; //Hard coding for now because there will be future changes in the database
            if (ModelState.IsValid)
            {
                db.MaterialsExpenses.Add(materials);
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
            string output = jsonSerializer.Serialize(materials);
            return Content(output, "application/json");

        }

        //POST: /Materials/UpdateMaterialsData
        [HttpPost]
        public ContentResult UpdateMaterialsData(MaterialsExpense materials)
        {
            
            materials.ItemNumberID = 1; //Hard coding for now because there will be future changes in the database
            if (ModelState.IsValid)
            {
                db.Entry(materials).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + err;
                    }
                }
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(materials);
            return Content(output, "application/json");

        }

        //POST: /Materials/MaterialsData
        [HttpPost]
        public ContentResult DeleteMaterialsData(MaterialsExpense materials)
        {
            var materialsExpenses = db.MaterialsExpenses.Include(m => m.Job);
            MaterialsExpense removeMaterials = db.MaterialsExpenses.Find(materials.MaterialsExpenseID);

            if (ModelState.IsValid)
            {
                db.MaterialsExpenses.Remove(removeMaterials);
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + err;
                    }
                }
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(removeMaterials);
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
