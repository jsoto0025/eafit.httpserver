using HttpServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLaucher
{
    /// <summary>
    /// Aplicación del HTTP Server
    /// </summary>
    class Program
    {

        /// <summary>
        /// Inicia la ejecución del servidor HTTP.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            var server = new Server();

            server.Start();
        }
    }
}
