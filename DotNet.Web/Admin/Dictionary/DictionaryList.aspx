<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictionaryList.aspx.cs"
    Inherits="DotNet.Web.Admin.Dictionary.DictionaryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Style/Js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Style/Js/jquery.metadata.js" type="text/javascript"></script>
    <script type="text/javascript">

        function Add() {
            if ($("#form1").valid()) {
                art.dialog.tips("数据请求中.....");
                DoPostBack("DotNetCustomCalDotNetack", "");
            }
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <AspNet:DotNetCustomCalDotNetack ID="DotNetCustomCalDotNetack" runat="server" UseSubmitBehavior="false"
            OnCustomCalDotNetack="DotNetCustomCalDotNetack_CustomCalDotNetack" />
        <div class="container">
            <div class="search">
                <div class="addtitle">
                    添加
                </div>
                <div class="searchcontent">
                    <span>添加字典分类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span>编码：</span> <span>
                        <asp:TextBox ID="ctlCode" runat="server" CssClass="input {required:true,messages:{required:'不能为空'}}" Width="200px"></asp:TextBox>
                    </span><span>名称：</span> <span>
                        <asp:TextBox ID="ctlName" runat="server" CssClass="input {required:true,messages:{required:'不能为空'}}" Width="200px"></asp:TextBox>
                    </span>
                    <span>
                        <input id="Button2" type="button" value="添加" onclick="Add()" />
                    </span>
                </div>
            </div>

            <AspNet:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClassMouseOver="RowHover" DataKeyNames="Fguid"
                Width="100%" AlternatingRowStyle-CssClass="AlternatingRow" CssClass="listtable" OnRowDeleting="GridView1_RowDeleting"
                OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="编码" HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Name" HeaderText="名称" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Fguid" HeaderText="Fguid" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                    <asp:CommandField ShowEditButton="True" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">

                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('确认要删除吗？');" Visible='<%#Eval("ShowDelete")%>'
                                Text="删除" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </AspNet:GridView>
        </div>
    </form>
</body>
</html>
