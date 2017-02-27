namespace Shouter
{
    using SimpleMVC;
    using SimpleHttpServer;

    class AppStart
    {
        /// <summary>
        /// Starting point of the application
        /// </summary>
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RoutesTable.Routes);
            MvcEngine.Run(server, "Shouter");
        }
    }
}