using Contact_Application.Controller;
using Contact_Application.Model;
using System.Collections;
UserController user = new();
ContactController contact = new();
NumberController Number = new();

Main_Menu:
Console.WriteLine("1.Sign In,\n" +
                  "2.Sign Up\n" +
                  "-----------------");
string secim = Console.ReadLine();
int Secim;
if(int.TryParse(secim, out Secim) && Secim > 0 && Secim < 3)
{
    if(Secim == 1)
    {
        Console.Clear();
        number:
        Console.WriteLine("Please, enter your phone number");
        string number = Console.ReadLine();

        if (number.Length == 13 && number.StartsWith("+994") && (number.Substring(4, 2) == "50" ||
                                         number.Substring(4, 2) == "55" ||
                                         number.Substring(4, 2) == "51" ||
                                         number.Substring(4, 2) == "77" ||
                                         number.Substring(4, 2) == "70"))
        {
            Console.Clear();
            List<User> Numbers = user.GetUsers();

            foreach (User item in Numbers)
            {
                if (number == item.Number)
                {
                User_Menu:
                    Console.WriteLine($"Hello {item.Name},\n" +
                                      $"1.Show Contacts,\n" +
                                      $"2.Add Contacts\n" +
                                      $"-----------------------");
                    string option = Console.ReadLine();
                    int Option;
                    if (int.TryParse(option, out Option) && Option > 0 && Option < 3)
                    {
                        if (Option == 1)
                        {
                            Console.Clear();
                            List<Contact> Contacts = contact.GetContacts();
                            foreach (Contact contacts in Contacts)
                            {
                                if(contacts.User_ID == item.ID)
                                {
                                    Console.WriteLine($"Name: {contacts.Name},\n" +
                                                  $"Surname: {contacts.Surname}\n");

                                }

                            }
                        AnaMenuKecini:
                            Console.WriteLine("\nPress 'f' to return Main Menu");
                            string AnaMenu = Console.ReadLine();
                            if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                            {
                                Console.Clear();
                                goto User_Menu;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Be sure to press correct button!");
                                goto AnaMenuKecini;
                            }
                        }
                        else if (Option == 2)
                        {
                            Console.Clear();
                            name:
                            Console.WriteLine("Please, insert contact's name");
                            string name = Console.ReadLine();
                            if (!(string.IsNullOrEmpty(name)))
                            {
                                Console.Clear();

                            surname:
                                Console.WriteLine("Please, insert contact's surname");
                                string surname = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(surname)))
                                {
                                    Console.Clear();

                                    int User_ID = item.ID;


                                    contact.AddContactDB(name, surname, User_ID);

                                    List<Contact> contacts = contact.GetContacts();
                                    List<Number> Contact_Number = Number.GetNumbers();

                                numbers:
                                    Console.WriteLine("Please, insert contact's number");
                                    string Contactnumber = Console.ReadLine();

                                    if (Contactnumber.Length == 13 && 
                                        Contactnumber.StartsWith("+994") &&
                                        (Contactnumber.Substring(4, 2) == "50" ||
                                         Contactnumber.Substring(4, 2) == "55" ||
                                         Contactnumber.Substring(4, 2) == "51" ||
                                         Contactnumber.Substring(4, 2) == "77" ||
                                         Contactnumber.Substring(4, 2) == "70"))
                                    {


                                        foreach (Contact item1 in contacts)
                                        {
                                            int ContactID = contacts.Count ;

                                            Console.WriteLine($"{ContactID}");
                                            foreach (Number item2 in Contact_Number)
                                            {
                                                if (!(Contactnumber == item2.Numbers))
                                                {
                                                    Number.AddNumbers(ContactID);

                                                    break;

                                                }

                                            }
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Try again");
                                        goto numbers;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Try again");
                                    goto surname;
                                }

                            }
                            else
                            {
                                Console.Clear ();
                                Console.WriteLine("Try Again");
                                goto name;
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Try Again");
                            goto User_Menu;
                        }
                    }
                }
            }
                
            
        }
        else
        {
            Console.WriteLine("Telefon nömrəsi düzgün deyil!");
        }
    }

    else if(Secim == 2)
    {
        Console.Clear();

        user.AddUserToDB();
    }
}
else 
{
    Console.Clear();
    Console.WriteLine("Try again!");
    goto Main_Menu;
}





