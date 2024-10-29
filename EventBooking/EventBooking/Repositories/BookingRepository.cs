using EventBooking.Interfaces;
using EventBooking.Models;
using EventBooking.Properties.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Repositories
{
    public class BookingRepository : IRepository<int, Booking>
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> Add(Booking entity)
        {
            try
            {
                _context.Bookings.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Booking> Delete(int key)
        {
            try
            {
                var Booking = await Get(key);
                if (Booking != null)
                {
                    _context.Bookings.Remove(Booking);
                    await _context.SaveChangesAsync();
                    return Booking;
                }
                throw new Exception("Delete error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Booking> Get(int key)
        {
            try
            {
                var Booking = await _context.Bookings.FirstOrDefaultAsync(c => c.Id == key);
                return Booking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            try
            {
                var Booking = await _context.Bookings.ToListAsync();
                if (Booking.Count == 0)
                {
                    throw new Exception("There is no user");
                }
                return Booking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Booking> Update(int key, Booking entity)
        {
            var Booking = await Get(key);
            if (Booking != null)
            {
                return Booking;
            }
            //throw new NotFoundException("Customer for delete");
            throw new Exception("message");
        }
    }
}
