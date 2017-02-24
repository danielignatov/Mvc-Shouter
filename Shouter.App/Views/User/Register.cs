namespace Shouter.App.Views.User
{
    using System;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using SimpleMVC.Utilities;
    using ViewModels;
    using System.IO;

    public class Register : IRenderable<StatusMessageViewModel>
    {
        public StatusMessageViewModel Model { get; set; }

        public string Render()
        {
            string page = FileRead.HtmlDocument("../../Content/register.html");
            page += Model.Message;

            return page;
        }
    }
}