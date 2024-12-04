using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Exceptions;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Repositories
{
    public class ClaimTypeRepository : IRepository<int, ClaimType>
    {
        private readonly InsuranceContext _context;
        private readonly ILogger<ClaimTypeRepository> _logger;

        public ClaimTypeRepository(InsuranceContext context, ILogger<ClaimTypeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ClaimType> Add(ClaimType entity)
        {



            try
            {
                _context.ClaimTypes.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new CouldNotAddException("ClaimType");
            }
        }

        public async Task<ClaimType> Delete(int key)
        {
            var claimTypes = await Get(key);
            if (claimTypes != null)
            {
                _context.ClaimTypes.Remove(claimTypes);
                await _context.SaveChangesAsync();
                return claimTypes;
            }
            _logger.LogError("ClaimType not found while trying to delete");
            throw new NotFoundException("claimTypes for delete");
        }

        public async Task<ClaimType> Get(int key)
        {
            var claimType = await _context.ClaimTypes.FirstOrDefaultAsync(c => c.Id == key);
            return claimType;
        }

        public async Task<IEnumerable<ClaimType>> GetAll()
        {
            var claimType = await _context.ClaimTypes.ToListAsync();
            if (claimType.Count == 0)
            {
                throw new CollectionEmptyException("ClaimTypes");
            }
            return claimType;
        }

        public async Task<ClaimType> Update(int key, ClaimType entity)
        {
            var claimType = await Get(key);
            if (claimType == null)
            {
                throw new NotFoundException("ClaimTypes");
            }
            try
            {
                _context.ClaimTypes.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not update ClaimType details");
                throw new Exception("Unable to modify ClaimType object");
            }
        }
    }
}
