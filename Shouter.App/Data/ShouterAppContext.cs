namespace Shouter.App.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShouterAppContext : DbContext
    {
        public ShouterAppContext()
            : base("name=ShouterAppContext")
        {
        }

        public virtual DbSet<Shout> Shouts { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Login> Logins { get; set; }
    }
}