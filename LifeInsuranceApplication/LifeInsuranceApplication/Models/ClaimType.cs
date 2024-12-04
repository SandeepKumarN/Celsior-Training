namespace LifeInsuranceApplication.Models
{
    public class ClaimType
    {
        public string ClaimName { get; set; } = string.Empty;
        public int Id { get; set; }
        public ICollection<Claim> Claims { get; set; }
    }
}
