using System.ComponentModel.DataAnnotations;

namespace LifeInsuranceApplication.Models
{

    public enum Status
    {
        Requested,
        Approved,
        Rejected
    }
    public class Claim
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }

        public Policy Policy { get; set; }
        public int ClaimTypeId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty ;
        public string ClaimantSettlementForm { get; set; } = string.Empty;
        public string DeathCertificate { get; set; } = string.Empty;
        public string PolicyCertificate { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public string AddressProof { get; set; } = string.Empty;
        public string CancelledCheck { get; set; } = string.Empty;
        public string Others { get; set; } = string.Empty ;

        public Status Status { get; set; } = Status.Requested;
    }
}
