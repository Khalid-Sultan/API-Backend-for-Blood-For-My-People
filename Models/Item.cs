using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string user_login { get; set; }
        public string user_url { get; set; }
        public string description { get; set; }
        public int stargazers_count { get; set; }

    }
}
