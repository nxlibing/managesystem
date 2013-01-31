<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleModule.aspx.cs" Inherits="DotNet.Web.Admin.Security.RoleModule" %>

<%@ Register Src="~/Admin/UserControls/ModuleList.ascx" TagPrefix="uc1" TagName="ModuleList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .box .listbox
        {
            width: 150px;
            height: 250px;
            margin-left: 85px;
            margin-bottom: 10px;
            background-image: none;
            background: #fff;
            font-size: 14px;
            border: 1px solid #d6d6d6;
            float: left;
        }

        .box .right
        {
            margin-left: 280px;
        }

        .right table
        {
            border: 0;
        }

        .box
        {
            width: 96%;
            float: left;
            margin: 2%;
            background: #FFF;
            border: 1px solid #d6d6d6;
        }

            .box .roleinfo
            {
                width: 100%;
                float: left;
                line-height: 40px;
                text-align: center;
                font-size: 14px;
            }

            .box ul
            {
                display: block;
                width: 100%;
                float: left;
                list-style: none;
            }

                .box ul li
                {
                    text-indent: 7px;
                    line-height: 35PX;
                    float: left;
                    width: 300px;
                }

        .rolelist td
        {
            padding: 7px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <span class="roleinfo">角色列表，请选择</span>
            <asp:ListView ID="ctlRoleList" runat="server" ItemContainerID="ItemPlaceHolder">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                    </ul>
                </LayoutTemplate>
                <SelectedItemTemplate>
                </SelectedItemTemplate>
                <ItemTemplate>
                    <li>[<asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Fguid")%>'
                        OnClick="LinkButton1_Click" Text='<%# Eval("Rolename")%>'></asp:LinkButton>]
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="box" id="Moduleinfo" runat="server" style="display: none">
            <span class="roleinfo">当前角色：【<span runat="server" id="roleinfo">请选择</span>】</span>
            <span class="roleinfo" style="color: red">
                <asp:Label ID="ctlTip" runat="server"></asp:Label></span>
            <div style="width: 100%; float: left; padding: 0 15px;">
                <uc1:ModuleList runat="server" ID="ctlModuleList" />
            </div>
            <span class="roleinfo">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" /></span>
        </div>
        <div style="display: none">
            <asp:TextBox ID="ctlRoleid" runat="server"></asp:TextBox>
        </div>
        <%--  <div id="gridmenu">
            <span><a class="chkall" name="checkall">全选</a> <em>|</em><a class="add" name="add">添加</a>
                <em>|</em><a class="del" name="del">删除</a><em>|</em> <a class="edit" name="edit">编辑</a><em>|</em>
                <a class="role" name="role">指派角色</a><em>|</em> <a class="password" name="password">重置密码</a></span>
        </div>
        <asp:ObjectDataSource ID="DataSource" runat="server" DataObjectTypeName="DotNet.Business.Security.Entities.Base_User"
            SelectCountMethod="GetCount" SelectMethod="GetData" EnablePaging="true" MaximumRowsParameterName="maxRows"
            StartRowIndexParameterName="startIndex" TypeName="DotNet.Web.Admin.Security.RoleModule"></asp:ObjectDataSource>
        <AspNet:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"
            EnableSortingAndPagingCalDotNetacks="false" DataSourceID="DataSource" PageSize="10"
            CssClassMouseOver="RowHover" PagingStyle="Default" Width="100%" ShowCheckbox="true"
            AlternatingRowStyle-CssClass="AlternatingRow" CssClass="listtable">
            <columns>
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
                    <a onclick='SetRowRoles("<%#Eval("Fguid")%>","<%#Eval("Realname")%>(<%#Eval("Username")%>)")'>
                        指派角色</a>
                </ItemTemplate>
            </asp:TemplateField>
        </columns>
            <pagerstyle cssclass="page" />
            <pagersettings firstpagetext="首页" lastpagetext="尾页" mode="NextPreviousFirstLast"
                nextpagetext="下一页" previouspagetext="上一页" />
        </AspNet:GridView>--%>
    </form>
</body>
</html>
