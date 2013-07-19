<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleManage1.aspx.cs" Inherits="DotNet.Web.Admin.Security.ModuleManage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Style/Js/jquery-1.9.0.min.js"></script>
    <script src="../../EasyUI/jquery.easyui.min.js"></script>
    <link href="../../EasyUI/themes/gray/easyui.css" rel="stylesheet" />
    <link href="../../EasyUI/themes/icon.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $('#tt').treegrid({

                pagination: true,
                rownumbers: true,


                title: '重复的未初分提案',
                loadMsg: "数据加载中，请稍后……",
                method: 'GET',
                url: 'Handler/ModuleManage.ashx',
                idField: 'Fguid',
                treeField: 'Moduleno',
                columns: [[
                    { title: '选择', checkbox: true },
                    { field: 'Moduleno', title: 'Moduleno' },
                    { title: 'Title', field: 'Title' },
                    { field: 'Description', title: 'Description', align: 'right' },

                    { field: 'Navigateurl', title: 'Navigateurl' },
                    { field: 'Status', title: 'Status' }
                ]],
                toolbar: [{
                    id: 'btnadd',
                    text: 'Add',
                    iconCls: 'icon-add',
                    handler: function () {
                        $('#btnsave').linkbutton('enable');
                        alert('add')
                    }
                }, {
                    id: 'btncut',
                    text: 'Cut',
                    iconCls: 'icon-cut',
                    handler: function () {
                        $('#btnsave').linkbutton('enable');
                        alert('cut')
                    }
                }, '-', {
                    id: 'btnsave',
                    text: 'Save',
                    disabled: true,
                    iconCls: 'icon-save',
                    handler: function () {
                        $('#btnsave').linkbutton('disable');
                        alert('save')
                    }
                }]
            });
        });
    </script>
    <style type="text/css">
        body {
            /*margin: 0;
            padding: 0;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table id="tt" class="easyui-datagrid"></table>

    </form>
</body>
</html>
