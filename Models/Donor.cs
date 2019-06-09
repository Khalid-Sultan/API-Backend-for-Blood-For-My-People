using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class Donor
    {
        public int id { get; set; }
        public int? userId { get; set; }
        public User user { get; set; }
        public string fullName { get; set; }
        public string dateOfBirth { get; set; }
        public string phoneNumber { get; set; }

        public ICollection<DonationHistory> DonationHistories { get; set; }
    }
}
