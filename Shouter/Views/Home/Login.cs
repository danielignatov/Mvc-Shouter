namespace Shouter.Views.Home
{
    using SimpleMVC.Interfaces;
    using Tools;

    public class Login : IRenderable
    {
        public string Render()
        {
            return FileRead.HtmlDocument("../../Content/login.html");
        }
    }
}