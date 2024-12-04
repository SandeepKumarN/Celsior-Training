using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Exceptions;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Repositories
{
    public class ClaimRepository : IRepository<int, Claim>
    {
        private readonly InsuranceContext _context;
        private readonly ILogger<ClaimRepository> _logger;

        public ClaimRepository(InsuranceContext context, ILogger<ClaimRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Claim> Add(Claim entity)
        {
            try
            {
                _context.Claims.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new CouldNotAddException("Claim");
            }
        }

        public async Task<Claim> Delete(int key)
        {
            var claims = await Get(key);
            if (claims != null)
            {
                _context.Claims.Remove(claims);
                await _context.SaveChangesAsync();
                return claims;
            }
            _logger.LogError("Claims not found while trying to delete");
            throw new NotFoundException("Claims for delete");
        }

        public async Task<Claim> Get(int key)
        {
            var claim = await _context.Claims.FirstOrDefaultAsync(c => c.Id == key);
            return claim;
        }

        public async Task<IEnumerable<Claim>> GetAll()
        {
            var claim = await _context.Claims.ToListAsync();
            if (claim.Count == 0)
            {
                throw new CollectionEmptyException("Claims");
            }
            return claim;
        }

        //public async Task<Claim> Update(int key, Claim entity)
        //{
        //    var claim = await Get(key);
        //    if (claim == null)
        //    {
        //        throw new NotFoundException("Claims");
        //    }
        //    try
        //    {
        //        _context.Claims.Update(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, "Could not update Claims details");
        //        throw new Exception("Unable to modify Claims object");
        //    }
        //}

        public async Task<Claim> Update(int key, Claim entity)
        {
            try
            {
                var claims = await Get(key);
                claims.Phone= entity.Phone;
                claims.Email = entity.Email;
                claims.Status = entity.Status;
                await _context.SaveChangesAsync();
                return claims;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
