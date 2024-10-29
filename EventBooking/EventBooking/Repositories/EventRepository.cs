using EventBooking.Interfaces;
using EventBooking.Models;
using EventBooking.Properties.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Repositories
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Event> Add(Event entity)
        {

            try
            {
                _context.Events.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> Delete(int key)
        {
            try
            {
                var Event = await Get(key);
                if (Event != null)
                {
                    _context.Events.Remove(Event);
                    await _context.SaveChangesAsync();
                    return Event;
                }
                throw new Exception("Delete error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> Get(int key)
        {
            try
            {
                var Event = await _context.Events.FirstOrDefaultAsync(c => c.Id == key);
                return Event;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            try
            {
                var Event = await _context.Events.ToListAsync();
                if (Event.Count == 0)
                {
                    throw new Exception("There is no user");
                }
                return Event;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> Update(int key, Event entity)
        {
            try
            {
                var Event = await Get(key);
                if (Event != null)
                {
                    Employee.Title = entity.Title;
                    Employee.DateTime = entity.DateTime;

                    await _context.SaveChangesAsync();
                    return Event;
                }
                //throw new NotFoundException("Customer for delete");
                throw new Exception("message");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
