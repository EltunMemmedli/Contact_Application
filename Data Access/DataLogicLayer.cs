using Contact_Application.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Application.Data_Access
{
    public class DataLogicLayer
    {
        public string Connection_String = "Data Source=(local);Database=Contact_Application;Integrated Security=sspi;";

        public void AddUser(User user)
        {
            string insertuser = "INSERT INTO Users (Name, Surname, Phone_Number) VALUES (@Name, @Surname, @Phone_Number);";

            using (SqlConnection Connection = new SqlConnection(Connection_String))
            {
                try
                {
                    Connection.Open();

                    using (SqlCommand command = new SqlCommand(insertuser, Connection))
                    {
                        command.Parameters.AddWithValue("@Name", user.Name);
                        command.Parameters.AddWithValue("@Surname", user.Surname);
                        command.Parameters.AddWithValue("@Phone_Number", user.Number);

                        command.ExecuteNonQuery();

                    }
                }
                catch(Exception exp) 
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }

        public void AddContact(Contact contact)
        {
            string insertcontact = "INSERT INTO Contact (Name, Surname, User_ID) VALUES (@Name, @Surname, @User_ID);";

            using (SqlConnection Connection = new SqlConnection(Connection_String))
            {
                try 
                {
                    Connection.Open();

                    using (SqlCommand command = new SqlCommand(insertcontact, Connection))
                    {
                        command.Parameters.AddWithValue("@Name", contact.Name);
                        command.Parameters.AddWithValue("@Surname", contact.Surname);
                        command.Parameters.AddWithValue("@User_ID", contact.User_ID);

                        command.ExecuteNonQuery ();
                    }
                } 
                catch (Exception exp) 
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }

        public void AddNumber(Number number)
        {
            string insertnumber = "INSERT INTO Numbers (Number, Contact_ID) VALUES (@Number, @Contact_ID);";

            using (SqlConnection Connection = new SqlConnection(Connection_String))
            {
                try 
                {
                    Connection.Open();

                    using (SqlCommand command = new SqlCommand(insertnumber, Connection))
                    {
                        command.Parameters.AddWithValue("@Number", number.Numbers);
                        command.Parameters.AddWithValue("@Contact_ID", number.Contact_ID);

                        command.ExecuteNonQuery ();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }
    }
}
