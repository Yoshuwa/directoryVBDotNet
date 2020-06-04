Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Reflection
Imports System.Web
Imports System.Web.Mvc

Public Class Library
    Public Shared Function GetConditions(selected As String) As List(Of SelectListItem)
        Dim list As New List(Of SelectListItem)
        Dim Item1 As SelectListItem = New SelectListItem With {.Text = "Contains", .Value = "Contains"}
        Dim Item2 As SelectListItem = New SelectListItem With {.Text = "Equals", .Value = "Equals"}
        Dim Item3 As SelectListItem = New SelectListItem With {.Text = "Starts with...", .Value = "Starts with..."}
        Dim Item4 As SelectListItem = New SelectListItem With {.Text = "More than...", .Value = "More than..."}
        Dim Item5 As SelectListItem = New SelectListItem With {.Text = "Less than...", .Value = "Less than..."}
        Dim Item6 As SelectListItem = New SelectListItem With {.Text = "Equal or more than...", .Value = "Equal or more than..."}
        Dim Item7 As SelectListItem = New SelectListItem With {.Text = "Equal or less than...", .Value = "Equal or less than..."}

        If selected = "Contains" Then
            Item1.Selected = True
        ElseIf selected = "Equals" Then
            Item2.Selected = True
        ElseIf selected = "Starts with..." Then
            Item3.Selected = True
        ElseIf selected = "More than..." Then
            Item4.Selected = True
        ElseIf selected = "Less than..." Then
            Item5.Selected = True
        ElseIf selected = "Equal or more than..." Then
            Item6.Selected = True
        ElseIf selected = "Equal or less than..." Then
            Item7.Selected = True
        End If

        list.Add(Item1)
        list.Add(Item2)
        list.Add(Item3)
        list.Add(Item4)
        list.Add(Item5)
        list.Add(Item6)
        list.Add(Item7)

        Return list.ToList()
    End Function

    Public Shared Function GetExports(selected As String) As List(Of SelectListItem)
        Dim list As New List(Of SelectListItem)
        Dim Item1 As SelectListItem = New SelectListItem With {.Text = "Pdf", .Value = "Pdf"}
        Dim Item2 As SelectListItem = New SelectListItem With {.Text = "Excel", .Value = "Excel"}
        Dim Item3 As SelectListItem = New SelectListItem With {.Text = "Word", .Value = "Word"}

        If selected = "Pdf" Then
            Item1.Selected = True
        ElseIf selected = "Excel" Then
            Item2.Selected = True
        ElseIf selected = "Word" Then
            Item3.Selected = True
        End If

        list.Add(Item1)
        list.Add(Item2)
        list.Add(Item3)

        Return list.ToList()
    End Function

    Public Shared Function GetPageSizes() As List(Of SelectListItem)
        Dim pagesizes As New List(Of SelectListItem)
        pagesizes.Add(New SelectListItem With {.Text = "5", .Value = "5"})
        pagesizes.Add(New SelectListItem With {.Text = "10", .Value = "10"})
        pagesizes.Add(New SelectListItem With {.Text = "25", .Value = "25"})
        pagesizes.Add(New SelectListItem With {.Text = "50", .Value = "50"})
        pagesizes.Add(New SelectListItem With {.Text = "100", .Value = "100"})
        pagesizes.Add(New SelectListItem With {.Text = "500", .Value = "500"})
        Return pagesizes.ToList()
    End Function

    Public Shared Function ToDataTable(Of T)(items As List(Of T)) As DataTable
        Dim dataTable As New DataTable(GetType(T).Name)

        'Get all the properties
        Dim Props As PropertyInfo() = GetType(T).GetProperties(BindingFlags.[Public] Or BindingFlags.Instance)
        For Each prop As PropertyInfo In Props
            'Setting column names as Property names
            dataTable.Columns.Add(prop.Name)
        Next
        For Each item As T In items
            Dim values = New Object(Props.Length - 1) {}
            For i As Integer = 0 To Props.Length - 1
                'inserting property values to datatable rows
                values(i) = Props(i).GetValue(item, Nothing)
            Next
            dataTable.Rows.Add(values)
        Next
        'put a breakpoint here and check datatable
        Return dataTable
    End Function

End Class

