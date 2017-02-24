namespace Shouter.App.ViewModel
{
    using Shouter.App.Models;
    using System;
    using System.Collections.Generic;

    public class ShowShoutsViewModel
    {
        #region Constructor
        public ShowShoutsViewModel()
        {
            this.Shouts = new List<Shout>();
        }
        #endregion

        #region Properties
        public List<Shout> Shouts { get; set; }
        #endregion
    }
}