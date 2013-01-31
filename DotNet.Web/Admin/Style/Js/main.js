var title = $(document).attr("title") + "-";

$(function () {
    setHeight();
    GetMenu("01");
    $("#leftbar li").live('click', function () {
        // $("#message").text("正在加载..");
        loading('页面加载......<img src="Style/artDialog4.1.6/skins/icons/loading.gif" width="16" height="16" alt="" /><span style=" magin_left:3px; line_height:15px;"></span>');
        setFrameUrl(this);
        $(this).addClass("current");

        var link = getCtlPropertyValue(this, "dir");

        $("#nav").html(link);
    });
    $("#righttop li").click(function () {
        setFrameUrl(this);
    });
    //    $("#adminmenu a").click(function () {
    //        setFrameUrl(this);
    //        return false;
    //    });
    $("#TabPage li").live('click', function () {
        SetMenu(this);
    });
    $("#nav a").live('click', function () {
        setFrameUrl(this);
        return false;
    });

    //    $("#splitbar").click(function () {
    //        leftBarExpansion();
    //    });
    $(window).resize(function () {
        setHeight();
    });
    $("#sysMain").load(function () {
        art.dialog({ id: 'pageLoadingTips' }).close();
    });
    IsLockScreen();
    document.onkeydown = function () {
        if (event.keyCode == 116) {
            event.keyCode = 0;
            event.returnValue = false;
        }
    }

    document.oncontextmenu = function () { event.returnValue = false; }
    //  notice("测试", "测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容", 3);
});

function notice(title, content, time) {
    art.dialog.notice({
        title: title,
        width: 220, // 必须指定一个像素宽度值或者百分比，否则浏览器窗口改变可能导致artDialog收缩
        content: content,
        icon: 'face-sad',
        time: (time || 5)
    });
}

function setHeight() {
    var height = $(window).height() - 69 - 49;
    var width = $(window).width() - 204;
    $("#leftbar").height(height - 12);
    $("#splitbar").height(height);
    $("#content").height(height);
    $("#content").width(width);
    $("#sysMain").height(height);
    $("#sysMain").width(width);
}

function setFrameUrl(a) {
    var url = getCtlPropertyValue(a, "href");
    if (url != undefined) {
        $('#sysMain').attr("src", url + "?rd=" + Math.random());
        $("#leftbar").find(".current").removeClass("current");
    }
}

function getCtlPropertyValue(ctl, property) {
    return $(ctl).attr(property); // + ;
}

function SetMenu(o) {
    var $li = $(o);
    var id = $li.attr("id");
    GetMenu(id);
    $(document).attr("title", title + $li.text());
    $("#TabPage").find(".Selected").removeClass("Selected");
    $li.addClass("Selected");
    $('#sysMain').attr("src", "main-index.aspx");
}

function GetMenu(id) {
    $.post("../Handler/MenuHandler.ashx", { id: id }, function (result) {
        var data = eval('(' + result + ')');
        $("#TabPage").html(data.mainmenu);
        $("#leftbar").html(data.leftmenu);
    });
}

function leftBarExpansion() {
    var staus = getCtlPropertyValue("#splitbar", "class");
    if (staus == "close") {
        $("#leftbar").width(0);
        //debugger;
        var width = $(window).width() - 6;
        $("#content").width(width);
        $("#sysMain").width(width);

        $('#splitbar').attr("class", "open");
    }
    else {
        $("#leftbar").width(198);
        var width = $(window).width() - 204;
        $("#content").width(width);
        $("#sysMain").width(width);

        $('#splitbar').attr("class", "close");
    }
}

function loading(content) {
    var top = $("#sysMain").height() / 2 + 50;
    var left = $("#sysMain").width() / 2 + 150;

    artDialog.pageloading(content, left, top);
}


function ChangePassword() {
    WinOpen("密码修改", "Security/Password.aspx", 400, 140);
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
}
function LockScreen() {
    addCookie("islockscreen", "true", 0)
    art.dialog.prompt.lock('请输入密码解除屏幕锁定？', function (data) {
        if (PasswordMatch(data)) {
            deleteCookie("islockscreen");
            return true;
        }
        return false;
    });
}
function PasswordMatch(value) {
    if (hex_md5(value) != $("#username").attr("p").toLocaleLowerCase()) {
        return false;
    }
    else { return true; }
}

function IsLockScreen() {
    var flag = getCookie("islockscreen");
    if (flag == "true") {
        LockScreen();
    }
}