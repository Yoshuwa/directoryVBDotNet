Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity

<Table("Company", Schema:="")>
Public Class Company

    <Key>
    <Column(Order:=0)>
    <Required>
    <Display(Name:="Company I D")>
    Public Property CompanyID() As Int32

    <StringLength(50)>
    <Display(Name:="Business Name")>
    Public Property BusinessName() As String

    <StringLength(50)>
    <Display(Name:="Email")>
    Public Property Email() As String

    <StringLength(11)>
    <Display(Name:="Phone")>
    Public Property Phone() As String

    <StringLength(50)>
    <Display(Name:="Website")>
    Public Property Website() As String

    <Display(Name:="Rating")>
    Public Property Rating() As Nullable(Of Int32)

    <Display(Name:="Reviews")>
    Public Property Reviews() As Nullable(Of Int32)

    <StringLength(50)>
    <Display(Name:="Latitude")>
    Public Property Latitude() As String

    <StringLength(50)>
    <Display(Name:="Longitude")>
    Public Property Longitude() As String

    <StringLength(50)>
    <Display(Name:="Category")>
    Public Property Category() As String


End Class
 
