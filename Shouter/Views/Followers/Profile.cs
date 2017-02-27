namespace Shouter.Views.Followers
{
    using SimpleMVC.Interfaces.Generic;
    using System.Text;
    using Tools;
    using ViewModels;

    public class Profile : IRenderable<UserProfileViewModel>
    {
        #region Properties
        public UserProfileViewModel Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string profileHtml = FileRead.HtmlDocument("../../Content/profile.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append($@"  <li class=""list-group-item"">
                <form class=""form-group"" action=""/followers/profile"" method=""POST"">
                        <h2>
                            <strong>{Model.Username}</strong></h2>
                        <input type=""submit"" class=""btn btn-{Model.FollowStatus}"" value=""{Model.FollowOption}""/>                       
                </form>
            </li>
            <h3>Shouts:</p>");

            foreach (var shoutViewModel in Model.Shouts)
            {
                pageBuilder.Append($@"<div class=""thumbnail"">
			                               <h4>
                                            <strong>
                                             <a href=""/followers/profile?id={shoutViewModel.Author.Id}"">{shoutViewModel.Author.Username}</a>
                                            <strong> 
                                            <small>{shoutViewModel.PostedForTime}</small></h4>
			                            <p>{shoutViewModel.Content}</p>
		                            </div>");
            }

            profileHtml = profileHtml.Replace("##profile##", pageBuilder.ToString());

            return profileHtml;
        }
        #endregion
    }
}