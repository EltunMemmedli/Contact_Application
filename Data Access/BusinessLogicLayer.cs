using Contact_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Application.Data_Access
{
    public class BusinessLogicLayer
    {
        private DataLogicLayer DataLogicLayer;

        public BusinessLogicLayer()
        {
            DataLogicLayer = new DataLogicLayer();
        }

        public void CheckUser(User user)
        {
            if (
                !(user.Name == null &&
                  user.Number == null)
               )
            {
                DataLogicLayer.AddUser(user);
            }
            else
            {
                throw new Exception();
            }
        }

        public void CheckContact(Contact contact)
        {
            if (
                !(contact.Name == null)
                )
            {
                DataLogicLayer.AddContact(contact);
            }
            else
            {
                throw new Exception();
            }
        }

        public void CheckNumber(Number number)
        {
            if (
                !(number.Numbers == null)
                )
            {
                DataLogicLayer.AddNumber(number);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
