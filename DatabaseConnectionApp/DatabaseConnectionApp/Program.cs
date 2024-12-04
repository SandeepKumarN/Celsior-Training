using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

// See https://aka.ms/new-console-template for more information
namespace DatabaseConnectioApp
{
    internal class Program
    {
        SqlConnection conn = new SqlConnection("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=True");

        public Program()
        {
           // conn.Open();
           // Console.WriteLine("Connection Successfully");
        }

        void GetProductDetailsFromDatabase()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Products";
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine($"Name: \t{reader["ProductName"]}");
                    Console.WriteLine($"Price: \t${reader["UnitPrice"]}");
                    Console.WriteLine("------------------------------------");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        void CreateUser()
        {
            String username, password;
            Console.WriteLine("Enter username  ");
            username = Console.ReadLine();
            Console.WriteLine("Enter password  ");
            password = Console.ReadLine();

            String insertQuery = $"Insert Into Users Values ('{username}', '{password}')";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("User Created Sucessfully ");
                }
                else
                {
                    Console.WriteLine("User Creation Failed ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        bool CheckUser(string username, string password)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM Users WHERE username=@un AND password=@pass", conn);
            try
            {
                sqlCommand.Parameters.AddWithValue("@un", username);
                sqlCommand.Parameters.AddWithValue("@pass", password);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }

            finally
            {
                conn.Close();
            }
        }

        
        void UpdatePassword()
        {
            String username, password, newPassword;
            Console.WriteLine("Enter username  ");
            username = Console.ReadLine();
            Console.WriteLine("Enter password  ");
            password = Console.ReadLine();


            try
            {
                if (CheckUser(username, password))
                {
                    Console.WriteLine("Please entrer your password  ");
                    newPassword = Console.ReadLine();
                    SqlCommand sqlCommand = new SqlCommand("Update SET Users password=@pass WHERE username=@un", conn);
                    sqlCommand.Parameters.AddWithValue("@un", username);
                    sqlCommand.Parameters.AddWithValue("@pass", password);
                    try
                    {
                        conn.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("User Created Sucessfully ");
                        }
                        else
                        {
                            Console.WriteLine("User Creation Failed ");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Could not verify. Sorry cannot update password now");
                }
                }
                catch(Exception e)
                    {
                    Console.WriteLine(e.Message);
                }

            finally
            {
                conn.Close();
            }
        }

        void UnderstandingDisconnectedArchitecture()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("SELECT * FROM Products", conn);
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
                Console.WriteLine($"The Current Connection State is {conn.State}");
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine($"Name: {row["ProductName"]}");
                    Console.WriteLine($"Price: {row["UnitPrice"]}");
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void GetCategories()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Categories";
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: \t{reader["CategoryID"]}");
                    Console.WriteLine($"NAME: \t{reader["CategoryName"]}");
                    Console.WriteLine("------------------------------------");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        void DeleteUserName()
        {
            string username;
            Console.WriteLine("Delete the users ");
            Console.Write("Enter user name :- ");
            username = Console.ReadLine();
            SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Users Where username=@user", conn);
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@user", username);
                //SqlDataReader reader = sqlCommand.ExecuteReader();
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("Deleted successfully");
                }
                else
                {
                    Console.WriteLine("failed");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                conn.Close();
            }

        }

        static void Main(String[] args)
        {
            Program program = new Program();
            //program.GetProductDetailsFromDatabase();
            //program.CreateUser();
            //program.UpdatePassword();
            //program.UnderstandingDisconnectedArchitecture();
            //program.GetCategories();
            program.DeleteUserName();
        }
    }
}
