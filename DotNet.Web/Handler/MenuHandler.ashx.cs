using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DotNet.Business.Security.Repositories;
using DotNet.Common;
using DotNet.Business.Security.Entities;

namespace DotNet.Web.UI.Handler
{
    /// <summary>
    /// MenuHandler 的摘要说明
    /// </summary>
    public class MenuHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["id"];
            string r = GetMenu(id);
            context.Response.Write(r);
        }

        private string GetMenu(string sysNo)
        {
            string result = "{{\"mainmenu\":\"{0}\",\"leftmenu\":\"{1}\"}}";

            string mainmenu = "";
            string leftmenu = "";
            IList<Base_Module> list = GetMenuList();

            var a = from p in list where string.IsNullOrEmpty(p.Pguid) select p;
            IList<Base_Module> newlist = a.ToList<Base_Module>();
            string li = "<li {2} id='{1}' >{0}</li>";
            string selectclass = "";
            foreach (var item in newlist)
            {
                if (item.Moduleno == sysNo)
                {
                    selectclass = "class='Selected'";

                    leftmenu += CreateMenu(item.Fguid, list);
                }
                else { selectclass = ""; }
                mainmenu += string.Format(li, item.Title, item.Moduleno, selectclass);
            }

            //string leftmenu = "";
            //var a = from p in list where p.Fguid == (sysNo) select p;
            //IList<Base_Module> newlist = a.ToList<Base_Module>();
            //foreach (var item in newlist)
            //{
            //    leftmenu += CreateMenu(item.Fguid, list);
            //}
            //            switch (sysNo)
            //            {
            //                case "manage":
            //                    r = @"<ul>
            //                <span>主菜单 </span>                <li href='Content.aspx'>子菜单</li><li href='login.aspx'>子菜单1</li><li href='login.aspx'>子菜单1</li>
            //            </ul>";
            //                    break;
            //                case "manage1":
            //                    r = @"<ul>
            //                <span>主菜单 1</span>                <li href='login.aspx'>子菜单1</li>
            //            </ul>";
            //                    break;
            //                case "manage2":
            //                    r = @"<ul>
            //                <span>主菜单2 </span>                <li href='login.aspx'>子菜单2</li>
            //            </ul>";
            //                    break;
            //            }

            result = string.Format(result, mainmenu, leftmenu);
            return result;
        }

        private string CreateMenu(string fguid, IList<Base_Module> list)
        {
            string menu = "";
            //            string menu = "<ul>{0}</ul>";
            string mainmenu = "<span>{0}</span>";
            string li = "<li href='{1}' dir='{2}'>{0}</li>";
            string title = "<a href=main-index.aspx>首页</a>&gt;<a>{0}</a>&gt;<a href={1}>{2}</a>";
            var a = from p in list where p.Pguid == fguid select p;
            IList<Base_Module> newlist = a.ToList<Base_Module>();
            foreach (var item in newlist)
            {
                if (item.Moduleno.Length == 4)
                {
                    menu += string.Format(mainmenu, item.Title);
                    menu += CreateMenu(item.Fguid, list);
                    menu = string.Format("<ul>{0}</ul>", menu);
                }
                else if (item.Moduleno.Length == 6)
                {
                    var p = from data in list where data.Fguid == fguid select data;
                    string index = "<a href='main-index.aspx'>首页</a>";
                    if (p.Count() > 0)
                    {
                        Base_Module data = p.ToList<Base_Module>()[0];
                        index = string.Format(title, data.Title, item.Navigateurl, item.Title);
                    }

                    menu += string.Format(li, item.Title, item.Navigateurl, index);
                }
            }
            return menu;
        }

        private IList<Base_Module> GetMenuList()
        {
            var data = HttpContext.Current.Session["userAccount"] as Business.Security.Domain.User;
            ModuleRepository rep = Ioc.Resolve<ModuleRepository>();
            //IList<Base_Module> list = rep.GetModuleList(data.ModuleList.ToArray());
            //return list;
            return rep.GetAll<Base_Module>();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}