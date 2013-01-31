<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="DotNet.Web.Admin.Notice.NoticeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Style/Css/Page.css" />
    <script type="text/javascript">
        function aa() {
            ExecuteAdd("添加栏目", "Cms/CategoryEdit.aspx", 400, 165);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <a onclick="aa()">点击我</a>
    </form>
</body>
</html>
