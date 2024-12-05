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

        public void AddNumber(int Contact_ID, string number)
        {
            Number newNumber = new Number(
                                            number = number,
                                            Contact_ID = Contact_ID);

            businessLogicLayer.CheckNumber(newNumber);
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
