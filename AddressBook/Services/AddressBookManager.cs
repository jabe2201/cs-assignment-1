using AddressBook.Interfaces;
using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class AddressBookManager : IAddressBookManager
    {
        public Contact CreateContact()
        {
            var contact = new Contact();
            Console.WriteLine("         ADD CONTACT         ");
            Console.Write("Enter First Name: "); contact.FirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(contact.FirstName))
            {
                Console.WriteLine("Must enter a name.");
                Console.ReadKey();
                Console.Clear(); 
                Console.Write("Enter First Name: "); contact.FirstName = Console.ReadLine();

            }
            /* Med denna while-loop kontrollerar jag så att jag inte får in tomma kontakter i adressboken. */
            Console.Write("Enter Last Name: "); contact.LastName = Console.ReadLine();
            Console.Write("Enter Street Address: "); contact.StreetAddress = Console.ReadLine();
            Console.Write("Enter City: "); contact.City = Console.ReadLine();
            Console.Write("Enter Phone number: "); contact.PhoneNumber = Console.ReadLine();
            return contact;
        }

        public void EditContact()
        {
            throw new NotImplementedException();
        }

        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("         ADDRESS BOOK         ");
            Console.WriteLine("1. View Address book");
            Console.WriteLine("2. Add Contact to your Address book");
            Console.WriteLine("3. Search Contact\n");
            Console.WriteLine("Q. To Exit Addressbook");
            Console.Write("\nPlease enter an Option: ");
            return (Console.ReadLine());
        }

        public void ManageContactMenu()
        {
            throw new NotImplementedException();
        }

        public void RemoveContact()
        {
            throw new NotImplementedException();
        }

        public void SearchContact(ref List<Contact> addressBook)
        {
            string searchName;
            string searchOption;
            var addressBookManager = new AddressBookManager();
            Console.Clear();
            Console.WriteLine("Search for Contact");
            Console.Write("Search by (F) First name or (L) Last name: "); searchOption = Console.ReadLine().ToLower();
            
            Console.Clear();

            switch (searchOption)
            {

                case "f":
                    Console.Write("Enter Name: ");
                    searchName = Console.ReadLine();
                    Console.Clear();
                    
                    var firstAddressBook = addressBook.Where(x => x.FirstName == searchName).ToList();
                    if (firstAddressBook.Count == 0)
                    {
                        Console.WriteLine("There is no contact with that name in your Addressbook.");
                        Console.ReadKey();
                    }
                    else
                    {
                        addressBookManager.ViewAddressBook(firstAddressBook);
                        Console.Write("Would you like to manage contact (Y/N): ");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            try
                            {
                                Console.Write("\nPlease enter Contact Number of the Contact you would like to manage: ");
                                var index = int.Parse(Console.ReadLine());
                                var id = firstAddressBook[index - 1].Id;
                                //ManageContact.ManageContactMenu(ref addressBook, id);
                            }
                            catch
                            {
                                Console.WriteLine("Contact Number does not exsist.");
                                Console.ReadKey();
                            }

                        }
                    }
                    break;
                case "l":
                    Console.Write("Enter Name: ");
                    searchName = Console.ReadLine();
                    Console.Clear();

                    var lastAddressBook = addressBook.Where(x => x.LastName == searchName).ToList();
                    if (lastAddressBook.Count == 0)
                    {
                        Console.WriteLine("There is no contact with that name in your Addressbook.");
                        Console.ReadKey();
                    }
                    else
                    {
                        addressBookManager.ViewAddressBook(lastAddressBook);
                        Console.Write("Would you like to manage contact (Y/N): ");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            try
                            {
                                Console.Write("\nPlease enter Contact Number of the Contact you would like to manage: ");
                                var index = int.Parse(Console.ReadLine());
                                var id = lastAddressBook[index - 1].Id;
                                //ManageContact.ManageContactMenu(ref addressBook, id);
                            }
                            catch
                            {
                                Console.WriteLine("Contact Number does not exsist.");
                                Console.ReadKey();
                            }

                        }
                    }
                    break;
                default:
                    Console.WriteLine("Not a valid command.");
                    Console.ReadKey();
                    break;
            }
        }

        public void ViewAddressBook(List<Contact> addressBook)
        {
                if (addressBook.Count == 0)
                {
                    Console.WriteLine("Your AddressBook is empty.");
                }
                else
                {
                    for (int i = 0; i < addressBook.Count; i++)
                    {
                        Console.WriteLine($"Contact number: {i + 1}.\nName: {addressBook[i].FirstName} {addressBook[i].LastName}\nAdress: {addressBook[i].StreetAddress}, {addressBook[i].City} \nPhone: {addressBook[i].PhoneNumber}\n");
                    }
                    /* Jag har här valt att använda en for-loop eftersom jag satt Id som en Guid och det inte säger så mycket. Jag skapar därför ett index istället 
                       som är oberoende av kontakternas Id-värden. */
                }

            
        }
    }
}
