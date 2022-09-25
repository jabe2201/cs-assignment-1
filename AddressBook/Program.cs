﻿using AddressBook.Model;
using AddressBook.Services;

var addressBookRepository = new AddressBookRepository();

var addressBook = addressBookRepository.ReadAddressBook();

var addressBookManager = new AddressBookManager();

while (true)
{
    var option = addressBookManager.MainMenu();
    switch (option)
    {
        case "1":
            Console.Clear();
            addressBookManager.ViewAddressBook(addressBook);
            Console.ReadKey();
            break;
        case "2":
            Console.Clear();
            var contact = addressBookManager.CreateContact();
            addressBook.Add(contact);
            addressBookRepository.SaveAddressBook(addressBook);
            Console.WriteLine("Contact successfully added.");
            Console.ReadKey();
            break;
        case "3":
            addressBookManager.SearchContact(ref addressBook);  
            break;
        case "Q":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid command.");
            Console.ReadKey();
            break;
    }
}