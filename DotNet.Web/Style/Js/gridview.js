//全选取消按钮函数，调用样式如：
function checkAll(chkobj) {
    // debugger;
    if ($(chkobj).text() == "全选") {
        $(chkobj).text("取消");
        $(".checkall input").attr("checked", true);
    } else {
        $(chkobj).text("全选");
        $(".checkall input").attr("checked", false);
    }
}

function GetFguid(gvname) {
    return GetCheckBoxValue(gvname, "fguid")
}

function GetCheckBoxValue(gvname, colname) {
    var colindex = 1;
    var arrFguid = new Array();
    $("#" + gvname + " th").each(function () {
        if ($(this).text().toLowerCase() == colname.toLowerCase()) {
            colindex = $(this).index();
        }
    });
    $(".checkall input:checked").each(function () {
        var $tr = $(this).parent().parent().parent();
        var value = $tr.find("td").eq(colindex).text();
        arrFguid.push(value);
    });

    return arrFguid;
}

//选中条目
function GetCheckedCount() {
    return $(".checkall input:checked").size();
}
