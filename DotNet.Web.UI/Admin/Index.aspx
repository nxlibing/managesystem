<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Web.UI.Admin.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Style/Js/jquery.js" type="text/javascript"></script>
    <script src="Style/Js/jquery.layout.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('body').layout({ applyDefaultStyles: true });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="ui-layout-center">
            Center
	<p><a href="http://layout.jquery-dev.net/demos.html">Go to the Demos page</a></p>
            <p>* Pane-resizing is disabled because ui.draggable.js is not linked</p>
            <p>* Pane-animation is disabled because ui.effects.js is not linked</p>
        </div>
        <div class="ui-layout-north">North</div>
        <div class="ui-layout-south">South</div>
        <div class="ui-layout-east">East</div>
        <div class="ui-layout-west">West</div>
    </form>
</body>
</html>
