using Shouter.App.Data;
using Shouter.App.Models;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouter.App.Security
{
    public static class SignInManager
    {
        #region Methods
        public static bool IsAuthenticated(HttpSession session)
        {
            using(var context = new ShouterAppContext())
            {
                if (context.Logins.Where(s => s.SessionId == session.Id).Select(a => a.IsActive).FirstOrDefault() == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static void LogIn(string username, HttpSession session)
        {
            using (var context = new ShouterAppContext())
            {
                Login login = new Login()
                {
                    SessionId = session.Id,
                    IsActive = true,
                    User = context.Users.Where(u => u.Username == username).FirstOrDefault()
                };

                context.Logins.Add(login);
                context.SaveChanges();
            }
        }

        public static void LogOut(HttpSession session)
        {
            using (var context = new ShouterAppContext())
            {
                Login login = context.Logins.Where(s => s.SessionId == session.Id).FirstOrDefault();

                context.Logins.Remove(login);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
