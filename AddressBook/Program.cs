using AddressBook.Services;

var addressBookRepository = new AddressBookRepository();

var addressBook = addressBookRepository.ReadAddressBook();

var addressBookManager = new AddressBookManager();

while (true)
{
    var option = addressBookManager.MainMenu();
}