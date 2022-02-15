using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace logExpand
{
    public class AppData
    {
        private static List<DBModel> dbdata =new List<DBModel> ();

        public static List<DBModel> DBdata {
           get { return dbdata; }
            set { dbdata = value; }
        }

    }
}

