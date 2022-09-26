using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Interfaces
{
    public interface IAddressBookRepository
    {
        public string CreateFilePath();
        /* Metod för att göra det möjligt för användaren att lägga in en egen filepath. */
        public void SaveAddressBook(List<Contact> addressBook);
        /* Metod som sparar adressboken till en fil. Kommer att behöva
           list som parameter. */
        public List<Contact> ReadAddressBook(string filePath);
        /* Metod som läser adressboken från en fil. */
    }
}
