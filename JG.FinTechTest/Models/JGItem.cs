using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JustGivingApi.Models
{
    public class JustGivingItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}