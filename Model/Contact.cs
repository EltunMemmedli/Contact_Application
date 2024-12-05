using Contact_Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Application.Model
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int User_ID { get; set; }

        public Contact(string name, string surname, int user_ID)
        {
            ContactID.CurrentContactID += 1;
            this.ID = ContactID.CurrentContactID;

            this.Name = name;
            this.Surname = surname;
            this.User_ID = user_ID;
        }
    }
}
