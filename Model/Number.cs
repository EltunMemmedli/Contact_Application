using Contact_Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Application.Model
{
    public class Number
    {
        public int ID { get; set; }
        public string Numbers { get; set; }
        public int Contact_ID { get; set; }

        public Number(string name, int contact_ID)
        {
            NumberID.CurrentNumberID += 1;
            this.ID = NumberID.CurrentNumberID;

            this.Numbers = name;
            this.Contact_ID = contact_ID;
        }
    }
}
