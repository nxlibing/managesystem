using DotNet.Business.Security.Entities;
using DotNet.Business.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Web.Admin.Security.Handler
{
    /// <summary>
    /// ModuleManage 的摘要说明
    /// </summary>
    public class ModuleManage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string r = GetData();
            context.Response.Write(r);
        }

        public string GetData()
        {
            string r = "";

            ModuleRepository _repository = DotNet.Common.Ioc.Resolve<ModuleRepository>();

            int i = 0;
            IList<Base_Module> list = _repository.GetQueryList(null, 0, 0, out i);

            var presult = from p in list where string.IsNullOrEmpty(p.Pguid) select p;

            IList<Base_Module> plist = presult.ToList<Base_Module>();
            foreach (var item in plist)
            {
                string subr = GetSubMenu(item.Fguid, list);

                r += item.ToJson() + ",";
                if (subr.Length > 0)
                {
                    r = r.Substring(0, r.Length - 2) + ",\"children\":[" + subr.Substring(0, subr.Length - 1) + "]},";
                }
            }

            r = "[" + r.Substring(0, r.Length - 1) + "]";
            //  r = r.Replace("},\"children\":", ",\"children\":");
            return r;
        }

        private string GetSubMenu(string pguid, IList<Base_Module> list)
        {
            string r = "";
            var subresult = from p in list where p.Pguid == pguid select p;

            IList<Base_Module> sublist = subresult.ToList<Base_Module>();
            foreach (var item in sublist)
            {
                string subr = GetSubMenu(item.Fguid, list);
                r += item.ToJson() + ",";
                if (subr.Length > 0)
                {
                    r = r.Substring(0, r.Length - 2) + ",\"children\":[" + subr.Substring(0, subr.Length - 1) + "]},";
                }
            }
            return r;
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