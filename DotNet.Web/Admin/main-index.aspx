<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main-index.aspx.cs" Inherits="DotNet.Web.Admin.main_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/Css/Base.css" rel="stylesheet" type="text/css" />
    <link href="Style/Css/Page.css" rel="stylesheet" type="text/css" />
    <script src="Style/Js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="Style/artDialog4.1.6/artDialog.js?skin=default" type="text/javascript"></script>
    <%-- <script src="Style/artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>--%>
    <script src="Style/artDialog4.1.6/plugins/iframeTools.source.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="title">
            <div class="icon">
                <img src="style/images/zao.gif" width="34" height="25" alt="" /></div>
            <span><strong>管理员，欢迎使用系统管理平台</strong> <a href="#" target="mainFrame">账号设置</a></span>
        </div>
        <div class="subtitle">
            <div class="icon">
                <img src="style/images/icon5.gif" width="22" height="20" alt="" /></div>
            <span>您最后一次登录的时间：<asp:Literal ID="LitLastLoginTime" runat="server"></asp:Literal>
                (不是您登录的？<a href="#">请点这里</a>)</span>
        </div>
        <div class="line">
        </div>
        <div class="title" style>
            <div class="icon">
                <img src="style/images/icon6.gif" width="21" height="28" alt="" /></div>
            <span><strong>系统使用指南</strong></span>
        </div>
    </div>
    </form>
</body>
</html>
