using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace T157547
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Spreadsheet.Open(Server.MapPath("~/App_Data/WorkDirectory/Sample.xlsx"));
        }

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Spreadsheet.Document.ExportToPdf(ms);

                ms.Seek(0, SeekOrigin.Begin);
                byte[] report = ms.ToArray();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Spreadsheet.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.OutputStream.Write(report, 0, report.Length);
                Response.End();
            }
        }
    }
}