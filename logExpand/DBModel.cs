using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace logExpand
{
    public class DBModel
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public enum DBType
        {
            SqlServer,
            MySql,
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string dbtype { get; set; }

        /// <summary>
        /// 数据库连接字符
        /// </summary>
        public string dbconnect { get; set; }

        /// <summary>
        /// 针对的表名
        /// </summary>
        public string tablename { get; set; }

        /// <summary>
        /// 影响的语句
        /// </summary>
        public string cmdtext { get; set; }

        /// <summary>
        /// 表影响的字段
        /// </summary>
        public List<TableValue> tablevalue { get; set; }

        /// <summary>
        /// 字段，过渡使用
        /// </summary>
        public List<string> value = new List<string>();
    }


    public class TableValue
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string type { get; set; }
    }

   
}
