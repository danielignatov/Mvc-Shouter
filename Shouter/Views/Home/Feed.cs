namespace Shouter.Views.Home
{
    using SimpleMVC.Interfaces.Generic;
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
            string feedHtml = FileRead.HtmlDocument("../../Content/feed.html");
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
            feedHtml = feedHtml.Replace("##feed##", pageBuilder.ToString());
            return feedHtml;
        }
        #endregion
    }
}