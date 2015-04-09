using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignetSSRProject.Models;

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
