namespace Shouter.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        #region Constructors
        public User()
        {
            this.Shouts = new HashSet<Shout>();
            this.Follow = new HashSet<User>();
            this.Followers = new HashSet<User>();
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Shout> Shouts { get; set; }

        public virtual ICollection<User> Follow { get; set; }

        public virtual ICollection<User> Followers { get; set; }
        #endregion
    }
}