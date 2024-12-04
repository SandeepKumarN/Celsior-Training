using System.ComponentModel.DataAnnotations;

namespace LifeInsuranceApplication.Models
{
        public class Policy
        {
            [Key]
            public int Id { get; set; }

            public string PolicyNumber { get; set; } = string.Empty;
            public ICollection<Claim> Claims { get; set; } = new List<Claim>();
        }
    
}
