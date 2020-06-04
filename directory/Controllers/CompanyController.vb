Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.IO
Imports PagedList
Imports PagedList.Mvc
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.Rendering

Public Class CompanyController
    Inherits Controller

    Private dtCompany As New DataTable

    ' GET: /Company/
    Public Function Index(sortOrder As String,  
                          SearchField As String, 
                          SearchCondition As String,
                          SearchText As String,
                          Export As String,
                          PageSize As Nullable(Of Integer),
                          page As Nullable(Of Integer),
                          command As String) As ActionResult

        If command = "Show All" Then
            SearchField = Nothing
            SearchCondition = Nothing
            SearchText = Nothing
            Session("SearchField") = Nothing
            Session("SearchCondition") = Nothing
            Session("SearchText") = Nothing
        ElseIf command = "Add New Record" Then
            Return RedirectToAction("Create")
        ElseIf command = "Export" Then
            Session("Export") = Export
        ElseIf command = "Search" Or command = "Page Size" Then
            If Not String.IsNullOrEmpty(SearchText) Then
                Session("SearchField") = SearchField
                Session("SearchCondition") = SearchCondition
                Session("SearchText") = SearchText
            End If
        End If
        If command = "Page Size" Then
            Session("PageSize") = PageSize
        End If

        ViewData("SearchFields") = GetFields(If(String.IsNullOrEmpty(CStr(Session("SearchField"))) = True, "Company I D", CStr(Session("SearchField"))))
        ViewData("SearchConditions") = Library.GetConditions(If(String.IsNullOrEmpty(CStr(Session("SearchCondition"))) = True, "Contains", CStr(Session("SearchCondition"))))
        ViewData("SearchText") = Session("SearchText")
        ViewData("Exports") = Library.GetExports(If(String.IsNullOrEmpty(CStr(Session("Export"))) = True, "Pdf", CStr(Session("Export"))))
        ViewData("PageSizes") = Library.GetPageSizes()

        ViewData("CurrentSort") = sortOrder
        ViewData("CompanyIDSortParm") = If(sortOrder = "CompanyID_asc", "CompanyID_desc", "CompanyID_asc")
        ViewData("BusinessNameSortParm") = If(sortOrder = "BusinessName_asc", "BusinessName_desc", "BusinessName_asc")
        ViewData("EmailSortParm") = If(sortOrder = "Email_asc", "Email_desc", "Email_asc")
        ViewData("PhoneSortParm") = If(sortOrder = "Phone_asc", "Phone_desc", "Phone_asc")
        ViewData("WebsiteSortParm") = If(sortOrder = "Website_asc", "Website_desc", "Website_asc")
        ViewData("RatingSortParm") = If(sortOrder = "Rating_asc", "Rating_desc", "Rating_asc")
        ViewData("ReviewsSortParm") = If(sortOrder = "Reviews_asc", "Reviews_desc", "Reviews_asc")
        ViewData("LatitudeSortParm") = If(sortOrder = "Latitude_asc", "Latitude_desc", "Latitude_asc")
        ViewData("LongitudeSortParm") = If(sortOrder = "Longitude_asc", "Longitude_desc", "Longitude_asc")
        ViewData("CategorySortParm") = If(sortOrder = "Category_asc", "Category_desc", "Category_asc")

        dtCompany = CompanyData.SelectAll()

        Try
            If Not String.IsNullOrEmpty(CStr(Session("SearchField"))) And Not String.IsNullOrEmpty(CStr(Session("SearchCondition"))) And Not String.IsNullOrEmpty(CStr(Session("SearchText"))) Then
                dtCompany = CompanyData.Search(CStr(Session("SearchField")), CStr(Session("SearchCondition")), CStr(Session("SearchText")))
            End If
        Catch ex As Exception
        End Try

        Dim Query = From rowCompany In dtCompany.AsEnumerable()
                    Select New Company() With { _
                            .CompanyID = rowCompany.Field(Of Int32)("CompanyID") _
                           ,.BusinessName = rowCompany.Field(Of String)("BusinessName") _
                           ,.Email = rowCompany.Field(Of String)("Email") _
                           ,.Phone = rowCompany.Field(Of String)("Phone") _
                           ,.Website = rowCompany.Field(Of String)("Website") _
                           ,.Rating = rowCompany.Field(Of Int32?)("Rating") _
                           ,.Reviews = rowCompany.Field(Of Int32?)("Reviews") _
                           ,.Latitude = rowCompany.Field(Of String)("Latitude") _
                           ,.Longitude = rowCompany.Field(Of String)("Longitude") _
                           ,.Category = rowCompany.Field(Of String)("Category") _
                    }

        Select Case sortOrder
            Case "CompanyID_desc":
                Query = Query.OrderByDescending(Function(s) s.CompanyID)
                Exit Select
            Case "CompanyID_asc":
                Query = Query.OrderBy(Function(s) s.CompanyID)
                Exit Select
            Case "BusinessName_desc":
                Query = Query.OrderByDescending(Function(s) s.BusinessName)
                Exit Select
            Case "BusinessName_asc":
                Query = Query.OrderBy(Function(s) s.BusinessName)
                Exit Select
            Case "Email_desc":
                Query = Query.OrderByDescending(Function(s) s.Email)
                Exit Select
            Case "Email_asc":
                Query = Query.OrderBy(Function(s) s.Email)
                Exit Select
            Case "Phone_desc":
                Query = Query.OrderByDescending(Function(s) s.Phone)
                Exit Select
            Case "Phone_asc":
                Query = Query.OrderBy(Function(s) s.Phone)
                Exit Select
            Case "Website_desc":
                Query = Query.OrderByDescending(Function(s) s.Website)
                Exit Select
            Case "Website_asc":
                Query = Query.OrderBy(Function(s) s.Website)
                Exit Select
            Case "Rating_desc":
                Query = Query.OrderByDescending(Function(s) s.Rating)
                Exit Select
            Case "Rating_asc":
                Query = Query.OrderBy(Function(s) s.Rating)
                Exit Select
            Case "Reviews_desc":
                Query = Query.OrderByDescending(Function(s) s.Reviews)
                Exit Select
            Case "Reviews_asc":
                Query = Query.OrderBy(Function(s) s.Reviews)
                Exit Select
            Case "Latitude_desc":
                Query = Query.OrderByDescending(Function(s) s.Latitude)
                Exit Select
            Case "Latitude_asc":
                Query = Query.OrderBy(Function(s) s.Latitude)
                Exit Select
            Case "Longitude_desc":
                Query = Query.OrderByDescending(Function(s) s.Longitude)
                Exit Select
            Case "Longitude_asc":
                Query = Query.OrderBy(Function(s) s.Longitude)
                Exit Select
            Case "Category_desc":
                Query = Query.OrderByDescending(Function(s) s.Category)
                Exit Select
            Case "Category_asc":
                Query = Query.OrderBy(Function(s) s.Category)
                Exit Select
            Case Else
                ' Name ascending 
                Query = Query.OrderBy(Function(s) s.CompanyID)
                Exit Select
        End Select

        If command = "Export" Then
            Dim gv As New GridView()
            Dim dt As New DataTable()
            'dt.Columns.Add("Company I D", GetType(String))
            dt.Columns.Add("Business Name", GetType(String))
            dt.Columns.Add("Email", GetType(String))
            dt.Columns.Add("Phone", GetType(String))
            dt.Columns.Add("Website", GetType(String))
            dt.Columns.Add("Rating", GetType(String))
            dt.Columns.Add("Reviews", GetType(String))
            dt.Columns.Add("Latitude", GetType(String))
            dt.Columns.Add("Longitude", GetType(String))
            dt.Columns.Add("Category", GetType(String))
            For Each item In Query
                dt.Rows.Add(
                        item.CompanyID _
                       ,item.BusinessName _
                       ,item.Email _
                       ,item.Phone _
                       ,item.Website _
                       ,item.Rating _
                       ,item.Reviews _
                       ,item.Latitude _
                       ,item.Longitude _
                       ,item.Category _
                    )
            Next
            gv.DataSource = dt
            gv.DataBind()
            ExportData(Export, gv, dt)
        End If

        Dim pageNumber As Integer = (If(page, 1))
        Return View(Query.ToPagedList(pageNumber, CInt((If(Session("PageSize"), 50)))))
    End Function

    ' GET: /Company/Details/<id>
    Public Function Details(
                           CompanyID As Nullable(Of Int32) _
                           ) As ActionResult

        If _
            CompanyID Is Nothing _
        Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If


        Dim Company As New Company()
        Company.CompanyID = System.Convert.ToInt32(CompanyID)
        Company = CompanyData.Select_Record(Company)

        If Company Is Nothing Then
            Return HttpNotFound()
        End If
        Return View(Company)
    End Function

    ' GET: /Company/Create
    Public Function Create() As ActionResult

        Return View()
    End Function

    ' POST: /Company/Create
    ' To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    ' more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost> _
    <ValidateAntiForgeryToken> _
    Public Function Create(<Bind(Include:=
                                   "BusinessName" _
                           + "," + "Email" _
                           + "," + "Phone" _
                           + "," + "Website" _
                           + "," + "Rating" _
                           + "," + "Reviews" _
                           + "," + "Latitude" _
                           + "," + "Longitude" _
                           + "," + "Category" _
				  )> Company As Company) As ActionResult

        If ModelState.IsValid Then
            Dim bSucess As Boolean
            bSucess = CompanyData.Add(Company)
            If bSucess = True Then
                Return RedirectToAction("Index")
            Else
                ModelState.AddModelError("", "Can Not Insert")
            End If
        End If

        Return View(Company)
    End Function

    ' GET: /Company/Edit/<id>
    Public Function Edit(
                        CompanyID As Nullable(Of Int32) _
                        ) As ActionResult

        If _
            CompanyID Is Nothing _
        Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If

        Dim Company As New Company
        Company.CompanyID = System.Convert.ToInt32(CompanyID)
        Company = CompanyData.Select_Record(Company)

        If Company Is Nothing Then
            Return HttpNotFound()
        End If

        Return View(Company)
    End Function

    ' POST: /Company/Edit/<id>
    ' To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    ' more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost, ActionName("Edit")> _
    <ValidateAntiForgeryToken> _
    Public Function Edit(Company As Company) As ActionResult

        Dim oCompany As New Company
        oCompany.CompanyID = System.Convert.ToInt32(Company.CompanyID)
        oCompany = CompanyData.Select_Record(oCompany)

        If ModelState.IsValid Then
            Dim bSucess As Boolean
            bSucess = CompanyData.Update(oCompany, Company)
            If bSucess = True Then
                Return RedirectToAction("Index")
            Else
                ModelState.AddModelError("", "Can Not Update")
            End If
        End If


        Return View(Company)
    End Function

    ' GET: /Company/Delete/<id>
    Public Function Delete(
                           CompanyID As Nullable(Of Int32) _
                           ) As ActionResult

        If _
            CompanyID Is Nothing _
        Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If


        Dim Company As New Company()
        Company.CompanyID = System.Convert.ToInt32(CompanyID)
        Company = CompanyData.Select_Record(Company)

        If Company Is Nothing Then
            Return HttpNotFound()
        End If
        Return View(Company)
    End Function

    ' POST: /Company/Delete/<id>
    <HttpPost, ActionName("Delete")> _
    <ValidateAntiForgeryToken> _
    Public Function DeleteConfirmed(
                                   CompanyID As Nullable(Of Int32) _
                                   ) As ActionResult

        Dim Company As New Company
        Company.CompanyID = System.Convert.ToInt32(CompanyID)
        Company = CompanyData.Select_Record(Company)

        Dim bSucess As Boolean
        bSucess = CompanyData.Delete(Company)
        If bSucess = True Then
            Return RedirectToAction("Index")
        Else
            ModelState.AddModelError("", "Can Not Delete")
        End If
        Return Nothing
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    Private Shared Function GetFields(selected As String) As List(Of SelectListItem)
        Dim list As New List(Of SelectListItem)
        'Dim Item1 As SelectListItem = New SelectListItem With {.Text = "Company I D", .Value = "Company I D"}
        Dim Item2 As SelectListItem = New SelectListItem With {.Text = "Business Name", .Value = "Business Name"}
        Dim Item3 As SelectListItem = New SelectListItem With {.Text = "Email", .Value = "Email"}
        Dim Item4 As SelectListItem = New SelectListItem With {.Text = "Phone", .Value = "Phone"}
        Dim Item5 As SelectListItem = New SelectListItem With {.Text = "Website", .Value = "Website"}
        Dim Item6 As SelectListItem = New SelectListItem With {.Text = "Rating", .Value = "Rating"}
        Dim Item7 As SelectListItem = New SelectListItem With {.Text = "Reviews", .Value = "Reviews"}
        Dim Item8 As SelectListItem = New SelectListItem With {.Text = "Latitude", .Value = "Latitude"}
        Dim Item9 As SelectListItem = New SelectListItem With {.Text = "Longitude", .Value = "Longitude"}
        Dim Item10 As SelectListItem = New SelectListItem With {.Text = "Category", .Value = "Category"}

        If selected = "Business Name" Then
            Item2.Selected = True
        ElseIf selected = "Email" Then
            Item3.Selected = True
        ElseIf selected = "Phone" Then
            Item4.Selected = True
        ElseIf selected = "Website" Then
            Item5.Selected = True
        ElseIf selected = "Rating" Then
            Item6.Selected = True
        ElseIf selected = "Reviews" Then
            Item7.Selected = True
        ElseIf selected = "Latitude" Then
            Item8.Selected = True
        ElseIf selected = "Longitude" Then
            Item9.Selected = True
        ElseIf selected = "Category" Then
            Item10.Selected = True
        End If

        ' list.Add(Item1)
        list.Add(Item2)
        list.Add(Item3)
        list.Add(Item4)
        list.Add(Item5)
        list.Add(Item6)
        list.Add(Item7)
        list.Add(Item8)
        list.Add(Item9)
        list.Add(Item10)

        Return list.ToList()
    End Function

    Private Sub ExportData(Export As [String], gv As GridView, dt As DataTable)
        If Export = "Pdf" Then
            Dim pdfForm As New PDFform(dt, "Dbo. Company", "Many")
            Dim document As Document = pdfForm.CreateDocument()
            Dim renderer As New PdfDocumentRenderer(True)
            renderer.Document = document
            renderer.RenderDocument()

            Dim stream As New MemoryStream()
            renderer.PdfDocument.Save(stream, False)

            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=" + "Report.pdf")
            Response.ContentType = "application/Pdf.pdf"
            Response.BinaryWrite(stream.ToArray())
            Response.Flush()
            Response.[End]()
        Else
            Response.ClearContent()
            Response.Buffer = True
            If Export = "Excel" Then
                Response.AddHeader("content-disposition", "attachment;filename=" + "Report.xls")
                Response.ContentType = "application/Excel.xls"
            ElseIf Export = "Word" Then
                Response.AddHeader("content-disposition", "attachment;filename=" + "Report.doc")
                Response.ContentType = "application/Word.doc"
            End If
            Response.Charset = ""
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            gv.RenderControl(htw)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        End If
    End Sub

End Class
 
