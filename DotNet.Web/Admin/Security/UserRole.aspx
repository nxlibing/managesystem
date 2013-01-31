<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="DotNet.Web.Admin.Security.UserRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(function () {
            $("#checkall").click(function () {
                if (!!$("#checkall").attr("checked")) {
                    //  debugger;
                    $("#ctlRoleList :checkbox").each(function () {
                        $(this).attr("checked", true);
                    });
                }
                else {
                    $("#ctlRoleList :checkbox").each(function () {
                        $(this).attr("checked", false);
                    });
                }
            });

            var api = art.dialog.open.api;
            api.button({
                name: '保存',
                calDotNetack: CalDotNetack
            }, {
                name: '取消',
                calDotNetack: function () { api.close(); }
            });
        });


        function CalDotNetack() {
            art.dialog.tips("数据请求中.....");
            var args = GetValues();
            DoPostBack("DotNetCustomCalDotNetack", args);
            return false;
        }

        function EndCustomCalDotNetack(e) {
            art.dialog.open.origin.EndCustomCalDotNetack(e);
        }

        function GetValues() {
            var values = "";
            $("input[name^='ctlRoleList']").each(function () {
                if (this.checked) {
                    //$(this):当前checkbox对象;
                    //$(this).parent("span"):checkbox父级span对象
                    values += $(this).parent("span").attr("alt") + ",";
                }
            });
            return values;
        }
    </script>
    <style type="text/css">
        html, body
        {
            background: #fff;
            font-size: 12px;
        }
        #userinfo
        {
            color: Red;
            font-weight: bold;
        }
        
        table tr
        {
            line-height: 35px;
            text-indent: 7px;
        }
        
        table td
        {
            width: 25%;
        }
        .index
        {
            line-height: 40px;
            text-indent: 7px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <AspNet:DotNetCustomCalDotNetack ID="DotNetCustomCalDotNetack" runat="server" UseSubmitBehavior="false"
        OnCustomCalDotNetack="DotNetCustomCalDotNetack_CustomCalDotNetack" EndCalDotNetack="EndCustomCalDotNetack" />
    <div class="index">
        请为用户<span id="userinfo" runat="server"></span> 设置角色
    </div>
    <div class="index">
        <asp:CheckBox ID="checkall" runat="server" Text="全选" />
    </div>
    <div>
        <asp:CheckBoxList ID="ctlRoleList" runat="server" RepeatDirection="Horizontal" Width="100%"
            BorderStyle="None" RepeatColumns="4">
        </asp:CheckBoxList>
    </div>
    </form>
</body>
</html>
