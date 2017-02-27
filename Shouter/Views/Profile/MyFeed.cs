namespace Shouter.Views.Profile
{
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using ViewModels;

    public class MyFeed : IRenderable<List<ShoutViewModel>>
    {
        #region Properties
        public List<ShoutViewModel> Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            //   < div class="thumbnail">
            //	<h4><strong>MyUsername<strong>  <small>3 minutes ago</small></h4>
            //	<p>Shout text goes here</p>
            //	<input type = "button" class="btn btn-danger" value="Delete"/>
            //</div>
            throw new System.NotImplementedException();
        }
        #endregion
    }
}