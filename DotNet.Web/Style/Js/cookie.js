//该函数接收3个参数：cookie名称，cookie值，以及在多少小时后过期。
//这里约定expireHours为0时不设定过期时间，即当浏览器关闭时cookie自动消失
function addCookie(name,value,expireHours){
    var cookieString=name+"="+escape(value);
    //判断是否设置过期时间
    if(expireHours>0){
        var date=new Date();
        date.setTime(date.getTime+expireHours*3600*1000); // 转换为毫秒
        cookieString=cookieString+"; expire="+date.toGMTString();
    }
    document.cookie=cookieString;
}

//返回名称为name的cookie值，如果不存在则返回空
function getCookie(name){
    var strCookie=document.cookie;
    var arrCookie=strCookie.split("; "); // 将多cookie切割为多个名/值对
    for(var i=0;i<arrCookie.length;i++){ // 遍历cookie数组，处理每个cookie对
        var arr=arrCookie[i].split("="); // 找到名称为userId的cookie，并返回它的值
        if(arr[0]==name)
            return arr[1];
    }
    return "";
}
//删除指定名称的cookie
function deleteCookie(name){
    var date=new Date();
    date.setTime(date.getTime()-10000); // 删除一个cookie，就是将其过期时间设定为一个过去的时间
    document.cookie=name+"=v; expire="+date.toGMTString();
}
