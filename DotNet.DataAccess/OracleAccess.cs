using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;
using LB.Common;
using System.Data.SqlClient;

namespace LB.DataAccess
{
    public class OracleDataAccess : LB.DataAccess.IOracleDataAccess
    {
        /// <summary>
        /// 根据制定的sql获得DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>
        /// 制定sql的DataTable数据，若出错则返回null
        /// </returns>
        public DataTable GetDataTable(String sql)
        {
            try
            {
                OracleDataAdapter da = new OracleDataAdapter(sql, AppInfo.ConnectString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                LB.Common.Log.Error(String.Format("执行sql:{0}时出错", sql), ex);
                return null;
            }
        }

        public System.Data.DataTable GetDataTable(String sql, String[] parameters, object[] values)
        {
            try
            {
                OracleCommand cmd = new OracleCommand(sql, new OracleConnection(AppInfo.ConnectString));
                OracleParameterCollection cmdParameters = cmd.Parameters;
                for (int i = 0; i < values.Length; ++i)
                {
                    if (values[i].GetType().IsAssignableFrom(typeof(String)))
                    {
                        cmdParameters.Add(parameters[i], OracleType.NVarChar);
                        cmdParameters[i].Value = values[i];
                    }
                    else if (values[i].GetType().IsAssignableFrom(typeof(double)) ||
                        values[i].GetType().IsAssignableFrom(typeof(double?)))
                    {
                        cmdParameters.Add(parameters[i], OracleType.Double);
                        cmdParameters[i].Value = values[i];
                    }
                    else if (values[i].GetType().IsAssignableFrom(typeof(int)) ||
                        values[i].GetType().IsAssignableFrom(typeof(int?)))
                    {
                        cmdParameters.Add(parameters[i], OracleType.Int32);
                        cmdParameters[i].Value = values[i];
                    }
                    else if (values[i].GetType().IsAssignableFrom(typeof(DateTime)) ||
                        values[i].GetType().IsAssignableFrom(typeof(DateTime?)))
                    {
                        cmdParameters.Add(parameters[i], OracleType.DateTime);
                        cmdParameters[i].Value = values[i];
                    }
                }

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                LB.Common.Log.Error(String.Format("执行sql:{0}时出错", sql), ex);
                return null;
            }
        }

        /// <summary>
        /// 根据指定的sql得到DataTable        
        /// </summary>
        /// <param name="connectString">连接字符串</param>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(String connectString, String sql)
        {
            try
            {
                OracleDataAdapter da = new OracleDataAdapter(sql, connectString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                //  LB.Common.Log.Error(String.Format("执行sql:{0}时出错", sql), ex);
                return null;
            }
        }

        public bool ExcuteSql(String sql)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(AppInfo.ConnectString))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;

                    conn.Open();
                    int r = cmd.ExecuteNonQuery();

                    return r >= 0;
                }
            }
            catch (Exception ex)
            {
                // LB.Common.Log.Error(String.Format("执行sql:{0}时出错", sql), ex);
                return false;
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="sql">存储过程执行语句</param>
        /// <returns></returns>
        public bool ExcuteSP(string sql)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(AppInfo.ConnectString))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    int r = cmd.ExecuteNonQuery();

                    return r >= 0;
                }
            }
            catch (Exception ex)
            {
                // LB.Common.Log.Error(String.Format("执行sql:{0}时出错", sql), ex);
                return false;
            }
        }

        /// <summary>
        /// 将DataTable插入数据库中
        /// </summary>
        /// <param name="dbtablename">数据库中要插入的表名</param>
        /// <param name="dt">DataTable</param>
        /// <param name="con">数据库连接字符串</param>
        /// <returns></returns>
        public bool InsertDatatable(string queryString, DataTable dt, string con)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(con))
                {
                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = new OracleCommand(queryString, connection);
                    OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
                    connection.Open();
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr.AcceptChanges();
                        dr.SetAdded();
                    }
                    adapter.Update(dt);
                    connection.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Error(String.Format("检疫监管{0}表统计数据保存时", queryString.Replace("select * from", "")), e);
                return false;
            }
        }

        public bool ExcuteSql(String sql, string con)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(con))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;

                    conn.Open();
                    int r = cmd.ExecuteNonQuery();

                    return r >= 0;
                }
            }
            catch (Exception ex)
            {
                // LB.Common.Log.Error(String.Format("执行sql:{0}时出错", sql), ex);
                return false;
            }
        }
    }
}
