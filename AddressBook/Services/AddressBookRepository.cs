using AddressBook.Interfaces;
using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private static readonly string _filePath = @"C:\Users\jacob\Documents\Nackademin\ProgrammeringC#\ovningar\AddressBook\addressbook.json";
        /* Här skapar jag en sökväg dit filen ska sparas. Jag vill inte att denna ska kunna manipuleras någonstans i programmet och har därför
           satt den till "private static readonly" */

        public List<Contact> ReadAddressBook()
        {
            if(!File.Exists(_filePath))
            {
                using (File.Create(_filePath))
                return new List<Contact>();
            }
            /* If-satsen kollar först om sökvägen finns, om inte så skapar den en ny sökväg och en ny lista som den skickar tillbaka till main. */
            var data = File.ReadAllText(_filePath);
            var addressBook = JsonSerializer.Deserialize<List<Contact>>(data);
            return addressBook;
            /* Läser in ifrån json-filen och skapar en lista som går att använda i main programmet och returnerar denna. */
        }

        public void SaveAddressBook(List<Contact> addressBook)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            /* Indenterar raderna så att det blir lättare att läsa dokumentet. */
            string json = JsonSerializer.Serialize(addressBook, options);
            File.WriteAllText(_filePath, json);
            /* Gör om adressboken till en string i json-format och läser in denna i en fil som den sparar där sökvägen pekar. */
        }
    }
}
