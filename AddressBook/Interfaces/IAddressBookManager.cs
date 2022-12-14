using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Interfaces
{
    internal interface IAddressBookManager
    {
        public string MainMenu();
        /* Visar huvudmenyn och ber användare göra ett val som den returnerar till main */
        public void ViewAddressBook(List<Contact> addressBook);

        public void DetailedView(List<Contact> addressBook);
        /* Metod som listar alla kontakter i adressboken. */
        public Contact CreateContact();
        /* Skapar en kontakt och låter användaren fylla den med uppgifter.
           Returnerar sedan den färdiga kontakten rätt in i adressboken. */
        public void SearchContact(ref List<Contact> addressBook, string filePath);
        /* Tar emot adressboken som en list och ber användaren om ett söknamn
           att söka igenom list med. */
        public void ManageContactMenu(ref List<Contact> addressBook, Guid id, string filePath);
        /* Menyval efter att användaren sökt upp en specifik kontakt. */
        public void RemoveContact(ref List<Contact> addressBook, Guid id, string filePath);
        /* Ska ligga under "ManageContactMenu" */
        public void EditContact(ref List<Contact> addressBook, Guid id, string filePath);
        /* Tillåter användaren att ändra uppgifter om en speciell kontakt.
           Ska ligga under "ManageContactMenu". */
    }
}
