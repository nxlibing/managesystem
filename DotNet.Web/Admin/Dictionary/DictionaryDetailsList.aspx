<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictionaryDetailsList.aspx.cs" Inherits="DotNet.Web.Admin.Dictionary.DictionaryDetailsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Style/Js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Style/Js/jquery.metadata.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Add() {
            if ($("#form1").valid()) {
                art.dialog.tips("数据请求中.....");
                DoPostBack("CalDotNetack", "");
            }
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <AspNet:DotNetCustomCalDotNetack ID="CalDotNetack" runat="server" UseSubmitBehavior="false" OnCustomCalDotNetack="CalDotNetack_CustomCalDotNetack" />
        <div class="container">

            <div class="search">
                <div class="addtitle">
                    添加
                </div>
                <div class="searchcontent">
                    <span>类型名称：</span> <span>
                        <asp:DropDownList ID="ctlCategorys" AutoPostBack="true" runat="server" Width="200PX" OnSelectedIndexChanged="ctlCategorys_SelectedIndexChanged"></asp:DropDownList>

                    </span><span>编码：</span> <span>
                        <asp:TextBox ID="ctlCode" runat="server" CssClass="input {required:true,messages:{required:'不能为空'}}" Width="200px"></asp:TextBox>
                    </span><span>名称：</span> <span>
                        <asp:TextBox ID="ctlName" runat="server" CssClass="input {required:true,messages:{required:'不能为空'}}" Width="200px"></asp:TextBox>
                    </span>
                    <span>
                        <input id="Button1" type="button" value="添加" onclick="Add()" />
                    </span>
                </div>
            </div>
            <AspNet:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClassMouseOver="RowHover"
                Width="100%" AlternatingRowStyle-CssClass="AlternatingRow" DataKeyNames="Fguid"
                CssClass="listtable" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting"
                OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="编码" HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Name" HeaderText="名称" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="StatusName" HeaderText="状态" HeaderStyle-HorizontalAlign="Left" Visible="false" />
                    <asp:BoundField DataField="ShowDelete" HeaderText="删除" HeaderStyle-HorizontalAlign="Left" Visible="false" />
                    <asp:TemplateField HeaderText="状态" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <%# Eval("StatusName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">

                        <ItemTemplate>
                            <%-- <%#Eval("ShowDelete")%>--%>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Enable" CommandArgument=' <%# Eval("Fguid") %>'
                                OnClientClick="return confirm('确认要启用吗？');" CssClass='<%#Eval("ShowDelete")%>'>启用</asp:LinkButton>

                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('确认要删除吗？');" CssClass='<%#Eval("ShowDelete")%>'>删除</asp:LinkButton>


                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </AspNet:GridView>
        </div>
    </form>
</body>
</html>
