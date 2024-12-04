using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;


namespace Northwindproject
{
    internal class Service : IService
    {
       //SqlConnection conn= new SqlConnection();
        public bool Login()
        {
            //string username, password;
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            string query = $"SELECT * FROM Users WHERE username = @username AND passwords = @password";

            try
            {
                SqlConnection conn = new SqlConnection("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=true");
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine("Login Sucessfully");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password");
                        return false;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                return false;
            }
        }

        public void Register()
        {
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            string query = $"INSERT INTO Users (username, passwords) Values(@username, @passwords)";

            try
            {
                SqlConnection conn = new SqlConnection("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=true");
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwords", password);
                    conn.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Console.WriteLine("Registration Sucessful");
                    }
                    else
                    {
                        Console.WriteLine("Registration failed");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }

        public void updatePassword()
        {
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your newpassword: ");
            string newpassword = Console.ReadLine();


            string query = $"UPDATE Users SET passwords = @NewPassword WHERE Username = @Username";

            try
            {
                SqlConnection conn = new SqlConnection("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=true");
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NewPassword", newpassword);
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Console.WriteLine("Password update sucessful");
                    }
                    else
                    {
                        Console.WriteLine("Password update failed");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }

        public void ViewOrderSummary()
        {
            Console.WriteLine("Enter order number: ");
            string orderNumber = Console.ReadLine();
           

            string query = @"SELECT o.OrderID, o.CustomerID
                            FROM Orders o
                            WHERE o.OrderID = @OrderNumber";

            try
            {
                SqlConnection conn = new SqlConnection("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=true");
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine($"Order summary for order number: {orderNumber}");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Customer Name: {reader["CustomerID"]} OrderID: {reader["OrderID"]}");
                        }
                    }

                    else
                    {
                        Console.WriteLine("No order found with the given order number");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }

        public void ViewPreviousOrder(string customerId)
        {
            string query = @"SELECT OrderID, OrderDate
                           FROM Orders
                           WHERE CustomerID = @CustomerId";

            try
            {
                SqlConnection conn = new SqlConnection("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=true");
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine($"Previous Orders for Customer ID: {customerId}");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Order Number: {reader["OrderID"]}, Order Date: {reader["OrderDate"]}");
                        }
                    }

                    else
                    {
                        Console.WriteLine("No order found with the given customer Id");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }

        }

        public void ViewShippersDetail()
        {
            Console.WriteLine("Enter order number: ");
            string orderNumber = Console.ReadLine();

            string query = @"SELECT o.OrderID, s.ShipperID, s.Phone
FROM Shippers s
JOIN Orders o ON s.ShipperID = o.ShipVia
WHERE o.OrderID = @OrderNumber";
            try
            {
                SqlConnection conn = new SqlConnection("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=true");
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine($"Shipper Details for Order Number: {orderNumber}");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Shipper ID: {reader["ShipperID"]} Phone: {reader["Phone"]}");
                        }
                    }

                    else
                    {
                        Console.WriteLine("No shipper details found for the given order number.");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}

