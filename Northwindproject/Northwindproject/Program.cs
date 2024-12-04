using static System.Reflection.Metadata.BlobBuilder;

namespace Northwindproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();

            bool isRunning = true;
            bool isLoggedIn = false;
            string customerId = "";

            while (isRunning)
            {
                if (!isLoggedIn)
                {
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Exit");

                    Console.Write("Choose an option: ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            isLoggedIn = service.Login();
                            if (isLoggedIn)
                            {
                                Console.WriteLine("Enter your Customer ID: ");
                                customerId = Console.ReadLine();
                            }
                            break;

                        case "2":
                            service.Register();
                            break;

                        case "3":
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("1. View Previous Orders");
                    Console.WriteLine("2. View Order Summary");
                    Console.WriteLine("3. View Shipper Details");
                    Console.WriteLine("4. Update Password");
                    Console.WriteLine("5. Logout");
                    Console.WriteLine("6. Exit");

                    Console.Write("Choose an option: ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            service.ViewPreviousOrder(customerId);
                            break;

                        case "2":
                            service.ViewOrderSummary();
                            break;

                        case "3":
                            service.ViewShippersDetail();
                            break;

                        case "4":
                            service.updatePassword();
                            break;

                        case "5":
                            isLoggedIn = false;
                            customerId = "";
                            Console.WriteLine("Logged out successfully.");
                            break;

                        case "6":
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }

            Console.WriteLine("Application exited.");
        }
    }
}
