namespace WebAPIOct24.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int EventId { get; set; }

        public Employee Employee { get; set; }
        public Event Event { get; set; }
    }
}
