using Contact_Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Application.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }

        public User(string name, string surname, string number)
        {
            UserID.CurrentUserID += 1;
            this.ID = UserID.CurrentUserID;

            this.Name = name;
            this.Surname = surname;
            this.Number = number;
        }

    }
}
