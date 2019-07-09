using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JustGivingApi.Models
{
    public class JustGivingItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public double DonationAmount { get; set; }

        public double GiftAidAmount { get; set; }
    }
}