using Contact_Application.Data_Access;
using Contact_Application.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contact_Application.Controller
{
    public class UserController
    {
        BusinessLogicLayer BusinessLogicLayer;

        private string connectionString = "Data Source=(local);Database=Contact_Application;Integrated Security=sspi;";

        public UserController()
        {
            BusinessLogicLayer = new BusinessLogicLayer();
        }

        public void AddUserToDB()
        {
            name:
            Console.WriteLine("Please, enter your Name");
            string name = Console.ReadLine();
            if (!(string.IsNullOrEmpty(name)))
            {
                Console.Clear();
                surname:
                Console.WriteLine("Please, enter your Surname");
                string surname = Console.ReadLine();
                if (!(string.IsNullOrEmpty(surname)))
                {
                    Console.Clear();
                    Phone_Number:
                    Console.WriteLine("Please, enter your Phone number");
                    string Phone_Number = Console.ReadLine();
                    if (Phone_Number.Length == 13 && Phone_Number.StartsWith("+994") && (Phone_Number.Substring(4, 2) == "50" ||
                                                     Phone_Number.Substring(4, 2) == "55" ||
                                                     Phone_Number.Substring(4, 2) == "51" ||
                                                     Phone_Number.Substring(4, 2) == "77" ||
                                                     Phone_Number.Substring(4, 2) == "70"))
                    {
                        User user = new User(name, surname, Phone_Number);

                        BusinessLogicLayer.CheckUser(user);
                    }
                }

            }
            
        }

        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();

            string Querry = "SELECT Name, Surname, Phone_Number FROM Users;";

            try 
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new User(reader["Name"].ToString(), reader["Surname"].ToString(), reader["Phone_Number"].ToString());

                                userList.Add(user);
                            }
                        }
                    }
                }
            }
            catch(Exception exp) 
            {
                Console.WriteLine(exp.Message);
            }

            return userList;
        }

        public void DisplayUsers()
        {
            List<User> users = GetUsers();

            Console.WriteLine("Users in the ArrayList:");
            foreach (User user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
