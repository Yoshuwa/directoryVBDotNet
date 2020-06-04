Imports System.Globalization
Imports System.Xml
Imports System.Xml.XPath
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes
Imports MigraDoc.Rendering
Imports System.Diagnostics
Imports System.Data

Public Class PDFform
    Public Sub New()
    End Sub

    Private document As Document
    Private dt As DataTable
    Private table As Table
    Private Title As String
    Private OneORMany As String

    Public Sub New(dtIn As DataTable, Name As [String], Type As String)
        dt = dtIn
        Title = Name
        OneORMany = Type
    End Sub

    Public Function CreateDocument() As Document
        Me.document = New Document()
        DefineStyles()
        CreatePage(OneORMany)
        FillContent()
        Return Me.document
    End Function

    Private Sub DefineStyles()
        Dim style As Style = Me.document.Styles("Normal")
        style.Font.Name = "Verdana"

        style = Me.document.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Verdana"
        style.Font.Name = "Times New Roman"
        style.Font.Size = 8

        style = Me.document.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceAfter = "5mm"
    End Sub

    Private Sub CreatePage(ByVal Type As String)
        Dim pageSetup As PageSetup = Me.document.DefaultPageSetup.Clone()
        If OneORMany = "One" Then
            pageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait
        Else
            pageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape
        End If
        Dim section As Section = Me.document.AddSection()
        section.PageSetup.Orientation = pageSetup.Orientation
        Dim paragraph As Paragraph = section.Headers.Primary.AddParagraph()
        paragraph.Style = "Reference"
        paragraph.AddFormattedText(Title, TextFormat.Bold)

        Me.table = section.AddTable()
        Me.table.Style = "Table"
        Me.table.Borders.Width = 0.25
        Me.table.Borders.Left.Width = 0.5
        Me.table.Borders.Right.Width = 0.5
        Me.table.Rows.LeftIndent = 0

        Dim column As Column
        If OneORMany = "One" Then
            column = Me.table.AddColumn(100)
            column.Format.Alignment = ParagraphAlignment.Center
            column = Me.table.AddColumn(350)
            column.Format.Alignment = ParagraphAlignment.Center
        Else
            For Each col As DataColumn In dt.Columns
                column = Me.table.AddColumn()
                column.Format.Alignment = ParagraphAlignment.Center
            Next
        End If

        ' Create the header of the table
        Dim row As Row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Shading.Color = TableBlue

        For i As Integer = 0 To dt.Columns.Count - 1
            row.Cells(i).AddParagraph(dt.Columns(i).ColumnName)
            row.Cells(i).Format.Font.Bold = True
            row.Cells(i).Format.Alignment = ParagraphAlignment.Left
            row.Cells(i).VerticalAlignment = VerticalAlignment.Bottom
        Next

        Me.table.SetEdge(0, 0, dt.Columns.Count, 1, Edge.Box, BorderStyle.[Single], 0.75)
    End Sub

    Private Sub FillContent()
        Dim row1 As Row
        For i As Integer = 0 To dt.Rows.Count - 1
            row1 = Me.table.AddRow()
            row1.TopPadding = 1.5
            For j As Integer = 0 To dt.Columns.Count - 1
                row1.Cells(j).Shading.Color = Color.Empty
                row1.Cells(j).VerticalAlignment = VerticalAlignment.Center
                row1.Cells(j).Format.Alignment = ParagraphAlignment.Left
                row1.Cells(j).Format.FirstLineIndent = 1
                row1.Cells(j).AddParagraph(dt.Rows(i)(j).ToString())
                Me.table.SetEdge(0, Me.table.Rows.Count - 2, dt.Columns.Count, 1, Edge.Box, BorderStyle.[Single], _
                    0.75)
            Next
        Next
    End Sub

    ' Some pre-defined colors
#If True Then
    ' RGB colors
    Shared ReadOnly TableBorder As New Color(81, 125, 192)
    Shared ReadOnly TableBlue As New Color(235, 240, 249)
    Shared ReadOnly TableGray As New Color(242, 242, 242)
#Else
    ' CMYK colors
    Shared ReadOnly tableBorder As Color = Color.FromCmyk(100, 50, 0, 30)
    Shared ReadOnly tableBlue As Color = Color.FromCmyk(0, 80, 50, 30)
    Shared ReadOnly tableGray As Color = Color.FromCmyk(30, 0, 0, 0, 100)
#End If
End Class

