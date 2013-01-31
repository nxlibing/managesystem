<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.aspx.cs" Inherits="DotNet.Web.Admin.Cms.ArticleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <title></title>
    <script src="../Ueditor/editor_config.js" type="text/javascript"></script>
    <script src="../Ueditor/editor_all_min.js" type="text/javascript"></script>
    <script src="../../Style/Js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css">
        .editbody, .edittable .title
        {
            background: #fff;
        }

        input[type="checkbox"]
        {
            margin-top: 8px;
        }

        label
        {
            margin-right: 25px;
        }
    </style>
</head>
<body class="editbody">
    <form id="form1" runat="server">
        <div style="display: none">
            <asp:TextBox ID="txtFguid" runat="server"></asp:TextBox>
        </div>
        <table class="edittable" style="border: none; margin: 15px 0;">
            <tr>
                <td class="title">栏目：
                </td>
                <td colspan="5">
                    <asp:DropDownList ID="ctlCategory" runat="server" Width="403px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="title">标题：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="ctlTitle" runat="server" CssClass="input" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">作者：
                </td>
                <td style="width: 85px; float: left">
                    <asp:TextBox ID="ctlAuthor" runat="server" CssClass="input" Width="80px"></asp:TextBox>
                </td>
                <td class="title" style="width: 50px">来源：
                </td>
                <td style="width: 85px; float: left">
                    <asp:TextBox ID="ctlSource" runat="server" CssClass="input" Width="80px" Text="本站"></asp:TextBox>
                </td>
                <td class="title" style="width: 80px">发布时间：
                </td>
                <td style="float: left">
                    <asp:TextBox ID="ctlPubsj" runat="server" CssClass="input" Width="80px" onClick="WdatePicker()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">推荐类型：
                </td>
                <td colspan="5">
                    <asp:CheckBoxList ID="ctlRecomendType" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="color" Text="醒目"></asp:ListItem>
                        <asp:ListItem Value="hot" Text="热点"></asp:ListItem>
                        <asp:ListItem Value="top" Text="置顶"></asp:ListItem>
                        <asp:ListItem Value="recomend" Text="推荐"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="title">外部链接：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="ctlLinkurl" runat="server" CssClass="input" Width="400px" Text="http://"></asp:TextBox>如：http://www.baidu.com
                </td>
            </tr>
            <tr>
                <td class="title" style="height: 450px; vertical-align: top;">内容：
                </td>
                <td colspan="5">
                    <script type="text/plain" id="editor"></script>
                    <asp:Label ID="ctlContent" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="title">内容简介：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="ctlIntroduction" runat="server" Width="400px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">关键字：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="ctlKeywords" runat="server" CssClass="input" Width="400px"></asp:TextBox>请输入关键字以逗号分割，长度限制在25个字符以内！
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-indent: 100px;">
                    <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
<script type="text/javascript">
    var op = {
        initialFrameWidth: 620,
        wordCount: false,
        elementPathEnabled: false,
        autoHeightEnabled: false,
        textarea: 'editorValue',
        initialContent: ''
    };
    var editor = UE.getEditor('editor', op);

    editor.addListener('contentChange ', function () {
        $("#ctlIntroduction").val(editor.getContentTxt().substring(0, 100) + "...");
    })
    editor.setContent($("ctlContent").val());
</script>
</html>
