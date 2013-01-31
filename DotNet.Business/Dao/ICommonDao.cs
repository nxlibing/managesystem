using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate;
using DotNet.Entitity;
using DotNet.Core.Query;
using DotNet.Core;
using DotNet.Facilities.NHibernateIntegration;

namespace DotNet.DataAccess
{
    /// <summary>
    /// ͨ�����ݷ��ʽӿ�
    /// </summary>
    public interface ICommonDao
    {
        /// <summary>
        /// NH Session������
        /// </summary>
        ISessionManager SessionManager { get; }

        /// <summary>
        /// ����ָ�������ͺ����������ݿ��ȡһ��ʵ��
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="id">����</param>
        /// <returns>����Ķ��󣬻���Ϊnull</returns>
        object GetObjectById(Type type, String id);

        /// <summary>
        /// ����ָ�������ͺ����������ݿ��ȡһ��ʵ��. 
        /// ����ָ����û����������ʱ���Ƿ���Է���null
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="id">����</param>
        /// <param name="allowNull">�ܷ���Է���null</param>
        /// <returns>����Ķ���</returns>
        object GetObjectById(Type type, String id, bool allowNull);

        /// <summary>
        /// ����ָ�������ͺ����������ݿ��ȡһ��ʵ��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>����Ķ��󣬻���Ϊnull</returns>
        T GetObjectById<T>(String id);

        /// <summary>
        /// ����ָ����queryData�����������ķ�ʽ��ϣ������ݿ��������
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>        
        /// <param name="queryData">��������</param>
        /// <param name="mathType">�ַ�����ƥ�䷽ʽ��Ĭ��Ϊȫƥ��</param>
        /// <returns>����ķ�ʽ��ϲ�ѯ�Ľ��</returns>
        IList<T> CompositeList<T>(BusinesBase queryData, CriteriaOperator criteriaOperator = CriteriaOperator.Full) where T : BusinesBase;

        /// <summary>
        /// ����ָ��������ֵ��ȡ�����ݿ��ȡָ�����͵ĵ������ݶ���
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="propertyName">�����ֶ�����</param>
        /// <param name="description">����ֵ</param>
        /// <returns>����Ķ���</returns>
        object GetObjectByProperty(Type type, string propertyName, object value);

        /// <summary>
        /// ����ָ��������ֵ��ȡ�����ݿ��ȡָ�����͵ĵ������ݶ���
        /// </summary>
        /// <typeparam name="T">��������</param>
        /// <param name="propertyName">�����ֶ�����</param>
        /// <param name="description">����ֵ</param>
        /// <returns>����Ķ���</returns>
        T GetObjectByProperty<T>(string propertyName, object value);

        /// <summary>
        /// ��ȡָ�����͵����ж���
        /// </summary>
        /// <param name="type">��������</param>
        /// <returns>ָ�����͵��������ݿ����ݶ���</returns>
        IList GetAll(Type type);

        /// <summary>
        /// ��ȡָ�����͵����ж���
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <returns>ָ�����͵��������ݿ����ݶ���</returns>
        IList<T> GetAll<T>();

        /// <summary>
        /// ��ȡָ�����͵��������ݣ�������ָ������������.
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="sortProperties">�������ԣ��ֶΣ�</param>
        /// <returns>����ָ��������������������</returns>
        IList GetAll(Type type, OrderType orderType = OrderType.Asc, params string[] sortProperties);

        /// <summary>
        /// ��ȡָ�����͵��������ݣ�������ָ������������(ascending).
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="sortProperties">�������ԣ��ֶΣ�</param>
        /// <returns></returns>
        IList<T> GetAll<T>(OrderType orderType = OrderType.Asc, params string[] sortProperties);

        /// <summary>
        /// ��ȡ������criteriaƥ��Ķ���.
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="criteria">NHibernate DetachedCriteria ����.</param>
        /// <returns>����criteriaƥ��Ķ���</returns>
        /// <remarks>
        /// ��Ҫ��UI��ʹ�ã������ᵼ��UI���Nhibernate������
        /// </remarks>
        IList<T> GetAlDotNetyCriteria<T>(DetachedCriteria criteria);

        /// <summary>
        /// ��ȡ������criteriaƥ��Ķ���.
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="criteria">NHibernate DetachedCriteria ����.</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="pageSize">��ҳ��С</param>
        /// <returns>����criteriaƥ��Ķ���</returns>
        /// <remarks>
        /// ��Ҫ��UI��ʹ�ã������ᵼ��UI���Nhibernate������
        /// </remarks>
        IList<T> GetAlDotNetyCriteria<T>(DetachedCriteria criteria, int start, int pageSize);

        /// <summary>
        /// ��ȡָ��fguid�����ж���
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="ids">fguid����</param>
        /// <returns></returns>
        IList<T> GetByIds<T>(String[] ids);

