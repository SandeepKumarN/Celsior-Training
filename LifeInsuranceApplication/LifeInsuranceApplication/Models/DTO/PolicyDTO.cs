using System.ComponentModel.DataAnnotations;
namespace LifeInsuranceApplication.Models.DTO

{
    public class PolicyDTO
    {
        [Required(ErrorMessage = "policyNumber cannot  be blank")]
        public string PolicyNumber { get; set; } = string.Empty;
    }
}
