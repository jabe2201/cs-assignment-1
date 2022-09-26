using AddressBook.Interfaces;
using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class AddressBookRepository : IAddressBookRepository
    {
        public string CreateFilePath()
        {
            Console.Write("Please enter a filepath that you would like to use to save your Address Book: ");
            string filePath = Console.ReadLine(); 
            filePath = $@"{filePath}\addressbook.json";
            return filePath;
            /* Metoden tillåter användaren att själv ange vart den ösnkar spara adressboken. Jag lägger sedan till den nödvändiga informationen som måste
               finnas med i stringen för att File.Create ska kunna skapa en fil utav det.*/
        }
        public List<Contact> ReadAddressBook(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                return new List<Contact>();
            }
            /* If-satsen kollar först om sökvägen finns, om inte så skapar den en ny sökväg och en ny lista som den skickar tillbaka till main. */
            var data = File.ReadAllText(filePath);
            if(data.Count() == 0) 
            {
                return new List<Contact>();
            }
            /* Kontrollerar om listan är tom. För om den är det så kraschar programmet när vi kör det. */
            else
            {
                var addressBook = JsonSerializer.Deserialize<List<Contact>>(data);
                return addressBook;
                /* Läser in ifrån json-filen och skapar en lista som går att använda i main programmet och returnerar denna. */
            }
        }

        public void SaveAddressBook(List<Contact> addressBook, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            /* Indenterar raderna så att det blir lättare att läsa dokumentet. */
            string json = JsonSerializer.Serialize(addressBook, options);
            File.WriteAllText(filePath, json);
            /* Gör om adressboken till en string i json-format och läser in denna i en fil som den sparar där sökvägen pekar. */
        }
    }
}
