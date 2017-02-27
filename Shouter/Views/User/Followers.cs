namespace Shouter.Views.User
{
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Text;
    using Tools;
    using ViewModels;

    public class Followers : IRenderable<List<UserViewModel>>
    {
        #region Properties
        public List<UserViewModel> Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string followersHtml = FileRead.HtmlDocument("../../Content/following.html");
            StringBuilder pageBuilder = new StringBuilder();
            foreach (var userViewModel in Model)
            {
                pageBuilder.Append(
                    $@"<li><h4><strong><a href=""/followers/profile?id={userViewModel.Id}"">{userViewModel.Username}</a></strong> </h4></li>");
            }
            followersHtml = followersHtml.Replace("##followers##", pageBuilder.ToString());
            return followersHtml;
        }
        #endregion
    }
}