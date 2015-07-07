using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Collections.Specialized.NameValueCollection;
//using System.Web.UI.Page;
//using System.Web.UI.ScriptManager;

using Microsoft.Reporting.WebForms;

namespace SignetSSRProject.Reports
{
    public partial class Reportweb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        string Jobtype = HttpContext.Current.Request.QueryString["Jobtype"];
        string Begindate =HttpContext.Current. Request.QueryString["Begindate"];
        string Enddate = HttpContext.Current.Request.QueryString["Enddate"];
   


        /*protected void get_reports_Click(object sender, EventArgs e)
        {
            try
            {

                myReportViewer.ProcessingMode = ProcessingMode.Remote;

                myReportViewer.ServerReport.ReportServerUrl = new Uri("http://dileepthani9369:80/ReportServer");

                myReportViewer.ServerReport.ReportPath = "/SSRS Project/Report1";

                myReportViewer.ServerReport.Refresh();

            }

            catch (Exception ex)
            {

                Response.Write(ex.ToString());

            }
        }*/
        
    }
}