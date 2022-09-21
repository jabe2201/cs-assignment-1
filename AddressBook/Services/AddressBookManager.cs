using AddressBook.Interfaces;
using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("3. Search Contact");
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

        public void SearchContact()
        {
            throw new NotImplementedException();
        }

        public void ViewAddressBook(List<Contact> addressBook)
        {
            if(addressBook.Count == 0)
            {
                Console.WriteLine("Your AddressBook is empty.");
            }
            else
            {
                for (int i = 0; i < addressBook.Count; i++)
                {
                    Console.WriteLine($"Contact number: {i + 1}.\nName: {addressBook[i].DisplayPerson}\nAdress: {addressBook[i].DisplayAddress}\nPhone: {addressBook[i].PhoneNumber}\n");
                }
                /* Jag har här valt att använda en for-loop eftersom jag satt Id som en Guid och det inte säger så mycket. Jag skapar därför ett index istället 
                   som är oberoende av kontakternas Id-värden. */
            }

        }
    }
}
