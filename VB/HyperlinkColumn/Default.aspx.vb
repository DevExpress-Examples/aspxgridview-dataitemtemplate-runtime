Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Namespace HyperlinkColumn
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Protected Sub ASPxGridView1_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.KeyFieldName = "ID"
			ASPxGridView1.DataSource = GetData()
			If (Not IsPostBack) AndAlso (Not IsCallback) Then
				PopulateColumns()
				ASPxGridView1.DataBind()
			Else
				CreateTemplate()
			End If
		End Sub

		Public Function GetData() As DataTable
			Dim Table As New DataTable()
			Table.Columns.Add("ID", GetType(Integer))
			Table.Rows.Add(1)
			Table.Rows.Add(2)
			Return Table
		End Function

		Public Sub PopulateColumns()
			Dim colID As New GridViewDataTextColumn()
			colID.FieldName = "ID"
			ASPxGridView1.Columns.Add(colID)

			Dim colItemTemplate As New GridViewDataTextColumn()
			colItemTemplate.DataItemTemplate = New MyHyperlinkTemplate() ' Create a template
			colItemTemplate.Name = "colItemTemplate"
			colItemTemplate.Caption = "Template Column"
			ASPxGridView1.Columns.Add(colItemTemplate)
		End Sub

		Private Sub CreateTemplate()
			CType(ASPxGridView1.Columns("colItemTemplate"), GridViewDataColumn).DataItemTemplate = New MyHyperlinkTemplate()
		End Sub
	End Class

	Friend Class MyHyperlinkTemplate
		Implements ITemplate
		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim link As New ASPxHyperLink()
			Dim gridContainer As GridViewDataItemTemplateContainer = CType(container, GridViewDataItemTemplateContainer)
			link.NavigateUrl = String.Format("~/details.aspx?Device={0}", gridContainer.KeyValue)
			link.Text = String.Format("Get details about device {0}", gridContainer.KeyValue)
			container.Controls.Add(link)
		End Sub
	End Class
End Namespace
