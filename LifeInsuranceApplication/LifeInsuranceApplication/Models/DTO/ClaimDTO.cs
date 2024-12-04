using LifeInsuranceApplication.Misc;
using System.ComponentModel.DataAnnotations;

namespace LifeInsuranceApplication.Models.DTO
{
    public class ClaimDTO
    {
        [Required(ErrorMessage = "PolicyId cannot be null.")]
        public int PolicyId { get; set; }

        [Required(ErrorMessage = "ClaimTypeId cannot be null.")]
        public int ClaimTypeId { get; set; }

        [Required(ErrorMessage = "Email cannot be null.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone cannot be null.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "ClaimantSettlementForm cannot be null.")]
        [FileRequired(new[] { "application/pdf", "image/jpeg", "image/png" }, 5 * 1024 * 1024, ErrorMessage = "Invalid file format or size.")]
        public IFormFile ClaimantSettlementForm { get; set; }

        [Required(ErrorMessage = "DeathCertificate cannot be null.")]
        [FileRequired(new[] { "application/pdf", "image/jpeg", "image/png" }, 5 * 1024 * 1024, ErrorMessage = "Invalid file format or size.")]
        public IFormFile DeathCertificate { get; set; }

        [Required(ErrorMessage = "PolicyCertificate cannot be null.")]
        [FileRequired(new[] { "application/pdf", "image/jpeg", "image/png" }, 5 * 1024 * 1024, ErrorMessage = "Invalid file format or size.")]
        public IFormFile PolicyCertificate { get; set; }

        [Required(ErrorMessage = "Photo cannot be null.")]
        [FileRequired(new[] { "image/jpeg", "image/png" }, 5 * 1024 * 1024, ErrorMessage = "Invalid file format or size.")]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "AddressProof cannot be null.")]
        [FileRequired(new[] { "application/pdf", "image/jpeg", "image/png" }, 5 * 1024 * 1024, ErrorMessage = "Invalid file format or size.")]
        public IFormFile AddressProof { get; set; }

        [Required(ErrorMessage = "CancelledCheck cannot be null.")]
        [FileRequired(new[] { "application/pdf", "image/jpeg", "image/png" }, 5 * 1024 * 1024, ErrorMessage = "Invalid file format or size.")]
        public IFormFile CancelledCheck { get; set; }

        [Required(ErrorMessage = "Others cannot be null.")]
        [FileRequired(new[] { "application/pdf", "image/jpeg", "image/png" }, 5 * 1024 * 1024, ErrorMessage = "Invalid file format or size.")]
        public IFormFile Others { get; set; }

        
    }
}
