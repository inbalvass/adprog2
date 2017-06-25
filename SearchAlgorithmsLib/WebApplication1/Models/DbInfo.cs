using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class DbInfo
    {
        [Key, Column(Order = 0)]
        [Required]
        public string Username { get; set; }
        [Key, Column(Order = 1)]
        [Required]
        public int Password { get; set; }
        public string Email { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }

}