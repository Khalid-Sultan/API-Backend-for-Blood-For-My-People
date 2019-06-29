using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class DonationHistory
    {
        public int donationHistoryId { get; set; }
        public int? donorId { get; set; }
        public Donor donor { get; set; }

        public int? recepientId { get; set; }
        public Recepient recepient { get; set; }
        public double amount { get; set; }
        public string date { get; set; }


    }
}
