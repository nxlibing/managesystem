<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="DotNet.Web.Admin.Security.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Style/Js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Style/Js/jquery.validate.message.zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            //            $("#form1").validate({
            //                errorPlacement: function (error, element) {
            //                    error.appendTo($(element).parent());
            //                }
            //            });
            // $("#form1").validate();
            var api = art.dialog.open.api;
            api.button({
                name: '保存',
                calDotNetack: CalDotNetack
            }, {
                name: '取消',
                calDotNetack: function () { api.close(); }
            });
        });
        function CalDotNetack() {
            if ($("#form1").valid()) {
                art.dialog.tips("数据请求中.....");
                DoPostBack("DotNetCustomCalDotNetack", "add");
            }
            return false;
        }

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
            <asp:TextBox ID="txtPw" runat="server"></asp:TextBox>
        </div>
        <table class="edittable">
            <tr>
                <td class="title">登录名：
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="input required" Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">姓名：
                </td>
                <td>
                    <asp:TextBox ID="txtRealname" runat="server" CssClass="input required" Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">密码：
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input" Width="215px"></asp:TextBox><asp:Label ID="pwtip" runat="server" Text="为空不修改"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="title">备注：
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="input required" Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">状态：
                </td>
                <td>
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
