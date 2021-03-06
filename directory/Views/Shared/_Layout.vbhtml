﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - directory</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryui")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", False)
    <link href="@Url.Content("~/Content/jquery-ui.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/jquery.ui.all.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/jquery.ui.core.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/jquery.ui.datepicker.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/jquery.ui.theme.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/PagedList.css")" rel="stylesheet" type="text/css" />
    <script src="@Url.Content("~/Scripts/jquery-1.10.2.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery-ui-1.10.2.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.ui.core.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.ui.widget.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.ui.datepicker.js")" type="text/javascript"></script>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("directory", "Index", "Home", Nothing, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Companies", "Index", "Company", Nothing, New With {.class = "navbar-brand_"})</li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container-fluid body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year</p>
        </footer>
    </div>
</body>
</html>
 
