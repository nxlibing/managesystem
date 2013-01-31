<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="DotNet.Web.Admin.Cms.ArticleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Style/Css/Page.css" />
    <%--    <script src="../Style/artDialog/artDialog.js?skin=default" type="text/javascript"></script>
    <script src="../Style/artDialog/plugins/iframeTools.source.js" type="text/javascript"></script>
    
    <script src="../Style/Js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../Style/Js/Common.js" type="text/javascript"></script>--%>
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
                    self.location = 'ArticleEdit.aspx';
                    break;
                case "del":
                    ExecuteDelete("CalDotNetack", "GridView1", "Fguid");
                    break;
                case "edit":
                    self.location = 'ArticleEdit.aspx';
                    break;
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
                    搜索
                </div>
                <div class="searchcontent">
                    <span>栏目：</span> <span>
                        <asp:DropDownList ID="ctlCategory" runat="server" Width="150px">
                            <asp:ListItem Text="asdf" Value=""></asp:ListItem>
                            <asp:ListItem Text="asdf" Value=""></asp:ListItem>
                            <asp:ListItem Text="asdf" Value=""></asp:ListItem>
                            <asp:ListItem Text="asdf" Value=""></asp:ListItem>
                            <asp:ListItem Text="asdf" Value=""></asp:ListItem>
                            <asp:ListItem Text="asdf" Value=""></asp:ListItem>
                        </asp:DropDownList></span>
                    <span>标题：</span> <span>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="input" Width="150px"></asp:TextBox></span>
                    <span>作者：</span> <span>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="input" Width="150px"></asp:TextBox></span>
                    <span>
                        <input id="Button2" type="button" value="查询" onclick="DataSearch()" /></span>
                </div>
            </div>
            <div id="gridmenu">
                <span><a class="chkall" name="checkall">全选</a> <em>|</em><a class="add" name="add">添加</a>
                    <em>|</em><a class="del" name="del">删除</a><em>|</em> <a class="edit" name="edit">编辑</a></span>
            </div>
            <asp:ObjectDataSource ID="DataSource" runat="server" DataObjectTypeName="DotNet.Business.Cms.Entities.Cms_Article"
                SelectCountMethod="GetCount" SelectMethod="GetData" EnablePaging="true" MaximumRowsParameterName="maxRows"
                StartRowIndexParameterName="startIndex" TypeName="DotNet.Web.Admin.Cms.ArticleList"></asp:ObjectDataSource>
            <AspNet:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                EnableSortingAndPagingCalDotNetacks="true" DataSourceID="DataSource" PageSize="10"
                CssClassMouseOver="RowHover" PagingStyle="Default" Width="100%" ShowCheckbox="true"
                AlternatingRowStyle-CssClass="AlternatingRow" CssClass="listtable">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="标题" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Category.Title" HeaderText="栏目" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Author" HeaderText="作者" HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Click" HeaderText="浏览数" HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" NullDisplayText="0" />
                    <asp:BoundField DataField="Pubsj" HeaderText="发布日期" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-dd-MM}" HtmlEncode="false" />

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
