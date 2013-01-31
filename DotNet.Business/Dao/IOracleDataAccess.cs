using System;
using System.Data;
namespace DotNet.DataAccess
{
    public interface IOracleDataAccess
    {
        bool ExcuteSql(string sql);
        bool ExcuteSql(string sql, string connectString);
        bool ExcuteSP(string sql);
        DataTable GetDataTable(string connectString, string sql);
        DataTable GetDataTable(string sql);

        /// <summary>
        /// 通过带参的方式获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        DataTable GetDataTable(String sql, String[] parameters, object[] values);


        /// <summary>
        /// 将DataTable插入数据库中
        /// </summary>
        /// <param name="dbtablename">数据库中要插入的表名</param>
        /// <param name="dt">DataTable</param>
        bool InsertDatatable(string dbtablename, DataTable dt, string connectString);
    }
}
