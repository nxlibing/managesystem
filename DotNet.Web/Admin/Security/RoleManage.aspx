<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="DotNet.Web.Admin.Security.RoleManage" %>

<%@ Register Assembly="DotNet.Controls" Namespace="DotNet.Controls.GridView" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Style/Css/Page.css" rel="stylesheet" type="text/css" />
    <%--    <script src="../Style/Js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../Style/Js/Common.js" type="text/javascript"></script>
    <script src="../Style/artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../Style/artDialog4.1.6/plugins/iframeTools.source.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        $(function () {

            $("#gridmenu a").click(function () {
                var action = getCtlPropertyValue(this, "name");
                exeAction(this, action);
            });
        });

        function exeAction(o, action) {
            switch (action) {
                case "checkall":
                    checkAll(o);
                    break;
                case "add":
                    ExecuteAdd("编辑角色", "Security/RoleEdit.aspx", 350, 120);
                    break;
                case "del":
                    ExecuteDelete("CalDotNetack", "GridView1", "Fguid");
                    break;
                case "edit":
                    ExecuteEdit("编辑角色", "Security/RoleEdit.aspx", 350, 120, "GridView1");
                    break;
                case "sort": break;
            }
        }

        function DataSearch() {
            DoPostBack("CalDotNetack", 'search');
        }
        function CustomCalDotNetack(action) {
            DoPostBack("CalDotNetack", action + "_" + GetFguid("GridView1"));
        }
        function EndCustomCalDotNetack(e) {
            //  debugger;
            var data = Dcq.ParseJson(e);
            if (data.Result == "true") {
                art.dialog.tiploading("操作成功！", 2, function () {
                    //  debugger;
                    if (!data.IsRefresh) {
                        DataSearch();
                    }
                });
            }
            else {
                art.dialog.tips("操作失败！", 2);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <AspNet:DotNetCustomCalDotNetack ID="CalDotNetack" runat="server" UseSubmitBehavior="false" OnCustomCalDotNetack="DotNetCustomCalDotNetack_CustomCalDotNetack"
        EndCalDotNetack="EndCustomCalDotNetack" />
    <div class="container">
        <div class="search">
            <div class="searchtitle">
                查询
            </div>
            <div class="searchcontent">
                <span>角色名称：</span> <span>
                    <asp:TextBox ID="ctlRolename" runat="server" CssClass="input" Width="150px"></asp:TextBox></span>
                <%--<span>名称：</span> <span style=" width:160px">
                    <AspNet:DotNetDropDownList ID="DotNetDropDownList" runat="server" Width="150px">
                        <asp:ListItem Value="" Text="项目1"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目2"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目3"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目4"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目5"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目6"></asp:ListItem>
                    </AspNet:DotNetDropDownList>
                </span>--%>
                <%--<span>名称：</span><span>
                    <AspNet:DotNetDropDownList ID="DotNetDropDownList1" runat="server" Width="150px">
                        <asp:ListItem Value="" Text="项目1"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目2"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目3"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目4"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目5"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目6"></asp:ListItem>
                    </AspNet:DotNetDropDownList>
                </span>--%><span>
                    <input id="Button2" type="button" value="查询" onclick="DataSearch()" /></span>
            </div>
        </div>
        <div id="gridmenu">
            <span><a class="chkall" name="checkall">全选</a> <em>|</em><a class="add" name="add">添加</a>
                <em>|</em><a class="del" name="del">删除</a><em>|</em> <a class="edit" name="edit">编辑</a></span>
        </div>
        <asp:ObjectDataSource ID="DataSource" runat="server" DataObjectTypeName="DotNet.Business.Security.Entities.Base_Role"
            SelectCountMethod="GetCount" SelectMethod="GetData" EnablePaging="true" MaximumRowsParameterName="maxRows"
            StartRowIndexParameterName="startIndex" TypeName="DotNet.Web.Admin.Security.RoleManage">
        </asp:ObjectDataSource>
        <AspNet:GridView ID="GridView1" runat="server" AllowPaging="true" EnableSortingAndPagingCalDotNetacks="true"
            AutoGenerateColumns="false" DataSourceID="DataSource" PageSize="10" CssClassMouseOver="RowHover"
            PagingStyle="Default" Width="100%" ShowCheckbox="true" AlternatingRowStyle-CssClass="AlternatingRow"
            CssClass="listtable">
            <Columns>
                <asp:BoundField DataField="Rolename" HeaderText="角色名称" />
                <asp:BoundField DataField="Description" HeaderText="描述" />
                <asp:BoundField DataField="Status" HeaderText="状态" />
                <asp:BoundField DataField="Fguid" HeaderText="Fguid" HeaderStyle-CssClass="hidden"
                    FooterStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
            </Columns>
            <PagerStyle CssClass="page" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast"
                NextPageText="下一页" PreviousPageText="上一页" />
        </AspNet:GridView>
    </div>
    </form>
</body>
</html>
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Style/Css/Page.css" />
    <script src="../Style/Js/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../Style/Js/lhgdialog/lhgdialog.min.js?skin=blue" type="text/javascript"></script>
    <%--   <script src="../Style/Js/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Add() {
            WinOpen(400, 300, "添加角色", "url:Admin/RoleEdit.aspx?rd=" + Math.random());
        }
        function Update() {

            WinOpen(400, 300, "编辑角色", "url:Admin/RoleEdit.aspx?action=view&fguid=51E1FCE6-CEF9-43C8-BFC7-2F6AC2700E66&rd=" + Math.random());
        }

        function Reload() {
            window.location.reload();
        }
        function WinOpen(width, height, title, content) {
            $.dialog({
                width: width + 'px',
                height: height,
                lock: true,
                title: title,
                content: content
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        首页 &gt; 控制面板 &gt; 管理员管理</div>
    <div class="tools_box">
        <div class="tools_bar">
            <div class="search_box">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" />
            </div>
            <a onclick="Add()" class="tools_btn"><span><b class="add">添加管理员</b></span></a> <a
                onclick="Update()" class="tools_btn"><span><b class="return">编辑</b></span></a>
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b
                class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn" OnClientClick="return ExePostBack('btnDelete');"><span><b class="delete">批量删除</b></span></asp:LinkButton>
        </div>
    </div>
    <asp:ObjectDataSource ID="DataSource" runat="server" DataObjectTypeName="DotNet.Business.Security.Entities.Base_Role"
        SelectCountMethod="GetCount" SelectMethod="GetData" EnablePaging="true" MaximumRowsParameterName="maxRows"
        StartRowIndexParameterName="startIndex" TypeName="DotNet.Web.Admin.RoleManage"></asp:ObjectDataSource>
    <cc1:DotNetGridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"
        EnableSortingAndPagingCalDotNetacks="true" DataSourceID="DataSource" PageSize="10"
        CssClassMouseOver="rowover" PagingStyle="Default" Width="100%" ShowCheckbox="true">
        <Columns>
            <asp:BoundField DataField="Rolename" HeaderText="角色名" />
            <asp:BoundField DataField="Description" HeaderText="描述" />
            <asp:BoundField DataField="Status" HeaderText="状态" />
        </Columns>
        <PagerStyle CssClass="page" />
        <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast"
            NextPageText="下一页" PreviousPageText="上一页" />
    </cc1:DotNetGridView>
    </form>
</body>
</html>
--%>