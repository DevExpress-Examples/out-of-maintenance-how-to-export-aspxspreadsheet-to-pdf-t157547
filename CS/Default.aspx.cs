using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraPrinting;
using DevExpress.Spreadsheet;

public partial class _Default : System.Web.UI.Page {

    protected void Spreadsheet_Init(object sender, EventArgs e) {
        if (!IsPostBack)
            Spreadsheet.Open(Server.MapPath("~/Sample.xlsx"));
    }
    protected void ExportButton_Click(object sender, EventArgs e) {
        using (MemoryStream ms = new MemoryStream()) {
            Spreadsheet.Document.SaveDocument(ms, DocumentFormat.Xlsm);
            ms.Position = 0;
            Workbook book = new Workbook();
            book.LoadDocument(ms, DocumentFormat.Xlsm);
            ms.Position = 0;
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = book;
            link.ExportToPdf(ms);

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