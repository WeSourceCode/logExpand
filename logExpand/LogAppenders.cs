using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using static logExpand.DBModel;

namespace logExpand
{
    public class LogAppenders
    {
        public static void GetAppenders()
        {
            var repository = LogManager.GetRepository();
            var appenders = repository.GetAppenders();


            AppData.DBdata.Clear();

            foreach (var appender in appenders)
            {
                string Name= appender.Name.ToString();
                string type = appender.GetType().FullName;
                switch (type)
                {
                    case "log4net.Appender.AdoNetAppender":
                      var ado=  (log4net.Appender.AdoNetAppender)appender;
                        DBModel model = new DBModel
                        {
                            dbconnect = ado.ConnectionString,
                            dbtype = ado.ConnectionType,
                            cmdtext = ado.CommandText,
                        };
                        string comText=ado.CommandText;
                        string RegexStr = @"\[\S*\]";   // ""匹配"

                        foreach(string item in Regex.Matches(comText, RegexStr)[0].Value.Split(','))
                        {
                            model.value.Add(item.Trim().Trim('[').Trim(']'));
                        }

                        string tableStr = @" \S*\(";
                        model.tablename = Regex.Match(comText,tableStr).Value.ToString().Replace("(", "").Trim();

                        AppData.DBdata.Add(model) ;
                            break;
                    case "log4net.Appender.RollingFileAppender":
                        var file = (log4net.Appender.RollingFileAppender)appender;
                        break;
                }
            }

            AppendersDba(AppData.DBdata);
        }

        private static void AppendersDba(List<DBModel> list)
        {
            Console.WriteLine("开始执行配置文件与数据库对比");
            foreach(DBModel item in  list)
            {
                LogDal logDal = new LogDal(item.dbconnect);
                logDal.exist(item.tablename,item.value);
            }
        }
    }
}
