Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace T157547
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If Not IsPostBack Then
				Spreadsheet.Open(Server.MapPath("~/App_Data/WorkDirectory/Sample.xlsx"))
			End If
		End Sub

		Protected Sub ExportButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Using ms As New MemoryStream()
				Spreadsheet.Document.ExportToPdf(ms)

				ms.Seek(0, SeekOrigin.Begin)
				Dim report() As Byte = ms.ToArray()

				Response.ContentType = "application/pdf"
				Response.AddHeader("content-disposition", "attachment;filename=Spreadsheet.pdf")
				Response.Cache.SetCacheability(HttpCacheability.NoCache)
				Response.OutputStream.Write(report, 0, report.Length)
				Response.End()
			End Using
		End Sub
	End Class
End Namespace