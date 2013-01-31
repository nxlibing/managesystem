<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="DotNet.Web.Admin.Security.RoleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--    
    <script src="../Style/Js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../Style/Js/Common.js" type="text/javascript"></script>
    <script src="../Style/artDialog4.1.6/artDialog.source.js" type="text/javascript"></script>
    <script src="../Style/artDialog4.1.6/plugins/iframeTools.source.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        $(function () {
            var api = art.dialog.open.api;
            api.button({
                name: '保存',
                calDotNetack: CalDotNetack
            }, {
                name: '取消',
                calDotNetack: function () { api.close(); }
            });
        })
        function CalDotNetack() {

            art.dialog.tips("数据请求中.....");
            DoPostBack("DotNetCustomCalDotNetack", "add");
            return false;
        }

        // art.dialog.open.origin.tt(); //调用来源页面
        function EndCustomCalDotNetack(e) {

            art.dialog.open.origin.EndCustomCalDotNetack(e);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <AspNet:DotNetCustomCalDotNetack ID="DotNetCustomCalDotNetack" runat="server" UseSubmitBehavior="false"
        OnCustomCalDotNetack="DotNetCustomCalDotNetack_CustomCalDotNetack" EndCalDotNetack="EndCustomCalDotNetack" />
    <div style="display: none">
        <asp:TextBox ID="txtFguid" runat="server"></asp:TextBox>
    </div>
    <table class="edittable">
        <tr>
            <td class="title">
                角色名称
            </td>
            <td>
                <asp:TextBox ID="txtRolename" runat="server" CssClass="input" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                备注
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="input" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                状态
            </td>
            <td>
                <%-- <AspNet:DotNetDropDownList ID="txtStatus" runat="server">
                    <asp:ListItem Selected="True" Value="1">有效</asp:ListItem>
                    <asp:ListItem Value="0">无效</asp:ListItem>
                </AspNet:DotNetDropDownList>--%>
                <asp:RadioButtonList ID="txtStatus" runat="server" RepeatDirection="Horizontal" BorderStyle="None">
                    <asp:ListItem Selected="True" Value="1">有效</asp:ListItem>
                    <asp:ListItem Value="0">无效</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
