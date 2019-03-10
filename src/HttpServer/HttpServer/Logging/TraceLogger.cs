using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Logging
{
    public class TraceLogger
    {
        public static void ConsoleLog(string message)
        {
            Console.WriteLine(message + "\t" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
        }
    }
}
