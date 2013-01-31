<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="DotNet.Web.Admin.Security.UserManage" %>

<%@ Register Assembly="DotNet.Controls" Namespace="DotNet.Controls.GridView" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                    ExecuteAdd("添加用户", "Security/UserEdit.aspx", 400, 180);
                    break;
                case "del":
                    ExecuteDelete("CalDotNetack", "GridView1", "Fguid");
                    break;
                case "edit":
                    ExecuteEdit("编辑用户", "Security/UserEdit.aspx", 400, 180, "GridView1");
                    break;
                case "role":
                    SetRoles();
                    break;
                case "password":
                    ChangePassword();
                    break;
            }
        }

        function SetRoles() {
            if (GetCheckedCount() != 1) {
                art.dialog.tips("请选择一条需要指派角色的数据！", 1);
            }
            else {
                var fguid = GetCheckBoxValue("GridView1", "Fguid");
                var Realname = GetCheckBoxValue("GridView1", "姓名");
                var Username = GetCheckBoxValue("GridView1", "登录名");
                var value = Realname + "(" + Username + ")";
                SetRowRoles(fguid, value);
            }
        }

        function ChangePassword() {
            if (GetCheckedCount() == 0) {
                art.dialog.tips("请选择需要修改密码的数据！", 1);
            }
            else {
                var fguid = GetCheckBoxValue("GridView1", "Fguid");
                WinOpen("密码修改", "Security/Password.aspx?fguid=" + fguid, 400, 100);
            }
        }

        function SetRowRoles(fguid, value) {
            var url = "Security/UserRole.aspx?fguid=" + fguid + "&value=" + value;
            WinOpen("角色分派", url, 500, 170);
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
                art.dialog.tiploading("操作成功！", 2, function () {
                    if (!data.IsRefresh) {
                        DataSearch();
                    }
                    else {
                        WinClose();
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
                    姓名
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
                    <em>|</em><a class="del" name="del">删除</a><em>|</em> <a class="edit" name="edit">编辑</a><em>|</em>
                    <a class="role" name="role">指派角色</a><em>|</em> <a class="password" name="password">重置密码</a></span>
            </div>
            <asp:ObjectDataSource ID="DataSource" runat="server" DataObjectTypeName="DotNet.Business.Security.Entities.Base_User"
                SelectCountMethod="GetCount" SelectMethod="GetData" EnablePaging="true" MaximumRowsParameterName="maxRows"
                StartRowIndexParameterName="startIndex" TypeName="DotNet.Web.Admin.Security.UserManage"></asp:ObjectDataSource>
            <cc1:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                EnableSortingAndPagingCalDotNetacks="false" DataSourceID="DataSource" PageSize="10"
                CssClassMouseOver="RowHover" PagingStyle="Default" Width="100%" ShowCheckbox="true"
                AlternatingRowStyle-CssClass="AlternatingRow" CssClass="listtable">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="登录名" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="Realname" HeaderText="姓名" HeaderStyle-Width="200px" />
                    <asp:BoundField DataField="Description" HeaderText="描述" />
                    <asp:BoundField DataField="Status" HeaderText="状态" HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Fguid" HeaderText="Fguid" HeaderStyle-CssClass="hidden"
                        FooterStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                    <asp:TemplateField HeaderText="操作" ShowHeader="False" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <a onclick='SetRowRoles("<%#Eval("Fguid")%>","<%#Eval("Realname")%>(<%#Eval("Username")%>)")'>指派角色</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="page" />
                <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast"
                    NextPageText="下一页" PreviousPageText="上一页" />
            </cc1:GridView>
        </div>
    </form>
</body>
</html>
