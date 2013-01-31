using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Business.Security.Domain
{
    public class User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string Userid { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// MD5密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Realname { get; set; }

        /// <summary>
        /// 用户状态   
        /// -1非法字符 0用户未启用 1正常
        /// 2用户不存在 3密码错误 4没有登录权限
        /// </summary>
        public int LoginStatus { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public List<string> ModuleList { get; set; }
    }
}
