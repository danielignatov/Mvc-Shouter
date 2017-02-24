namespace Shouter.App.Services
{
    using Data;
    using Models;
    using System;
    using System.Linq;

    public static class UserService
    {
        #region Methods
        public static bool ValidUsername(string username)
        {
            using (var context = new ShouterAppContext())
            {
                // If there is record of that username return false
                if (context.Users.Where(u => u.Username == username).Count() > 0)
                {
                    return false;
                }
            }

            // Else return true
            return true;
        }

        public static bool ValidEmail(string email)
        {
            using (var context = new ShouterAppContext())
            {
                // If there is record of that email return false
                if (context.Users.Where(u => u.Email == email).Count() > 0)
                {
                    return false;
                }
            }

            // Else return true
            return true;
        }

        public static bool ValidBirthDate(DateTime birthDate)
        {
            DateTime startDate = birthDate;
            DateTime endDate = DateTime.Now;

            int years = endDate.Year - startDate.Year;

            if (startDate.Month == endDate.Month &&// if the start month and the end month are the same
                endDate.Day < startDate.Day)// BUT the end day is less than the start day
            {
                years--;
            }
            else if (endDate.Month < startDate.Month)// if the end month is less than the start month
            {
                years--;
            }

            if (years >= 13)
            {
                return true;
            }
            
            return false;
        }

        public static void RegisterUserToDatabase(User user)
        {
            using (var context = new ShouterAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static bool ValidPassword(string username, string password)
        {
            using (var context = new ShouterAppContext())
            {
                var truePassword = context.Users.Where(u => u.Username == username).Select(p => p.Password).FirstOrDefault();

                if (truePassword == password)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}