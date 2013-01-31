<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolePermissions.aspx.cs" Inherits="DotNet.Web.Admin.Security.RolePermissions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Style/Js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../Style/Js/jquery.layout-latest.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('body').layout({ applyDefaultStyles: true });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="ui-layout-center">
            当前角色权限列表
        </div>
        <div class="ui-layout-west">角色列表</div>
    </form>
</body>
</html>
