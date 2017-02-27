namespace Shouter.ViewModels
{
    using System.Collections.Generic;

    public class UserProfileViewModel
    {
        #region Constructors
        public UserProfileViewModel()
        {
            this.Shouts = new List<ShoutViewModel>();
        }
        #endregion

        #region Properties
        public string Username { get; set; }

        public string FollowStatus { get; set; }

        public string FollowOption { get; set; }

        public List<ShoutViewModel> Shouts { get; set; }
        #endregion
    }
}
