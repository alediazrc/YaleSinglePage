using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class OAuth
    {
        public string acces_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}