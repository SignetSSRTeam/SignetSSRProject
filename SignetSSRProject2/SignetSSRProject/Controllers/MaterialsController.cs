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
                                     mat.Expense,
                                     JobID = mat.Job.JobNumber,
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
        public void MaterialsData(MaterialsExpense materials)
        {
            //var materialsExpenses = db.MaterialsExpenses.Include(m => m.ItemNumber).Include(m => m.Job);
            //var materialsJobNumber = materials.JobID.ToString();

            //var materialsJobID = (from mat in materialsExpenses
            //                      where mat.Job.JobNumber == materialsJobNumber
            //                      select                                 
            //                            mat.Job.JobID                                     
            //                     ).SingleOrDefault();
            //materials.JobID = Convert.ToInt32(materialsJobID);
            //materials.ItemNumberID = 1; //Hard coding for now because there will be future changes in the database
            //if (ModelState.IsValid)
            //{
            //    db.MaterialsExpenses.Add(materials);
            //    db.SaveChanges();
            //}
            //else
            //{
            //    string error = "";
            //    foreach (ModelState modelState in ViewData.ModelState.Values)
            //    {
            //        foreach (ModelError err in modelState.Errors)
            //        {
            //            error = error + err;
            //        }
            //    }
            //}

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
