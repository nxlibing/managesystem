using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Repositories;
using DotNet.DataAccess;
using DotNet.Business.Security.Entities;
using System.Collections;
using NHibernate.Criterion;
using DotNet.Common;

namespace DotNet.Business.Security.Repositories
{
    public class ModuleRepository : Repository
    {
        public ModuleRepository(ICommonDao commonDao)
            : base(commonDao)
        { }

        public IList<Base_Module> GetModuleList(string[] fguids)
        {
            return CommonDao.GetByIds<Base_Module>(fguids);
        }

        public IList<Base_Module> GetList(string sysno)
        {
            string hql = string.Format("from Base_Module where Pguid='?'", sysno);
            IList list = CommonDao.GetByHql(hql, new object[] { sysno });
            return list.OfType<Base_Module>().ToList();
        }

        public IList<Base_Module> GetList()
        {
            return CommonDao.GetAll<Base_Module>();
        }

        public IList<Base_Module> GetQueryList(string filter, int pageindex, int pagesize, out int count)
        {
            DetachedCriteria criteria = DetachedCriteria.For<Base_Module>();

            // criteria.Add(Expression.Like("Realname", "%" + filter + "%"));
            criteria.SetProjection(Projections.RowCount());
            count = this.GetUniquResult<int>(criteria);

            criteria.SetProjection(null);
            criteria.AddOrder(Order.Asc("Moduleno"));
            //   this.GetAlDotNetyCriteria<Base_Module>(criteria);
            return this.GetAlDotNetyCriteria<Base_Module>(criteria);
        }

        public bool SaveOrUpdate(Base_Module data)
        {
            try
            {
                if (string.IsNullOrEmpty(data.Moduleno))
                {
                    data.Moduleno = GenerateModuleNo(data.Pguid);
                }
                CommonDao.SaveOrUpdate(data);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("用户数据编辑", e);
                return false;
            }
        }

        public string GenerateModuleNo(string pguid)
        {
            string result = "";
            string maxno = GetMaxModuleNo(pguid);
            if (string.IsNullOrEmpty(maxno))
            {
                Base_Module data = GetObjectById<Base_Module>(pguid);
                result = data.Moduleno + "01";
            }
            else
            {
                int newno = int.Parse(maxno) + 1;
                string newnostr = newno.ToString();
                if (newnostr.Length % 2 != 0)
                {
                    result = "0" + newnostr;
                }
                else
                {
                    result = newnostr;
                }
            }
            return result;
        }

        public string GetMaxModuleNo(string pguid)
        {
            string hql = string.Format("SELECT max(Moduleno) as m FROM Base_Module where Pguid='{0}'", pguid);
            IList list = CommonDao.GetByHql(hql, new object[] { });
            return list[0].ToString2();
        }

        public int Delete(string[] fguids)
        {
            try
            {
                return CommonDao.Delete<Base_Module>(fguids);
            }
            catch (Exception e)
            {
                Log.Error("用户数据删除时", e);
                return -1;
            }
        }
    }
}
