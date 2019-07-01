    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class User
    {
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public virtual Donor donor { get; set; }
        public virtual Recepient recepient { get; set; }
    }
}
