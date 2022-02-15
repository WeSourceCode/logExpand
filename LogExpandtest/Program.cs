
using log4net;
using logExpand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogExpandtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogAppenders.GetAppenders();

            //LogMethod log = Log.GetLogger("default");
            //log.Error("我草");

            "输出错误到数据库".LogError();

            LogMethod.error("我草");
            LogMethod.Info("我草");
            Console.WriteLine(logExpand.AppData.DBdata.Count);
        }

        
    }
}
