using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Interfaces
{
    public interface IAddressBookRepository
    {
        public void SaveAddressBook();
        /* Metod som sparar adressboken till en fil. Kommer att behöva
           list som parameter. */
        public List<Contact> ReadAddressBook();
        /* Metod som läser adressboken från en fil. */
    }
}
