using Contact_Application.Data_Access;
using Contact_Application.Model;
using Contact_Application.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Contact_Application.Controller
{
    public class ContactController
    {
        BusinessLogicLayer BusinessLogicLayer;

        private string connectionString = "Data Source=(local);Database=Contact_Application;Integrated Security=sspi;";

        public ContactController()
        {
            BusinessLogicLayer = new BusinessLogicLayer();
        }

        public void AddContactDB(string name, string Surname, int userId)
        {


            Contact newContact = new Contact(
                                                name = name,
                                                Surname = Surname,
                                                userId = userId

                                                );


            BusinessLogicLayer.CheckContact(newContact);
        }

        public List<Contact> GetContacts()
        {
            List<Contact> userList = new List<Contact>();
            string Querry = "SELECT Name, Surname, User_ID FROM Contact;";

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
                                string name = reader["Name"].ToString();
                                string surname = reader["Surname"].ToString();
                                int userId = 0;

                                // User_ID'nin doğru bir int olup olmadığını yoxlamaq
                                if (int.TryParse(reader["User_ID"].ToString(), out userId))
                                {
                                    var user = new Contact(name, surname, userId);
                                    userList.Add(user);
                                }
                                else
                                {
                                    // İstədiyiniz halda, hər hansı bir səhv hallarda nə baş verəcəyini burada idarə edə bilərsiniz
                                    Console.WriteLine("User_ID dəyəri düzgün deyil.");
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

            return userList;
        }

    }
}
