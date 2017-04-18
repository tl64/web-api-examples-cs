using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebAPISelfHosting
{
    class Program //run visual studio as administrator
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:4554");
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new {id = RouteParameter.Optional});
            var server = new HttpSelfHostServer(config);
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server is opened");
            Console.ReadLine();
        }
    }
}
