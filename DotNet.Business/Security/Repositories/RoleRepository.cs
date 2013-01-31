using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Entities;
using NHibernate.Criterion;
using DotNet.Business.Repositories;
using DotNet.DataAccess;
using DotNet.Common;

namespace DotNet.Business.Security.Repositories
{
    public class RoleRepository : Repository
    {
        public RoleRepository(ICommonDao commonDao)
            : base(commonDao)
        { }

        public IList<Base_Role> GetQueryList(string filter, int pageindex, int pagesize, out int count)
        {
            DetachedCriteria criteria = DetachedCriteria.For<Base_Role>();
            criteria.Add(Expression.Like("Rolename", "%" + filter + "%"));
            criteria.SetProjection(Projections.RowCount());
            count = this.GetUniquResult<int>(criteria);

            criteria.SetProjection(null);
            return this.GetAlDotNetyCriteria<Base_Role>(criteria, pageindex, pagesize);
        }

        public bool SaveOrUpdate(Base_Role data)
        {
            try
            {
                CommonDao.SaveOrUpdate(data);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("角色数据编辑", e);
                return false;
            }
        }

        public int Delete(string[] fguids)
        {
            try
            {
                return CommonDao.Delete<Base_Role>(fguids);
            }
            catch (Exception e)
            {
                Log.Error("角色数据删除时", e);
                return -1;
            }
        }

    }
}
