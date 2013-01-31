<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frame.aspx.cs"
    Inherits="DotNet.Web.UI.frame" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--    <script src="Style/Js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="Style/artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    //<script src="Style/artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <script src="Style/artDialog4.1.6/artDialog.source.js" type="text/javascript"></script>
    <script src="Style/artDialog4.1.6/plugins/iframeTools.source.js" type="text/javascript"></script>
    <script src="Style/Js/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //debugger;
            var api = art.dialog.open.api;
            api.button({
                name: 'OK',
                calDotNetack: CalDotNetack
            });
        })
        function CalDotNetack() {
            //  debugger;
            // art.dialog.open.origin.tt(); //调用来源页面

            DoPostBack("DotNetCustomCalDotNetack", 'dd');
            return false;
        }
       
 
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <cc1:DotNetDropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="1" Text="项目1"></asp:ListItem>
        <asp:ListItem Value="2" Text="项目2"></asp:ListItem>
        <asp:ListItem Value="3" Text="项目3"></asp:ListItem>
        <asp:ListItem Value="4" Text="项目4"></asp:ListItem>
        <asp:ListItem Value="5" Text="项目5"></asp:ListItem>
        <asp:ListItem Value="6" Text="项目6"></asp:ListItem>
    </cc1:DotNetDropDownList>
    <cc2:DotNetCustomCalDotNetack ID="DotNetCustomCalDotNetack" runat="server" UseSubmitBehavior="false"
        OnCustomCalDotNetack="DotNetCustomCalDotNetack_CustomCalDotNetack" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>

    </form>
</body>
</html>
