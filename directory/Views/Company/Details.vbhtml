@ModelType Company

@Code
    ViewBag.Title = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

    <h2>  @Html.DisplayFor(Function(Model) Model.BusinessName)</h2>

<div>
    @*<h4>Company</h4>*@
	<hr />
    <dl class="dl-horizontal">
        @Html.HiddenFor(Function(Model) Model.CompanyID)

        <dt>
            @Html.DisplayNameFor(Function(Model) Model.BusinessName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.BusinessName)
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.Email)
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Phone)
        </dt>

        <dd>
            <a href="tel:@Html.DisplayFor(Function(Model) Model.Phone)">@Html.DisplayFor(Function(Model) Model.Phone)</a> 
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Website)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.Website)
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Rating)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.Rating)
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Reviews)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.Reviews)
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Latitude)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.Latitude)
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Longitude)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.Longitude)
        <dt>
            @Html.DisplayNameFor(Function(Model) Model.Category)
        </dt>

        <dd>
            @Html.DisplayFor(Function(Model) Model.Category)
    </dl>
</div>
<p>
            @Html.ActionLink("Edit", "Edit", New With {
 						.CompanyID = Model.CompanyID 
 						}) |
    @Html.ActionLink("Back to List", "Index")
</p>
 
