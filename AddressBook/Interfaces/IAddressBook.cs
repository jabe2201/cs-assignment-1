using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Interfaces
{
    internal interface IAddressBook
    {
        public void SaveAddressBook();
        /* Metod som sparar adressboken till en fil. Kommer att behöva
           list som parameter. */
        public List<Contact> ReadAddressBook();
        /* Metod som läser adressboken från en fil. */
        public void MainMenu();
        
        public void ViewAddressBook();
        /* Metod som listar alla kontakter i adressboken. */
        public Contact CreateContact();
        /* Tar emot en kontakt och låter användaren fylla den med uppgifter.
           Returnerar sedan den färdiga kontakten rätt in i adressboken. */
        public void SearchContact();
        /* Tar emot adressboken som en list och ber användaren om ett söknamn
           att söka igenom list med. */
        public void ManageContactMenu();
        /* Menyval efter att användaren sökt upp en specifik kontakt. */
        public void RemoveContact();
        /* Ska ligga under "ManageContactMenu" */
        
        public void EditContact();
        /* Tillåter användaren att ändra uppgifter om en speciell kontakt.
           Ska ligga under "ManageContactMenu". */



    }
}
