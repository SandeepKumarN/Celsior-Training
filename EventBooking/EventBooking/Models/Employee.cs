namespace EventBooking.Models
{
    public class Employee
    {
        public static string Title { get; internal set; }
        public static string DateTime { get; internal set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
