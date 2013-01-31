using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Repositories;
using DotNet.DataAccess;
using DotNet.Business.Security.Entities;
using NHibernate.Criterion;
using DotNet.Common;

namespace DotNet.Business.Security.Repositories
{
    public class UserRepository : Repository
    {
        public UserRepository(ICommonDao commonDao)
            : base(commonDao)
        { }

        public IList<Base_User> GetList()
        {
            return CommonDao.GetAll<Base_User>();
        }

        public IList<Base_User> GetQueryList(string filter, int pageindex, int pagesize, out int count)
        {
            DetachedCriteria criteria = DetachedCriteria.For<Base_User>();

            criteria.Add(Expression.Like("Realname", "%" + filter + "%"));
            criteria.Add(Expression.Not(Expression.Eq("Status", "5")));
            criteria.SetProjection(Projections.RowCount());
            count = this.GetUniquResult<int>(criteria);

            criteria.SetProjection(null);
            return this.GetAlDotNetyCriteria<Base_User>(criteria, pageindex, pagesize);
        }

        public bool SaveOrUpdate(Base_User data)
        {
            try
            {
                CommonDao.SaveOrUpdate(data);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("用户数据编辑", e);
                return false;
            }
        }

        /// <summary>
        /// 用户删除采用假删除的方式，避免用户删除后无法确认业务数据的归属
        /// </summary>
        /// <param name="fguids"></param>
        /// <returns></returns>
        public bool Delete(string[] fguids)
        {
            try
            {
                Core.IUnitOfWork unitOfWork = Ioc.Resolve<Core.IUnitOfWork>();
                IList<Base_User> list = CommonDao.GetByIds<Base_User>(fguids);
                foreach (var item in list)
                {
                    item.Status = UserStatus.Delete;
                    Update<Base_User>(item, unitOfWork);
                }

                unitOfWork.Commit();

                return true;
            }
            catch (Exception e)
            {
                Log.Error("用户数据删除时", e);
                return false;
            }
        }
    }
}
