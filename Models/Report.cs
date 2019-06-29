using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class Report
    {
        public int reportId { get; set; }
        public int? donationHistoryId { get; set; }
        public DonationHistory donationHistory { get; set; }
        public string bloodType { get; set; }
    }
}
