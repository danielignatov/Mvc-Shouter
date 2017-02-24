namespace Shouter.App.Views.Home
{
    using SimpleMVC.Interfaces.Generic;
    using SimpleMVC.Utilities;
    using ViewModel;

    public class Feed : IRenderable<ShowShoutsViewModel>
    {
        #region Properties
        public ShowShoutsViewModel Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string page = FileRead.HtmlDocument("../../Content/feed.html");

            return page;
        }
        #endregion
    }
}