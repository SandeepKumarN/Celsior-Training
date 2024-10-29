namespace WebAPIOct24.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string DateTime { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
