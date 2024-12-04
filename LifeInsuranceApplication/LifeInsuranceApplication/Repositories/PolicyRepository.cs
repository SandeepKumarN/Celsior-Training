using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Exceptions;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Repositories
{
    public class PolicyRepository : IRepository<int, Policy>
    {
        private readonly InsuranceContext _context;
        private readonly ILogger<PolicyRepository> _logger;

        public PolicyRepository(InsuranceContext context, ILogger<PolicyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Policy> Add(Policy entity)
        {
            try
            {
                if (entity.PolicyNumber != "")
                {
                    _context.Policies.Add(entity);
                    await _context.SaveChangesAsync();
                    return entity;

                }
                throw new CouldNotAddException("Policy");

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new CouldNotAddException("Policy");
            }


            //try
            //{
            //    _context.Policies.Add(entity);
            //    await _context.SaveChangesAsync();
            //    return entity;
            //}
            //catch (Exception e)
            //{
            //    _logger.LogError(e.Message);
            //    throw new CouldNotAddException("Policy");
            //}
        }

        public async Task<Policy> Delete(int key)
        {
            var policies = await Get(key);
            if (policies != null)
            {
                _context.Policies.Remove(policies);
                await _context.SaveChangesAsync();
                return policies;
            }
            _logger.LogError("policies not found while trying to delete");
            throw new NotFoundException("policies for delete");
        }

        public async Task<Policy> Get(int key)
        {
            var policies = await _context.Policies.FirstOrDefaultAsync(c => c.Id == key);
            return policies;
        }

        public async Task<IEnumerable<Policy>> GetAll()
        {
            var policies = await _context.Policies.ToListAsync();
            if (policies.Count == 0)
            {
                throw new CollectionEmptyException("Policies");
            }
            return policies;
        }

        public async Task<Policy> Update(int key, Policy entity)
        {
            var policy = await Get(key);
            if (policy == null)
            {
                throw new NotFoundException("Policies");
            }
            try
            {
                _context.Policies.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not update Policy details");
                throw new Exception("Unable to modify Policy object");
            }
        }
    }
}
