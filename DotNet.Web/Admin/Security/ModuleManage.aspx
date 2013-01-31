<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleManage.aspx.cs" Inherits="DotNet.Web.Admin.Security.ModuleManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Style/Css/Page.css" />
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
                    ExecuteAdd("添加模块", "Security/ModuleEdit.aspx", 400, 200);
                    break;
                case "del":
                    ExecuteDelete("CalDotNetack", "GridView1", "Fguid");
                    break;
                case "edit":
                    ExecuteEdit("编辑模块", "Security/ModuleEdit.aspx", 400, 200, "GridView1");
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

        function Add(fguid) {
            ExecuteAdd("添加模块", "Security/ModuleEdit.aspx", 400, 200, fguid);
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
                <span>用户名称：</span> <span>
                    <asp:TextBox ID="ctlRealname" runat="server" CssClass="input" Width="150px"></asp:TextBox></span>
                <span>
                    <input id="Button2" type="button" value="查询" onclick="DataSearch()" /></span>
            </div>
        </div>
        <div id="gridmenu">
            <span><a class="chkall" name="checkall">全选</a> <em>|</em><a class="add" name="add">添加</a>
                <em>|</em><a class="del" name="del">删除</a><em>|</em> <a class="edit" name="edit">编辑</a></span>
        </div>
        <AspNet:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClassMouseOver="RowHover"
            Width="100%" ShowCheckbox="true" AlternatingRowStyle-CssClass="AlternatingRow"
            CssClass="listtable">
            <Columns>
                <asp:BoundField DataField="Moduleno" HeaderText="编号" HeaderStyle-Width="65px" />
                <asp:BoundField DataField="Title" HeaderText="名称" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="Description" HeaderText="描述" />
                <asp:BoundField DataField="Navigateurl" HeaderText="链接" />
                <asp:BoundField DataField="Fguid" HeaderText="Fguid" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                <asp:BoundField DataField="Pguid" HeaderText="编号" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                <asp:TemplateField HeaderText="操作" ShowHeader="False" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <a onclick='Add("<%#Eval("Fguid")%>")'>添加子菜单</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </AspNet:GridView>
    </div>
    </form>
</body>
</html>
