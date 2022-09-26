using AddressBook.Model;
using AddressBook.Services;

var addressBookRepository = new AddressBookRepository();

string filePath = addressBookRepository.CreateFilePath();

var addressBook = addressBookRepository.ReadAddressBook(filePath);
/* Läser in adressboken ifrån json-filen så att jag har en lokal kopia att arbeta med. */

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
            addressBookRepository.SaveAddressBook(addressBook, filePath);
            Console.WriteLine("Contact successfully added.");
            Console.ReadKey();
            break;
        case "3":
            addressBookManager.SearchContact(ref addressBook, filePath);  
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