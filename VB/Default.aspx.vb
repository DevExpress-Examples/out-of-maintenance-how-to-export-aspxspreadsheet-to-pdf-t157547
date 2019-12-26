Imports System
Imports System.IO
Imports System.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Spreadsheet_Init(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			Spreadsheet.Open(Server.MapPath("~/Sample.xlsx"))
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