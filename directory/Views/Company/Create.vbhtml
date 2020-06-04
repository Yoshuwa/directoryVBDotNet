@ModelType Company

@Code
    ViewBag.Title = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>


@Using (Html.BeginForm()) 
    @<text>
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>Company</h4>
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(Model) Model.CompanyID)

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.BusinessName, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.BusinessName)
                @Html.ValidationMessageFor(Function(Model) Model.BusinessName)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Email, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Email)
                @Html.ValidationMessageFor(Function(Model) Model.Email)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Phone, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Phone)
                @Html.ValidationMessageFor(Function(Model) Model.Phone)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Website, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Website)
                @Html.ValidationMessageFor(Function(Model) Model.Website)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Rating, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Rating)
                @Html.ValidationMessageFor(Function(Model) Model.Rating)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Reviews, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Reviews)
                @Html.ValidationMessageFor(Function(Model) Model.Reviews)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Latitude, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Latitude)
                @Html.ValidationMessageFor(Function(Model) Model.Latitude)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Longitude, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Longitude)
                @Html.ValidationMessageFor(Function(Model) Model.Longitude)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(Model) Model.Category, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(Model) Model.Category)
                @Html.ValidationMessageFor(Function(Model) Model.Category)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
    </text>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
 
