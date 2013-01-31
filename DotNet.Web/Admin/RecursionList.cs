using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Business.Cms.Entities;
using DotNet.Business.Security.Entities;
using DotNet.Common.Extensions;

namespace DotNet.Web.Admin
{
    public static class RecursionList
    {
        #region Module
        public static IList<Base_Module> GetModule(IList<Base_Module> list)
        {
            IList<Base_Module> result = new List<Base_Module>();
            var a = from p in list where string.IsNullOrEmpty(p.Pguid) select p;

            IList<Base_Module> rootlist = a.ToList<Base_Module>();
            foreach (var item in rootlist)
            {
                result.Add(item);
                result = result.Merge(GetRecursionModule(item.Fguid, list));
            }
            result.OrderBy(d => d.Moduleno);
            return result;
        }

        private static IList<Base_Module> GetRecursionModule(string fguid, IList<Base_Module> list)
        {
            
            IList<Base_Module> result = new List<Base_Module>();
            var a = from p in list where p.Pguid == fguid select p;
            IList<Base_Module> sublist = a.ToList<Base_Module>();

            char nbsp = (char)0xA0;
            foreach (var item in sublist)
            {
                int nodenolen = item.Moduleno.Length;
                string text = "∟" + item.Title.Trim();
                int len = nodenolen * 2 + text.Length-5;
                item.Title = text.PadLeft(len, nbsp);
                result.Add(item);
                result = result.Merge(GetRecursionModule(item.Fguid, list));
            }
            return result;
        }
        #endregion
        #region Category
        public static IList<Cms_Category> GetCategory(IList<Cms_Category> list)
        {
            IList<Cms_Category> result = new List<Cms_Category>();
            var a = from p in list where string.IsNullOrEmpty(p.Pguid) select p;

            IList<Cms_Category> rootlist = a.ToList<Cms_Category>();
            foreach (var item in rootlist)
            {
                result.Add(item);
                result = result.Merge(GetRecursionCateory(item.Fguid, list));
            }
            result.OrderBy(d => d.Categoryid);
            return result;
        }

        private static IList<Cms_Category> GetRecursionCateory(string fguid, IList<Cms_Category> list)
        {

            IList<Cms_Category> result = new List<Cms_Category>();
            var a = from p in list where p.Pguid == fguid select p;
            IList<Cms_Category> sublist = a.ToList<Cms_Category>();

            char nbsp = (char)0xA0;
            foreach (var item in sublist)
            {
                int nodenolen = item.Categoryid.Length;
                string text = "∟" + item.Title.Trim();
                int len = nodenolen + text.Length;
                item.Title = text.PadLeft(len, nbsp);
                result.Add(item);
                result = result.Merge(GetRecursionCateory(item.Fguid, list));
            }
            return result;
        }
        #endregion
    }
}