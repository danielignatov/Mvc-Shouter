namespace Shouter.Views.Followers
{
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Text;
    using Tools;
    using ViewModels;

    public class All : IRenderable<List<FollowerViewModel>>
    {
        #region Properties
        public List<FollowerViewModel> Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string followersHtml =  FileRead.HtmlDocument("../../Content/followers.html");
            StringBuilder pageBuilder = new StringBuilder();

            foreach (var followerViewModel in this.Model)
            {
                string template = $@"<li class=""list-group-item"">
                <form class=""form-group"" action=""/followers/all"" method=""POST"">
                        <h4>
                        <input type=""hidden"" name=""Id"" value=""{followerViewModel.Id}""</input>
                            <strong><a class=""col-md-8""href=""/followers/profile?id={followerViewModel.Id}"">{followerViewModel.Username}</a></strong>
                        <input type=""submit"" class=""btn btn-{followerViewModel.FollowStatus}"" value=""{followerViewModel.FollowOption}""/>
                        </h4>
                </form>
            </li>";
                pageBuilder.Append(template);
            }

            followersHtml = followersHtml.Replace("##following##", pageBuilder.ToString());

            return followersHtml;
        }
        #endregion
    }
}