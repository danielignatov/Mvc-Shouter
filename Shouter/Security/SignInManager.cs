namespace Shouter.Security
{
    using SimpleHttpServer.Models;
    using System.Linq;
    using Data.Contracts;

    /// <summary>
    /// Determines if the user is logged in.
    /// </summary>
    public class SignInManager
    {
        private IShouterContext context;

        public SignInManager(IShouterContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Checks if there is entry in Logins table that 
        /// contain the SessionId in the current session.
        /// And if that entry is not logged out.
        /// </summary>
        /// <returns>Bool</returns>
        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }

            return this.context.Logins.Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}