namespace EventBooking.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DateTime { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
