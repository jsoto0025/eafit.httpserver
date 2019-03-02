using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinHttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlServer = "http://localhost:8085";

            using (WebApp.Start<Startup>(urlServer))
            {
                Console.WriteLine("Inicio");
                Console.ReadKey();
                Console.WriteLine("Fin");

            }
            

        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(ctx => 
            {
                return ctx.Response.WriteAsync("Mi servidor HTTP Owin");
            });
        }
    }
}
