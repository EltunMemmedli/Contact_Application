using Contact_Application.Data_Access;
using Contact_Application.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Number = Contact_Application.Model.Number;

namespace Contact_Application.Controller
{
    public class NumberController
    {
        BusinessLogicLayer businessLogicLayer;

        public NumberController()
        {
            businessLogicLayer = new BusinessLogicLayer();
        }

        private string connectionString = "Data Source=(local);Database=Contact_Application;Integrated Security=sspi;";

        public void AddNumbers(int Contact_ID)
        {
            while (true)
            {
                Console.WriteLine("Please enter a phone number (type 'STOP' to finish):");
                string number = Console.ReadLine();

                // Check if the user wants to stop adding numbers
                if (number.ToLower() == "stop")
                {
                    Console.WriteLine("Number entry stopped.");
                    break;
                }

                // Validate the number format
                if (number.StartsWith("+994") &&
                    (number.Substring(4, 2) == "50" ||
                     number.Substring(4, 2) == "55" ||
                     number.Substring(4, 2) == "51" ||
                     number.Substring(4, 2) == "77" ||
                     number.Substring(4, 2) == "70"))
                {
                    // Create a new Number object
                    Number newNumber = new Number(number, Contact_ID);

                    // Process and add the number using the business logic layer
                    businessLogicLayer.CheckNumber(newNumber);

                    Console.WriteLine($"Number {number} successfully added for Contact ID {Contact_ID}.");
                }
                else
                {
                    Console.WriteLine("Invalid number. Please ensure it starts with '+994' and follows the correct format.");
                }
            }
        }


        public List<Number> GetNumbers()
        {
            List<Number> NumberList = new List<Number>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Number, Contact_ID FROM Numbers"; // Assuming "Numbers" is your table name


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string phoneNumber = reader["Number"].ToString(); // renamed to avoid conflict with class name
                                int contactId = 0;

                                // Check if the Contact_ID is a valid integer
                                if (int.TryParse(reader["Contact_ID"].ToString(), out contactId))
                                {
                                    var number = new Number(phoneNumber, contactId); // renamed to avoid conflict with the string variable
                                    NumberList.Add(number);
                                }
                                else
                                {
                                    // Handle the case when User_ID is not a valid integer
                                    Console.WriteLine("Contact_ID value is invalid.");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta baş verdi: {ex.Message}");
            }

            return NumberList;
        }
    }
}
