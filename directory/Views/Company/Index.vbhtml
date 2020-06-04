@ModelType PagedList.IPagedList(Of Company)
@Imports PagedList
@Imports PagedList.Mvc

@Code
    ViewBag.Title = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h4>Company Directory</h4>

@Using (Html.BeginForm("Index", "Company", FormMethod.Get))
    @<text>
        <table class="table">
            <tr>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
                <td align="center">                    
                    @Html.DropDownList("SearchField", DirectCast(ViewData("SearchFields"), IEnumerable(Of SelectListItem)), New With {.style = "width:150px;height:33px"})
                    @Html.DropDownList("SearchCondition", DirectCast(ViewData("SearchConditions"), IEnumerable(Of SelectListItem)), New With {.style = "width:150px;height:33px"})
                    @Html.TextBox("SearchText", TryCast(ViewData("SearchText"), [String]), New With {.style = "width:100px;height:33px"})
                    <input type="submit" value="Search" name="command" class="btn btn-default" />
                    <input type="submit" value="Show All" name="command" class="btn btn-default" />
                </td>
                <td>&nbsp;</td>
                <td align="right">&nbsp;</td>
            </tr>
            <tr>
                <td align="left">
                    @Html.DropDownList("Export", DirectCast(ViewData("Exports"), IEnumerable(Of SelectListItem)), New With {.style = "width:65px;height:33px"})
                    <input type="submit" value="Export" name="command" class="btn btn-default" />
                </td>
                <td>&nbsp;</td>
                <td align="center">
                    <input type="submit" value="Add New Record" name="command" class="btn btn-default" />
                </td>
                <td>&nbsp;</td>
                <td align="right">
                    @Html.DropDownList("PageSize", DirectCast(ViewData("PageSizes"), IEnumerable(Of SelectListItem)), New With {.style = "width:50px;height:33px"})
                    <input type="submit" value="Page Size" name="command" class="btn btn-default" />
                </td>
            </tr>
        </table>
    </text>
End Using

<table class="table">
    <tr>
        @*<th>
            @Html.ActionLink("Company I D", "Index", New With { .sortOrder = ViewData("CompanyIDSortParm"), .SearchText = ViewData("SearchText") })
        </th>*@
        <th>
            @Html.ActionLink("Business Name", "Index", New With { .sortOrder = ViewData("BusinessNameSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Email", "Index", New With { .sortOrder = ViewData("EmailSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Phone", "Index", New With { .sortOrder = ViewData("PhoneSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Website", "Index", New With { .sortOrder = ViewData("WebsiteSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Rating", "Index", New With { .sortOrder = ViewData("RatingSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Reviews", "Index", New With { .sortOrder = ViewData("ReviewsSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Latitude", "Index", New With { .sortOrder = ViewData("LatitudeSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Longitude", "Index", New With { .sortOrder = ViewData("LongitudeSortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th>
            @Html.ActionLink("Category", "Index", New With { .sortOrder = ViewData("CategorySortParm"), .SearchText = ViewData("SearchText") })
        </th>
        <th></th>
    </tr>

    @For Each item In Model
    @<tr>
        @*<td>
            @Html.DisplayFor(Function(modelItem) item.CompanyID)
        </td>*@
        <td>
            @Html.DisplayFor(Function(modelItem) item.BusinessName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Phone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Website)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Rating)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Reviews)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Latitude)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Longitude)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Category)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {
 						.CompanyID = item.CompanyID 
 						}) |*@

            @Html.ActionLink("View Profile", "Details", New With {
                                  .CompanyID = item.CompanyID
                                  })
            @*|
            @Html.ActionLink("Delete", "Delete", New With {
 						.CompanyID = item.CompanyID 
 						})*@
        </td>
    </tr>
    Next

</table>

<table class="table">
    <tr>
        <td align="center">
            @Html.PagedListPager(Model, Function(page) Url.Action("Index", New With {page, .sortOrder = ViewData("CurrentSort"), .SearchText = ViewData("SearchText")}))
        </td>
    </tr>
</table>

 
