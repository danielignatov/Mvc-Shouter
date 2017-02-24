namespace Shouter.App.Views.User
{
    using Shouter.App.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using SimpleMVC.Utilities;
    using System;

    public class Login : IRenderable<StatusMessageViewModel>
    {
        public StatusMessageViewModel Model { get; set; }

        public string Render()
        {
            string page = FileRead.HtmlDocument("../../Content/login.html");
            page += Model.Message;

            return page;
        }
    }
}