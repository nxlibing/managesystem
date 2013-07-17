<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="DotNet.Web.Admin.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统管理平台</title>
    <link rel="shortcut icon" href="../Style/Images/favicon.ico" />
    <link href="Style/Css/Base.css" rel="stylesheet" type="text/css" />
    <link href="Style/Css/Main.css" rel="stylesheet" type="text/css" />
    <script src="Style/Js/main.js" type="text/javascript"></script>
    <script src="Style/Js/MD5.js" type="text/javascript"></script>
    <script src="../Style/Js/cookie.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
            <div class="left">
                <img src="style/images/logo-title.png" alt="" />
            </div>
            <div class="right">
                <div class="nav">
                    <ul id="TabPage">
                        <%-- <li class="Selected" id="71ED44D1-9DF9-4A74-9B27-AEA5A552EC6A">权限系统</li>
                    <li id="C8FC7343-0147-4DCA-B84B-2678538B1FA2">新闻系统</li>
                     <li id="manage2">后台管理2</li>--%>
                    </ul>
                </div>
            </div>
            <div id="righttop">
                <ul>
                    <li class="righttophelp" href="http://www.baidu.com">购买咨询</li>
                    <li class="righttopabout" href="http://www.bing.com/">关于</li>
                </ul>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="adminmenu">
            欢迎您，<span id="username" runat="server"></span><em>|</em><%-- <a href="a#">基本信息</a> <em>|</em>--%>
            <a onclick="ChangePassword()">修改密码</a><em>|</em>
            <a onclick="LockScreen()">锁定屏幕</a>
            <%--<em>|</em> <a href="c#">定制菜单</a> <em>|</em>--%>
            <%--<a href="#" class="hover_url"><font color="#3186c8"
            style="text-decoration: underline;">
            <asp:HiddenField ID="hfCurrentID" runat="server"></asp:HiddenField>
            <asp:Label ID="DotNetlTotal" runat="server"></asp:Label></font> </a><span class="hover_url1">
                条信息</span>--%>
        </div>
        <div class="quickmenu">
            <div class="left">
                <ul>
                    <li><a href="#">快捷菜单</a></li>
                    <li style="margin-left: 22px">
                        <asp:LinkButton ID="DotNet_Exit" runat="server" OnClick="DotNet_Exit_Click">退出</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div class="right">
                <div class="nav" id="nav">
                    <a href="main-index.aspx">首页</a>
                </div>
            </div>
        </div>
        <div class="container">
            <div id="leftbar">
                <%--  <ul>
                <span>主菜单 </span>
                <li href="login.aspx">子菜单</li>
                <li href="asdf2">子菜单</li>
                <li href="asdf3">子菜单</li>
                <li href="asdf4">子菜单</li>
                <li href="asdf5">子菜单</li>
            </ul>
            <ul>
                <span>主菜单 </span>
                <li href="login.aspx">子菜单</li>
                <li href="asdf2">子菜单ww</li>
                <li href="asdf3">子菜单</li>
                <li href="asdf4">子菜单</li>
                <li href="asdf5">子菜单</li>
            </ul>--%>
                <%-- <ul class="open">
                <div class="span_open">品牌与分类</div><li><a href="shop/ShopCategories/List.aspx" target="mainFrame">
                    商品分类</a></li><li><a href="shop/Brands/AList.aspx" target="mainFrame">品牌管理</a></li></ul>--%>
            </div>
            <div id="splitbar" class="close">
            </div>
            <div id="content">
                <iframe frameborder="0" id="sysMain" name="sysMain" src="main-index.aspx"></iframe>
            </div>
        </div>
    </form>
</body>
</html>
