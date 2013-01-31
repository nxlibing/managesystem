<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="DotNet.Web.Admin.Content" %>

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
    <script src="Style/Js/Common.js" type="text/javascript"></script>
    <script src="Style/Js/Page.js" type="text/javascript"></script>
    <script src="Style/Js/JSON.js" type="text/javascript"></script>
    <script type="text/javascript">
        //        (function (config) {
        //            config['lock'] = true;
        //            config['fixed'] = true;
        //            config['okVal'] = 'Ok';
        //            config['cancelVal'] = 'Cancel';
        //            // [more..]
        //        })(art.dialog.defaults);
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
                    a();
                    break;
                case "del":
                    CustomCalDotNetack(action);
                    break;
                case "edit":
                    CustomCalDotNetack(action);
                    break;
                case "sort": break;
                // case "": break;                  
            }
        }
        function a() {
            art.dialog.open('frame.aspx', {

                title: '提示',
                ok: function () {
                    return false;
                },
                cancel: true
            });
        }
        function DataSearch() {
            DoPostBack("CalDotNetack", 'search');
        }
        function CustomCalDotNetack(action) {
            DoPostBack("CalDotNetack", action + "_" + GetFguid("GridView1"));
        }
        function EndCustomCalDotNetack(e) {
            var data = Dcq.ParseJson(e);
            if (data.Result == "true") {
                art.dialog.tips("操作成功！");
                if (!data.IsRefresh) {
                    DataSearch();
                }
            }
            else {
                art.dialog.tips("操作失败！");
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
                <span>名称：</span> <span>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input" Width="150px"></asp:TextBox></span>
                <span>名称：</span> <span>
                    <AspNet:DotNetDropDownList ID="DotNetDropDownList" runat="server" Width="150px">
                        <asp:ListItem Value="" Text="项目1"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目2"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目3"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目4"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目5"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目6"></asp:ListItem>
                    </AspNet:DotNetDropDownList>
                </span><span>名称：</span><span>
                    <AspNet:DotNetDropDownList ID="DotNetDropDownList1" runat="server" Width="150px">
                        <asp:ListItem Value="" Text="项目1"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目2"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目3"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目4"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目5"></asp:ListItem>
                        <asp:ListItem Value="" Text="项目6"></asp:ListItem>
                    </AspNet:DotNetDropDownList>
                </span><span>
                    <input id="Button2" type="button" value="查询" onclick="DataSearch()" /></span>
            </div>
        </div>
        <div class="gridmenu" id="gridmenu">
            <span><a class="chkall" name="checkall">全选</a> <em>|</em><a class="add" name="add">添加</a>
                <em>|</em><a class="del" name="del">删除</a><em>|</em> <a class="edit" name="edit">编辑</a><em>|</em>
                <a class="count" name="sort">排序</a> </span>
        </div>
        <asp:ObjectDataSource ID="DataSource" runat="server" DataObjectTypeName="DotNet.Business.Security.Entities.Base_Role"
            SelectCountMethod="GetCount" SelectMethod="GetData" EnablePaging="true" MaximumRowsParameterName="maxRows"
            StartRowIndexParameterName="startIndex" TypeName="DotNet.Web.Admin.Content"></asp:ObjectDataSource>
        <AspNet:DotNetGridView ID="GridView1" runat="server" AllowPaging="true" EnableSortingAndPagingCalDotNetacks="true"
            AutoGenerateColumns="false" DataSourceID="DataSource" PageSize="2" CssClassMouseOver="RowHover"
            PagingStyle="Default" Width="100%" ShowCheckbox="true" AlternatingRowStyle-CssClass="AlternatingRow">
            <Columns>
                <asp:BoundField DataField="Rolename" HeaderText="角色名" />
                <asp:BoundField DataField="Description" HeaderText="描述" />
                <asp:BoundField DataField="Status" HeaderText="状态" />
                <asp:BoundField DataField="Fguid" HeaderText="Fguid" HeaderStyle-CssClass="hidden"
                    FooterStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
            </Columns>
            <PagerStyle CssClass="page" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast"
                NextPageText="下一页" PreviousPageText="上一页" />
        </AspNet:DotNetGridView>
    </div>
    </form>
</body>
</html>
