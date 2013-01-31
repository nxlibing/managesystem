<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleEdit.aspx.cs" Inherits="DotNet.Web.Admin.Security.ModuleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <asp:TextBox ID="ctlSysno" runat="server"></asp:TextBox>
    </div>
    <table class="edittable">
        <tr>
            <td class="title">
                标题：
            </td>
            <td>
                <asp:TextBox ID="ctlTitle" runat="server" Width="200px" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                描述：
            </td>
            <td>
                <asp:TextBox ID="ctlDescription" runat="server" Width="200px" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                链接：
            </td>
            <td>
                <asp:TextBox ID="ctlNavigateurl" runat="server" Width="200px" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                显示顺序
            </td>
            <td>
                <asp:TextBox ID="ctlDispindex" runat="server" Width="200px" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                上级栏目
            </td>
            <td>
                <asp:DropDownList ID="ctlPguid" runat="server" Width="203px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="title">
                是否启用
            </td>
            <td>
                <asp:RadioButtonList ID="ctlStatus" runat="server" RepeatDirection="Horizontal" BorderStyle="None">
                    <asp:ListItem Selected="True" Value="1">有效</asp:ListItem>
                    <asp:ListItem Value="0">无效</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
