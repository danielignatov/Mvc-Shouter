namespace Shouter.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Shout
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }
    }
}