        /// <summary>
        /// ͨ�����ε�hql��ѯ����
        /// </summary>
        /// <param name="hql">hql��ѯ���</param>
        /// <param name="values">ֵ</param>
        /// <returns>���ϲ�ѯ�����Ĳ�ѯ���</returns>
        /// <remarks>valusesֵ��˳������hql��Ĳ���һһ��Ӧ</remarks>
        IList GetByHql(String hql, object[] values);

        /// <summary>
        /// ͨ�����ε�hql��ѯ����
        /// </summary>
        /// <param name="hql">hql��ѯ���</param>
        /// <param name="values">ֵ</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="pageSize">��ҳ��С</param>
        /// <returns>���ϲ�ѯ�����Ĳ�ѯ���</returns>
        /// <remarks>valusesֵ��˳������hql��Ĳ���һһ��Ӧ</remarks>
        IList GetByHql(String hql, object[] values, int start, int pageSize);

        /// <summary>
        /// ͨ�����ε�hql��ѯ����(��ѯΨһֵ)
        /// </summary>
        /// <param name="hql">hql��ѯ���</param>
        /// <param name="values">ֵ</param>
        /// <returns>���ϲ�ѯ�����Ĳ�ѯ���</returns>
        /// <remarks>valusesֵ��˳������hql��Ĳ���һһ��Ӧ</remarks>
        T GetUniqueResult<T>(String hql, object[] values);

        /// <summary>
        /// ͨ��Criteria��ѯ����(��ѯΨһֵ)
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="criteria">��ѯ����</param>
        /// <returns></returns>
        T GetUniqueResult<T>(DetachedCriteria criteria);

        /// <summary>
        /// ������߸������ݿ����
        /// </summary>
        /// <param name="obj">���ݶ���</param>
        /// <param name="unitOfWork">������Ԫ</param>
        void SaveOrUpdate(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="obj">���ݶ���</param>
        /// <param name="unitOfWork">������Ԫ</param>
        void Update(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// ��ʽ����
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="unitOfWork">������Ԫ</param>
        void Save(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// ������ɾ��ָ���Ķ���
        /// </summary>
        /// <param name="obj">ɾ������</param>
        /// <param name="unitOfWork">������Ԫ</param>
        void Delete(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// ͨ��idɾ������
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="id">����</param>
        /// <param name="unitOfWork">������Ԫ</param>
        /// <returns>ɾ���ļ�¼����</returns>        
        int Delete<T>(String id, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// ����ָ���Ĳ�ѯɾ��ָ��������(�ʺ����������)
        /// </summary>        
        /// <param name="query">��ѯ�ַ���</param>
        /// <param name="values">ֵ</param>
        /// <param name="types">ֵ��Nhibernate����</param>
        /// <param name="unitOfWork">������Ԫ</param>
        /// <returns>����ɾ������Ŀ</returns>
        int Delete(String query, object[] values, NHibernate.Type.IType[] types, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// ɾ��ָ��������(�������ݵ�����)
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="deleteDatas">��Ҫɾ��������</param>
        /// <param name="unitOfWork">������Ԫ</param>
        /// <returns>ɾ������������</returns>        
        int Delete<T>(IList<T> deleteDatas, IUnitOfWork unitOfWork = null) where T : BusinesBase;
        
        /// <summary>
        /// ɾ��ָ�������ݼ�(�������ݵ���������)
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="fguids">��Ҫɾ����������������</param>
        /// <param name="unitOfWork">������Ԫ</param>
        /// <returns>ɾ������������</returns>
        int Delete<T>(string[] fguids, IUnitOfWork unitOfWork = null) where T : BusinesBase;

        /// <summary>
        /// �Ӷ����������Ƴ�ָ���ļ���
        /// </summary>
        /// <param name="roleName"></param>
        void RemoveCollectionFromCache(string roleName);

        /// <summary>
        /// �Ӷ����������Ƴ�ָ���ļ���
        /// </summary>
        /// <param name="roleName">���ϵ�ȫ�� (e.g. DotNet.Bussiness.Domain.Node.ChildNodes).</param>
        /// <param name="id">���϶��������ߵ�����</param>
        void RemoveCollectionFromCache(string roleName, String id);

        /// <summary>
        /// �ӻ������Ƴ�һ����ѯ
        /// </summary>
        /// <param name="cacheRegion">�Ƴ��Ĳ�ѯ����</param>
        void RemoveQueryFromCache(string cacheRegion);

        /// <summary>
        /// �ѵ�ǰ���е����ݸ���д�����ݿ�
        /// </summary>
        void Flush();

        /// <summary>
        /// ���Session
        /// </summary>
        void Clear();

        /// <summary>
        /// ������ˢ��ָ���Ķ���
        /// </summary>
        void Refresh(object obj);

        /// <summary>
        /// ��nh session�������Ƴ�ָ������
        /// </summary>
        /// <param name="obj">nh session���Ƴ��Ķ���</param>
        void Evict(object obj);
    }
}
