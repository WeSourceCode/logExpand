using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace logExpand
{
    public class LogDal
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string Connect;

        /// <summary>
        /// 默认构造实现
        /// </summary>
        /// <param name="Connect">数据库连接字符串</param>
        public LogDal(string connect)
        {
            Connect = connect;
        }

        /// <summary>
        /// 检测在数据库中是否存在此表或者字段
        /// </summary>
        /// <param name="table"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool exist(string table, List<string> value = null)
        {
            if (string.IsNullOrEmpty(table))
            {
                return false;
            }

            if (!GetTable(table))
            {
                CreateTable(table);
            }


            if(!(value is null))
            {
                foreach(string item in value)
                {
                    if (!GetTableValue(table,item))
                    {
                        CreateTableValue(table,item);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 查询数据表是否存在
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool GetTable(string table)
        {
            string sql = string.Format($" select * from syscolumns where id = object_id('"+table+"') ");
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@table", table) };
            return SqlHelper.GetDataTable(Connect, sql, "table",sp).Rows.Count>0;
        }

        /// <summary>
        /// 查询数据表中的字段是否存在
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool GetTableValue(string table,string value)
        {
            string sql = string.Format($" select * from syscolumns where id = object_id('"+table+"') and name='"+value+"' ");
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@table", table), new SqlParameter("@value", value) };
            return SqlHelper.GetDataTable(Connect, sql, "table", sp).Rows.Count > 0;
        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool CreateTable(string table)
        {
            string sql = " CREATE TABLE  "+table+" ([Id][INT] IDENTITY(1, 1) NOT NULL) ";
            //List<SqlParameter> sqlParameters = new List<SqlParameter>();
            //sqlParameters.Add(new SqlParameter("@table", table));
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@table", SqlDbType.NVarChar);
            sqlParameters[0].Value = table;
            return   SqlHelper.ExecuteNonQuery(Connect, System.Data.CommandType.Text, sql, sqlParameters)>0;
        }


        /// <summary>
        /// 在数据表中新增字段
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool CreateTableValue(string table,string value)
        {
            string sql = @"alter table "+table+" add "+value+" NVARCHAR(500)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@table", table));
            sqlParameters.Add(new SqlParameter("@value", value));
            return SqlHelper.ExecuteNonQuery(Connect, System.Data.CommandType.Text, sql, sqlParameters.ToArray()) > 0;
        }
    }
}
