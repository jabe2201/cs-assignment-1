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
            throw new NotImplementedException();
        }

        public void EditContact()
        {
            throw new NotImplementedException();
        }

        public int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("         ADDRESS BOOK         ");
            Console.WriteLine("1. View Address book");
            Console.WriteLine("2. Add Contact to your Address book");
            Console.WriteLine("3. Search Contact");
            Console.Write("\nPlease enter an Option: ");
            return int.Parse(Console.ReadLine());
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

        public void ViewAddressBook()
        {
            throw new NotImplementedException();
        }
    }
}
