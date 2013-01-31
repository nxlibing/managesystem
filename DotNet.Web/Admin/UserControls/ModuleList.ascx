<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleList.ascx.cs" Inherits="DotNet.Web.Admin.UserControls.ModuleList" %>
<style type="text/css">
    table tr {
        overflow: scroll;
    }

    label {
        padding-right: 0px;
        padding-left: 3px;
        font-size: 1.1em;
        padding-bottom: 0px;
        padding-top: 0px;
    }

    table {
        border: 0px;
        padding: 0px;
        margin: 0px;
    }

        table tr {
            border: 0px;
            padding: 0px;
            margin: 0px;
        }

        table td {
            border: 0px;
            padding: 0px;
            margin: 0px;
            line-height: 20px;
        }
</style>
<script type="text/javascript">


    var a_box = null;

    //根据标记取得checkbox
    function getBoxByMark(mark) {
        for (i = 0; i < a_box.length; i++) {
            if ($(a_box[i]).attr("fguid") == mark) {
                return a_box[i];
            }
        }
    }

    //检查父选项
    function checkFatherBox(fmark) {
        if (fmark != "0") {
            //默认自己没有被选中
            var myChecked = false;
            for (var i = 0; i < a_box.length; i++) {
                //如果有兄弟菜单
                if ($(a_box[i]).attr("pguid") == fmark) {
                    //如果兄弟菜单被选中
                    if (a_box[i].checked == true) {
                        myChecked = true;
                    }
                }
            }
            var myEle = getBoxByMark(fmark);
            myEle.checked = myChecked;
            //回调本函数
            checkFatherBox($(myEle).attr("pguid"));
        }
    }

    //检查子选项
    function checkChildenBox(ele, mark) {
        for (var i = 0; i < a_box.length; i++) {
            //如果当前节点是传入节点的子节点
            if ($(a_box[i]).attr("pguid") == mark) {
                //如果当前节点没被选中
                if (ele.checked == false) {
                    a_box[i].checked = false;
                } else {
                    a_box[i].checked = true;
                }
                //回调本函数
                checkChildenBox(a_box[i], $(a_box[i]).attr("fguid"));
            }
        }
    }

    //检查选项框
    function checkThisBox(ele) {
        //如果没有取得选项树的集合，那就取得该选项树。
        if (a_box == null) {
            a_box = $("input:checkbox");
        }
        //检查父选项卡
        checkFatherBox($(ele).attr("pguid"));
        //检查子选项卡
        checkChildenBox(ele, $(ele).attr("fguid"));
    }
</script>
<asp:Table ID="TableList" runat="server"></asp:Table>
