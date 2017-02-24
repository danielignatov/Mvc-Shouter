namespace Shouter.App
{
    using SimpleMVC;
    using SimpleHttpServer;

    class AppStart
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "Shouter.App");
        }
    }
}