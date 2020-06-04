@ModelType Company

@Code
    ViewBag.Title = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Company</h4>
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
            @Html.DisplayFor(Function(Model) Model.Phone)
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

    @Using (Html.BeginForm()) 
        @<text>
        @Html.AntiForgeryToken()

        <div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
        </text>
    End Using
</div>
 
