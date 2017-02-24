namespace Shouter.App.Services
{
    using Shouter.App.Data;
    using Shouter.App.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class ShoutService
    {
        #region Methods
        public static List<Shout> ReturnAllShouts()
        {
            using(var context = new ShouterAppContext())
            {
                return context.Shouts.ToList();
            }
        }
        #endregion
    }
}