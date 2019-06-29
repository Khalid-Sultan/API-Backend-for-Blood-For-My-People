using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class Recepient
    {
        public int recepientId { get; set; }

        public int? userId { get; set; }
        public User user { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string phoneNumber { get; set; }

        public virtual ICollection<DonationHistory> DonationHistories { get; set; }
    }
}
