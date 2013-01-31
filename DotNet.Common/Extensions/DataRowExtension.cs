using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace System.Data
{
    public static class DataRowExtension
    {
        public static String GetStringValue(this DataRow dataRow, String colName)
        {
            if (dataRow.Table.Columns.Contains(colName))
            {
                return dataRow[colName] == DBNull.Value ? "" : dataRow[colName].ToString();
            }
            return "";
        }

        public static String GetStringValue(this DataRow dataRow, int col)
        {
            return dataRow[col] == DBNull.Value ? "" : dataRow[col].ToString();
        }

        public static double GetDoubleValue(this DataRow dataRow, String colName, double defaultValue)
        {
            return dataRow[colName] == DBNull.Value ? defaultValue : double.Parse(dataRow[colName].ToString());
        }

        public static double GetDoubleValue(this DataRow dataRow, int colIndex, double defaultValue)
        {
            return dataRow[colIndex] == DBNull.Value ? defaultValue : double.Parse(dataRow[colIndex].ToString());
        }

        /// <summary>
        /// 把rows里的数据复制到一个新的DataTable里
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static DataTable CopyToDataTable(this DataRow[] rows)
        {
            if (null == rows || rows.Length <= 0)
            {
                return null;
            }
            
            DataTable dt = rows[0].Table.Clone();
            foreach (DataRow row in rows)
            {
                dt.ImportRow(row);
            }

            return dt;
        }
    }
}
