using AddressBook.Interfaces;
using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public void EditContact(ref List<Contact> addressBook, Guid id)
        {
            string index = addressBook.FindIndex(x => x.Id == id).ToString();
            int _index = int.Parse(index);
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("         EDIT CONTACT        ");
                Console.WriteLine($"Name: {addressBook[_index].FirstName} {addressBook[_index].LastName}\nAdress: {addressBook[_index].StreetAddress}, {addressBook[_index].City} \nPhone: {addressBook[_index].PhoneNumber}\n");
                Console.WriteLine("1. First Name.");
                Console.WriteLine("2. Last Name.");
                Console.WriteLine("3. Street Address.");
                Console.WriteLine("4. City.");
                Console.WriteLine("5. Phone Number.");
                Console.Write("Please choose what you would like to edit:");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter First Name: ");
                        addressBook[_index].FirstName = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter Last Name: ");
                        addressBook[_index].LastName = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Enter Street Address: ");
                        addressBook[_index].StreetAddress = Console.ReadLine();
                        break;
                    case "4":
                        Console.Write("Enter City: ");
                        addressBook[_index].City = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Enter Phone Number: ");
                        addressBook[_index].PhoneNumber = Console.ReadLine();
                        break;
                }
                Console.Clear();
                Console.WriteLine($"Name: {addressBook[_index].FirstName} {addressBook[_index].LastName}\nAdress: {addressBook[_index].StreetAddress}, {addressBook[_index].City} \nPhone: {addressBook[_index].PhoneNumber}\n");
                Console.ReadKey();
                var addressBookRepository = new AddressBookRepository();
                addressBookRepository.SaveAddressBook(addressBook);
                Console.Write("Would you like to edit something else (Y/N): ");
                option = Console.ReadLine().ToLower();
                
            }
            while (option == "y");
            

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

        public void ManageContactMenu(ref List<Contact> addressBook, Guid id)
        {
            Console.Clear();
            Console.WriteLine("Manage Contact\n");
            Console.WriteLine("1. Change contat");
            Console.WriteLine("2. Remove contact");
            Console.Write("Enter command: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditContact(ref addressBook, id);
                    break;
                case "2":
                    RemoveContact(ref addressBook, id);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Not a valid command.");
                    Console.ReadKey();
                    break;
            }
        }

        public void RemoveContact(ref List<Contact> addressBook, Guid id)
        {
            var addressBookRepo = new AddressBookRepository();
            addressBook = addressBook.Where(x => x.Id != id).ToList();
            addressBookRepo.SaveAddressBook(addressBook);
        }

        public void SearchContact(ref List<Contact> addressBook)
        {
            string searchName;
            string searchOption;
            var addressBookManager = new AddressBookManager(); // du behöver inte ha denna!
            Console.Clear();
            Console.WriteLine("         SEARCH CONTACT      ");
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
                        Console.WriteLine("         CONTACTS IN YOUR ADDRESSBOOK        \n");
                        addressBookManager.ViewAddressBook(firstAddressBook);
                        Console.WriteLine("_____________________________________________\n");
                        Console.Write("Would you like to manage contact (Y/N): ");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            try
                            {
                                Console.Write("\nPlease enter Contact Number of the Contact you would like to manage: ");
                                var index = int.Parse(Console.ReadLine());
                                var id = firstAddressBook[index - 1].Id;
                                addressBookManager.ManageContactMenu(ref addressBook, id);
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
                                addressBookManager.ManageContactMenu(ref addressBook, id);
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
