using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace HTTPServer
{
    /// <summary>
    /// Clase ppal del server
    /// </summary>
    class WebServer
    {
        private TcpListener listener;
        private int port;
        private string home;
        private static string NOTFOUND404 = "HTTP/1.1 404 Not Found";
        private static string OK200 = "HTTP/1.1 200 OK\r\n\r\n\r\n";
        private static int MAX_SIZE = 1000;
        //Constructor que recibe los valores del puerto y path
        public WebServer(int port, string path)
        {
            this.port = port;
            this.home = path;
            //Instancia el objeto listener que escucha las peticiones
            listener = new TcpListener(IPAddress.Any, port);
        }
        //Inicializa el servidor
        public void Start()
        {
            listener.Start();
            Console.WriteLine(string.Format("Local server started at localhost:{0}", port));

            Console.CancelKeyPress += delegate
            {
                Console.WriteLine("Stopping server");
                StopServer();
            };
        }
        //Inicia la escucha
        public void Listen()
        {
            try
            {
                while (true)
                {
                    //Crea el array de Bytes 
                    Byte[] result = new Byte[MAX_SIZE];
                    //Cadena de texto con los datos de la petición
                    string requestData;
                    //Se crea el objeto client que acepta la solicitud de conexion del listener
                    TcpClient client = listener.AcceptTcpClient();
                    //Se obtienen los datos que vienen en la solicitud de conexion
                    NetworkStream stream = client.GetStream();
                    //Obtiene el tamaño del stream para luego ser deserializado a texto
                    int size = stream.Read(result, 0, result.Length);
                    //deserializa los datos contenidos  
                    requestData = System.Text.Encoding.ASCII.GetString(result, 0, size);
                    //muestra en pantalla
                    Console.WriteLine("Received: {0}", requestData);
                    //creaun objeto peticion con los datos recibidos y deserializados
                    Request request = GetRequest(requestData);
                    //Procesa la peticion
                    ProcessRequest(request, stream);
                    client.Close();
                }
            }
            finally
            {
                listener.Stop();
            }
        }

        private void ProcessRequest(Request request, NetworkStream stream)
        {
            if (request == null)
            {
                return;
            }
            if (request.Path.Equals("/"))
                request.Path = "/home.html";
            ParsePath(request);
            if (File.Exists(request.Path))
            {
                var fileContent = File.ReadAllText(request.Path);
                GenerateResponse(fileContent, stream, OK200);
                return;
            }

            GenerateResponse("Not found", stream, NOTFOUND404);
        }

        private void ParsePath(Request request)
        {
            request.Path.Replace('/', '\\');
            request.Path = home + request.Path;
        }

        private void GenerateResponse(string content, 
            NetworkStream stream,
            string responseHeader)
        {
            string response = "HTTP/1.1 200 OK\r\n\r\n\r\n";
            response = response + content;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(msg, 0, msg.Length);
            return;
        }

        private void StopServer()
        {
            listener.Stop();
        }

        private Request GetRequest(string data)
        {
            Request request = new Request();
            var list = data.Split(' ');
            if (list.Length < 3)
                return null;

            request.Command = list[0];
            request.Path = list[1];
            request.Protocol = list[2].Split('\n')[0];

            Console.WriteLine("Instruction: {0}\nPath: {1}\nProtocol: {2}",
                request.Command,
                request.Path,
                request.Protocol);
            return request;
        }

   
    }

    public class Request
    {
        public string Command;
        public string Path;
        public string Protocol;
    }

}
