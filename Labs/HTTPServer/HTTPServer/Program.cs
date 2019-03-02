namespace HTTPServer
{
    class Program
    {
        /// <summary>
        /// Aplicación del Servidor HTTP
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WebServer server = new WebServer(5000,"web");
            server.Start();
            server.Listen();
        }
    }
}

