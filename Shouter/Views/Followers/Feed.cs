using SimpleMVC.Interfaces.Generic;

namespace Shouter.Views.Followers
{
    using System.Collections.Generic;
    using System.Text;
    using Tools;
    using ViewModels;

    public class Feed : IRenderable<List<ShoutViewModel>>
    {
        #region Properties
        public List<ShoutViewModel> Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string followersFeedHtml = FileRead.HtmlDocument("../../Content/followersFeed.html");
            StringBuilder pageBuilder = new StringBuilder();

            foreach (var shoutViewModel in this.Model)
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

            followersFeedHtml = followersFeedHtml.Replace("##feed##", pageBuilder.ToString());

            return followersFeedHtml;
        }
        #endregion
    }
}