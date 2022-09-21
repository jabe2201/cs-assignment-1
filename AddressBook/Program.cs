using AddressBook.Model;
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
            if(contact != null)
            {
                addressBook.Add(contact);
                addressBookRepository.SaveAddressBook(addressBook);
                Console.WriteLine("Contact successfully added.");
            }
            else
            {
                Console.WriteLine("Contact information cannot be empty. Contact was not added.");
            }
            

            break;

    }
}