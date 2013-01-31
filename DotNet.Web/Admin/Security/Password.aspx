<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="DotNet.Web.Admin.Security.Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Style/Js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Style/Js/jquery.validate.message.zh-cn.js" type="text/javascript"></script>
    <script src="../Style/Js/jquery.metadata.js" type="text/javascript"></script>
    <script src="../Style/Js/MD5.js" type="text/javascript"></script>
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
            //    MD5();
            if ($("#form1").valid()) {
                art.dialog.tips("数据请求中.....");
                DoPostBack("DotNetCustomCalDotNetack", "");
            }
            return false;
        }

        function MD5(value) {
            if (hex_md5(value) != $("#ctlOldPassword2").val().toLocaleLowerCase()) {
                return false;
            }
            else { return true; }
        }
        // 原密码不同  
        jQuery.validator.addMethod("md5", function (value, element) {
            return this.optional(element) || MD5(value);
        }, "与原密码不同");


        // art.dialog.open.origin.tt(); //调用来源页面
        function EndCustomCalDotNetack(e) {
            var data = Dcq.ParseJson(e);
            if (data.Result == "true") {
                art.dialog.tips("操作成功！", 2);
                art.dialog.open.api.close();
            }
            else {
                art.dialog.tips("操作失败！", 2);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <AspNet:DotNetCustomCalDotNetack ID="DotNetCustomCalDotNetack" runat="server" UseSubmitBehavior="false"
        OnCustomCalDotNetack="DotNetCustomCalDotNetack_CustomCalDotNetack" EndCalDotNetack="EndCustomCalDotNetack" />
    <div style="display: none">
        <asp:TextBox ID="ctlFguid" runat="server"></asp:TextBox>
        <asp:TextBox ID="ctlOldPassword2" runat="server"></asp:TextBox>
    </div>
    <table class="edittable">
        <tr id="name" runat="server">
            <td class="title">
                用户名：
            </td>
            <td style="line-height: 27px;">
                <asp:Label ID="ctlUsername" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="old" runat="server">
            <td class="title">
                原密码：
            </td>
            <td>
                <asp:TextBox ID="ctlOldPassword" runat="server" Width="200px" CssClass="input required md5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                新密码：
            </td>
            <td>
                <asp:TextBox ID="ctlNewPassword" runat="server" Width="200px" CssClass="input required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                确认密码：
            </td>
            <td>
                <asp:TextBox ID="ctlNewPassword2" runat="server" Width="200px" CssClass="input  {required:true,equalTo:'#ctlNewPassword',messages:{equalTo:'两次输入不同'}}"></asp:TextBox>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
