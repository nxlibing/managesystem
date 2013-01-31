<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DotNet.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统管理平台登录</title>
    <link rel="shortcut icon" href="Style/Images/favicon.ico" />
    <link href="Admin/Style/Css/Base.css" rel="stylesheet" type="text/css" />
    <link href="Admin/Style/Css/Login.css" rel="stylesheet" type="text/css" />
    <script src="Admin/Style/Js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ToggleCode(obj, codeurl) {
            $(obj).attr("src", codeurl + "?time=" + Math.random());
        }
        $(function () {
            if ($.browser.msie && $.browser.version == "6.0") {
                window.location.href = 'ie6update.html';
            }
            $('#ctlUsername').focus();
        })
    </script>
</head>
<body>
    <form id="form1" runat="server" action="Login.aspx">
        <div class="login">
            <div class="left">
                <div class="logo">
                </div>
            </div>
            <div class="right">
                <div class="input">
                    <div class="row">
                        <asp:Label ID="ctlTip" runat="server" CssClass="tip"></asp:Label>
                    </div>
                    <div class="row">
                        <span class="value">用户名：</span>
                        <asp:TextBox ID="ctlUsername" runat="server" CssClass="txt_bg_l" Text="libing"></asp:TextBox>
                    </div>
                    <div class="row">
                        <span class="value">密&nbsp;码：</span>
                        <asp:TextBox ID="ctlPassword" runat="server" CssClass="txt_bg_l" Text="123"></asp:TextBox>
                    </div>
                    <div class="row">
                        <span class="value">验证码：</span>
                        <asp:TextBox ID="ctlCheckCode" runat="server" CssClass="txt_bg" Style=" letter-spacing:3px; TEXT-TRANSFORM: uppercase"></asp:TextBox>
                        <span class="checkimg">
                            <img src="Handler/Verify_code.ashx" alt="点击切换验证码" title="点击切换验证码" onclick="ToggleCode(this, 'Handler/Verify_code.ashx');return false;" /></span>
                    </div>
                    <div class="btn_box">
                        <asp:Button ID="btn_Ok" runat="server" CssClass="login_btn" OnClick="btn_Ok_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
