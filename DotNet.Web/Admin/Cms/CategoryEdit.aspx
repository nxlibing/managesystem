<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="DotNet.Web.Admin.Cms.CategoryEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html
        {
            overflow: hidden;
        }
    </style>
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
        <asp:TextBox ID="ctlFguid" runat="server"></asp:TextBox>
        <asp:TextBox ID="ctlCategoryid" runat="server"></asp:TextBox>
    </div>
    <table class="edittable">
        <tr>
            <td class="title">
                栏目名称：
            </td>
            <td>
                <asp:TextBox ID="ctlTitle" runat="server" CssClass="input" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                上级栏目：
            </td>
            <td>
                <asp:DropDownList ID="ctlPguid" runat="server" Width="203px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="title">
                外部链接：
            </td>
            <td>
                <asp:TextBox ID="ctlUrl" runat="server" CssClass="input" Width="200px" Text="http://" /></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                描述：
            </td>
            <td>
                <asp:TextBox ID="ctlDescription" runat="server" CssClass="input" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                允许添加内容：
            </td>
            <td>
                <asp:RadioButtonList ID="ctlIsadd" runat="server" RepeatDirection="Horizontal" BorderStyle="None">
                    <asp:ListItem Selected="True" Value="true">允许</asp:ListItem>
                    <asp:ListItem Value="false">不允许</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
