namespace Shouter.Views.User
{
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Text;
    using Tools;
    using ViewModels;

    public class Notifications : IRenderable<List<NotificationViewModel>>
    {
        #region Properties
        public List<NotificationViewModel> Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string notificationsHtml = FileRead.HtmlDocument("../../Content/notifications.html");
            StringBuilder pageBuilder = new StringBuilder();

            foreach (var notificationViewModel in Model)
            {
                pageBuilder.Append(
                    $@"<li><h4><strong><a href=""/followers/profile?id={notificationViewModel.UserId}"">{notificationViewModel
                        .Username}</a></strong> posted a shout</h4></li>");
            }

            notificationsHtml = notificationsHtml.Replace("##notifications##", pageBuilder.ToString());

            return notificationsHtml;
        }
        #endregion
    }
}