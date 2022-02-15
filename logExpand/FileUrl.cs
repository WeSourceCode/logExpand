using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace logExpand
{
    public class FileUrl
    {
        /// <summary>
        /// 拼接传入的路径返回完整的路径
        /// </summary>
        public static string PathUrl(string url)
        {
            if (!(HttpContext.Current is null))
            {
                return HttpContext.Current.Server.MapPath(url);

            }
            if (!(AppDomain.CurrentDomain is null))
            {
                return AppDomain.CurrentDomain.BaseDirectory.ToString() + url;
            }
            return "";
        }
    }
}
