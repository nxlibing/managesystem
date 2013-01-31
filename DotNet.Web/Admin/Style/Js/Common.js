//重写__doPostBack
function DoPostBack(eventTarget, eventArgument) {

    var theform = document.forms['form1'];
    if (!theform) {
        theform = document.form1;
    }

    if (theform.__EVENTTARGET != null) {
        theform.__EVENTTARGET.value = eventTarget;
    }

    if (theform.__EVENTARGUMENT != null) {
        theform.__EVENTARGUMENT.value = eventArgument;
    }
    theform.submit();
}

//获取页面控件的值json输出
function GetControlValues() {
    var result = '{{0}}';
    var propertyvalue = '"{0}":"{1}"';
    var propertyvalues = "";
    var arrInput = document.getElementsByTagName("input");
    var arrSelect = document.getElementsByTagName("select");
    //  debugger;
    // var arrAll = arrInput.push(arrSelect);
    //      var   myid   =   document.getElementById("tryselect");   
    //      alert(myid.options[myid.selectedIndex].value   +"\n"   +myid.options[myid.selectedIndex].text)   
    var key = "";
    var value = "";
    for (i = 0; i < arrInput.length; i++) {
        //  debugger;
        if (arrInput[i].id.indexOf("txt") == 0) {
            if (arrInput[i].type == 'checkbox') {
                value = arrInput[i].checked;
            }
            else {

                value = arrInput[i].value;
            }
            key = arrInput[i].id.substring(3);
            propertyvalues = propertyvalues + String.format(propertyvalue, key, value) + ",";
        }
    }
    for (i = 0; i < arrSelect.length; i++) {
        value = arrSelect[i].options[arrSelect[i].selectedIndex].value
        key = arrSelect[i].id.substring(3);
        propertyvalues = propertyvalues + String.format(propertyvalue, key, value) + ",";
    }
    result = String.format(result, propertyvalues.substring(0, propertyvalues.length - 1));
    return result;
}

//格式化输出
String.format = function () {

    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}

//执行回传函数
function ExePostBack(objId, gvname, colname) {
    if ($(".checkall input:checked").size() < 1) {
        $.dialog.alert('对不起，请选中您要操作的记录！');
        return false;
    }
    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }

    $.dialog.confirm(msg, function () {
        var arr = GetCheckBoxValue(gvname, colname);

        //  __doPostBack(objId, arr);
    });
    return false;
}

function ExecuteDelete(calDotNetackctlid, gvname, colname) {
    var count = GetCheckedCount();
    if (count < 1) {
        art.dialog.tips("对不起，请选中您要操作的记录！", 1);
        return;
    }
    var msg = "删除记录后不可恢复，您确定删除这&nbsp;<font  color='red'>" + count + "</font>&nbsp;条记录吗？";

    art.dialog.confirm(msg, function () {
        var arguments = GetCheckBoxValue(gvname, colname);
        //debugger;
        // art.dialog.alert(a[1]);
        // art.dialog.alert("helloword!", 1);
        //debugger;
        DoPostBack(calDotNetackctlid, 'del_' + arguments);
    });
}

function ExecuteEdit(title, url, width, height, gvname, colname) {
    var count = GetCheckedCount();
    if (count > 1) {
        art.dialog.tips("请重新选择，只能同时编辑一条数据！", 1);
        return;
    }
    else if (count < 1) {
        art.dialog.tips("请选择一条需要编辑的数据！", 1);
        return;
    }
    if (colname == undefined) {
        colname = "Fguid";
    }
    var arr = GetCheckBoxValue(gvname, colname);
    url += "?fguid=" + arr[0] + "&rd=" + Math.random();
    WinOpen(title, url, width, height)
}

function ExecuteAdd(title, url, width, height, fguid) {
    url += "?rd=" + Math.random();
    if (fguid != undefined) {
        url += "&pguid=" + fguid;
    }
    WinOpen(title, url, width, height)
}

function WinOpen(title, url, width, height) {
    art.dialog.open(url, {
        lock: true,
        width: width,
        height: height,
        padding: 0,
        title: title,
        zIndex: 0,
        id: 'winPage'
    });


    //   art.dialog.open(url);
}

function WinClose() {

    art.dialog({ id: 'winPage' }).close();
}

//获取控件属性值
function getCtlPropertyValue(ctl, property) {
    return $(ctl).attr(property); // + ;
}

//删除提示
function DeleteTip() {
    art.dialog.confirm('你确认删除该记录？', function () {
        return true;
    }, function () {
        return false;
    });
    return false;
}