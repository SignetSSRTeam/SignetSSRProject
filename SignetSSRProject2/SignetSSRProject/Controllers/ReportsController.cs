using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignetSSRProject.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/
        public ActionResult Index()
        {
            //ViewData["Message"] = "Welcome to ssrs";
            //return View();
        //}
        //public ActionResult ReportListing()
        //{
        return Redirect("../Reports/ReportList.aspx");

    }
            
        }
	}
