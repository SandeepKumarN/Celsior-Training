using AutoMapper;
using LifeInsuranceApplication.Exceptions;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;

namespace LifeInsuranceApplication.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IRepository<int, Claim> _claimRepository;
        private readonly string _uploadFolder;

        public ClaimService(IRepository<int, Claim> claimRepository, string uploadFolder)
        {
            _claimRepository = claimRepository;
            _uploadFolder = uploadFolder;
            Directory.CreateDirectory(_uploadFolder);
        }



        public async Task<IEnumerable<Claim>> GetAllClaims()
        {
            try
            {
                var myClaim = await _claimRepository.GetAll();
                return myClaim;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<int> CreateNewClaims(ClaimDTO claim)
        {
            try
            {
                Claim myClaim = await MappingClaim(claim);
                myClaim = await _claimRepository.Add(myClaim);
                return myClaim.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create claim: {ex.Message}");
            }
        }

        public async Task<Claim> MappingClaim(ClaimDTO claimDTO)
        {
            Claim myClaim = new Claim
            {
                PolicyId = claimDTO.PolicyId,
                ClaimTypeId = claimDTO.ClaimTypeId,
                Email = claimDTO.Email,
                Phone = claimDTO.Phone,
                ClaimantSettlementForm = await UploadFileAsync(claimDTO.ClaimantSettlementForm),
                DeathCertificate = await UploadFileAsync(claimDTO.DeathCertificate),
                PolicyCertificate = await UploadFileAsync(claimDTO.PolicyCertificate),
                Photo = await UploadFileAsync(claimDTO.Photo),
                AddressProof = await UploadFileAsync(claimDTO.AddressProof),
                CancelledCheck = await UploadFileAsync(claimDTO.CancelledCheck),
                Others = await UploadFileAsync(claimDTO.Others)

            };
            return myClaim;
        }

        private async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return string.Empty;
            }

            //var validFileTypes = new[] { "image/jpeg", "image/png", "application/pdf" };
            //if (!validFileTypes.Contains(file.ContentType))
            //{
            //    throw new InvalidOperationException("Invalid file type.");
            //}

            var filePath = Path.Combine(_uploadFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        public async Task<Claim> UpdateStatus(UpdateStatusDTO updateStatusDTO)
        {
            Claim claim = await _claimRepository.Get(updateStatusDTO.ClaimId);
            if (claim == null)
            {
                throw new NotFoundException("Claim not found for updating status.");
            }
            claim.Status = updateStatusDTO.status;
            Claim updateClaim = await _claimRepository.Update(updateStatusDTO.ClaimId, claim);
            return updateClaim;

            //return await _claimRepository.Update(claim.Id, claim);

        }
    }
    
}