using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackTrace.CreateLog
{
    public class CreateLog
    {
        #region Logging
        public static void Log(string type, string msg)
        {
            var dir = HttpContext.Current.Server.MapPath("~/logs");
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            System.IO.StreamWriter wrtr = null;
            {
                try
                {
                    wrtr = new System.IO.StreamWriter(dir + "/" + type + "-logs" + DateTime.Now.ToString("yyyyMMdd") + ".log", true);
                    wrtr.WriteLine(DateTime.Now.ToString() + "\t" + "\t" + msg);
                }
                finally
                {
                    if (wrtr != null)
                    {
                        wrtr.Close();
                        //wrtr.Dispose();
                    }
                }
            }
        }

        #endregion
    }
}