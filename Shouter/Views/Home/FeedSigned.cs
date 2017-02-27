namespace Shouter.Views.Home
{
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tools;
    using ViewModels;

    public class FeedSigned : IRenderable<List<ShoutViewModel>>
    {
        #region Properties
        
        public List<ShoutViewModel> Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string feedSignedInHtml = FileRead.HtmlDocument("../../Content/feed-signed.html");
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

            feedSignedInHtml = feedSignedInHtml.Replace("##username##", "Shouter");
            feedSignedInHtml = feedSignedInHtml.Replace("##feed##", pageBuilder.ToString());

            return feedSignedInHtml;
        }
        #endregion
    }
}