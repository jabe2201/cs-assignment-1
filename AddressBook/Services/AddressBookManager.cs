using AddressBook.Interfaces;
using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class AddressBookManager : IAddressBookManager
    {
        public Contact CreateContact()
        {
            var contact = new Contact();
            /* Instanserar en kontakt för metoden att fylla.*/
            Console.WriteLine("         ADD CONTACT         \n");
            Console.Write("Enter First Name: "); contact.FirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(contact.FirstName))
            {
                Console.WriteLine("Must enter a name.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Enter First Name: "); contact.FirstName = Console.ReadLine();

            }
            /* Med denna while-loop kontrollerar jag så att jag inte får in tomma kontakter i adressboken. */
            Console.Write("Enter Last Name: "); contact.LastName = Console.ReadLine();
            Console.Write("Enter Street Address: "); contact.StreetAddress = Console.ReadLine();
            Console.Write("Enter City: "); contact.City = Console.ReadLine();
            Console.Write("Enter Phone number: "); contact.PhoneNumber = Console.ReadLine();
            return contact;
        }

        public void EditContact(ref List<Contact> addressBook, Guid id, string filePath)
        {
            int index = addressBook.FindIndex(x => x.Id == id);
            /* FindIndex söker igenom addressboken efter det Guid id som jag har skickat med ifrån Search- och ManageContact och ger tillbaka positionen i adressbokens index som
               just det id:et har. Jag använder sedan detta index-värde för att hitta rätt rad i listan som utgör addressbook för att kunna ändra uppgifter om en kontakt.*/
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("         EDIT CONTACT        \n");
                Console.WriteLine($"Name: {addressBook[index].FirstName} {addressBook[index].LastName}\nAdress: {addressBook[index].StreetAddress}, {addressBook[index].City} \nPhone: {addressBook[index].PhoneNumber}\n");
                Console.WriteLine("1. First Name.");
                Console.WriteLine("2. Last Name.");
                Console.WriteLine("3. Street Address.");
                Console.WriteLine("4. City.");
                Console.WriteLine("5. Phone Number.");
                Console.Write("Please choose what you would like to edit:");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter First Name: ");
                        addressBook[index].FirstName = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter Last Name: ");
                        addressBook[index].LastName = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Enter Street Address: ");
                        addressBook[index].StreetAddress = Console.ReadLine();
                        break;
                    case "4":
                        Console.Write("Enter City: ");
                        addressBook[index].City = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Enter Phone Number: ");
                        addressBook[index].PhoneNumber = Console.ReadLine();
                        break;
                }
                Console.Clear();
                Console.WriteLine($"Name: {addressBook[index].FirstName} {addressBook[index].LastName}\nAdress: {addressBook[index].StreetAddress}, {addressBook[index].City} \nPhone: {addressBook[index].PhoneNumber}\n");
                Console.ReadKey();
                var addressBookRepository = new AddressBookRepository();
                addressBookRepository.SaveAddressBook(addressBook, filePath);
                Console.Write("Would you like to edit something else (Y/N): ");
                option = Console.ReadLine().ToLower();
                
            }
            while (option == "y");
            /* Jag valde här en do-while loop för att tillåta användaren att ändra flera uppgifter för samma kontakt utan att behöva återvända till huvudmenyn.*/
        }

        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("         ADDRESS BOOK         \n");
            Console.WriteLine("1. View Address book");
            Console.WriteLine("2. Add Contact to your Address book");
            Console.WriteLine("3. Search Contact\n");
            Console.WriteLine("Q. To Exit Addressbook");
            Console.Write("\nPlease enter an Option: ");
            return (Console.ReadLine());
            /* Visar menyvalen och returnerar användarens val till programmet.*/
        }

        public void ManageContactMenu(ref List<Contact> addressBook, Guid id, string filePath)
        {
            Console.Clear();
            Console.WriteLine("         MANAGE CONTACT      \n");
            Console.WriteLine("1. Change contat");
            Console.WriteLine("2. Remove contact");
            Console.Write("Enter command: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditContact(ref addressBook, id, filePath);
                    break;
                case "2":
                    RemoveContact(ref addressBook, id, filePath);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Not a valid command.");
                    Console.ReadKey();
                    break;
            }
            /* Jag väljer här att skicka adressboken som en ref eftersom jag vill kunna ändra direkt i listan och inte i en kopia och returnera den. Det tillåter mig också
               att använda .Where för att ta bort en kontakt. */
        }

        public void RemoveContact(ref List<Contact> addressBook, Guid id, string filePath)
        {
            var addressBookRepo = new AddressBookRepository();
            /* Instansering för att kunna spara adressboken när en kontakt är borttagen.*/ 
            addressBook = addressBook.Where(x => x.Id != id).ToList();
            /* Skapar en ny lista som innehåller alla positioner förutom det objekt som innehåller Guid id:et som jag har skickat med till funktionen. */
            addressBookRepo.SaveAddressBook(addressBook, filePath);
            Console.Clear();
            Console.WriteLine("Contact was succesfully removed.");
            Console.ReadKey();
        }

        public void SearchContact(ref List<Contact> addressBook, string filePath)
        {
            string searchName;
            string searchOption;
            var addressBookManager = new AddressBookManager(); 
            Console.Clear();
            Console.WriteLine("         SEARCH CONTACT      \n");
            Console.Write("Search by (F) First name or (L) Last name: "); searchOption = Console.ReadLine().ToLower();
            Console.Clear();
            switch (searchOption)
            {

                case "f":
                    Console.Write("Enter Name: ");
                    searchName = Console.ReadLine();
                    Console.Clear();
                    var firstAddressBook = addressBook.Where(x => x.FirstName == searchName).ToList();
                    /* Jag skapar här en ny lista eftersom en adressbok kan innehålla många kontakter med samma för eller efternamn. */
                    if (firstAddressBook.Count == 0)
                    {
                        Console.WriteLine("There is no contact with that name in your Addressbook.");
                        Console.ReadKey();
                    }
                    else
                    {
                        addressBookManager.ViewAddressBook(firstAddressBook);
                        Console.Write("Would you like to manage contact (Y/N): ");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            try
                            {
                                Console.Write("\nPlease enter Contact Number of the Contact you would like to manage: ");
                                var index = int.Parse(Console.ReadLine());
                                var id = firstAddressBook[index - 1].Id;
                                /* Eftersom mitt index i ViewAddressBook inte börjar på noll utan ett måste jag här dra av ett för att få fram rätt Guid Id. Detta är det Id som jag kommer att
                                   använda när jag tar bort eller ändrar i en kontakt, min markör för att hitta rätt objekt i listan.*/
                                addressBookManager.ManageContactMenu(ref addressBook, id, filePath);
                            }
                            catch
                            {
                                Console.WriteLine("Contact Number does not exsist.");
                                Console.ReadKey();
                            }
                            /* try-catch ser här till att vi inte kastas ut ur SearchContact om vi slår in en siffra som inte finns i adressboken. */
                        }
                    }
                    break;
                case "l":
                    Console.Write("Enter Name: ");
                    searchName = Console.ReadLine();
                    Console.Clear();

                    var lastAddressBook = addressBook.Where(x => x.LastName == searchName).ToList();
                    if (lastAddressBook.Count == 0)
                    {
                        Console.WriteLine("There is no contact with that name in your Addressbook.");
                        Console.ReadKey();
                    }
                    else
                    {
                        addressBookManager.ViewAddressBook(lastAddressBook);
                        Console.Write("Would you like to manage contact (Y/N): ");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            try
                            {
                                Console.Write("\nPlease enter Contact Number of the Contact you would like to manage: ");
                                var index = int.Parse(Console.ReadLine());
                                var id = lastAddressBook[index - 1].Id;
                                addressBookManager.ManageContactMenu(ref addressBook, id, filePath);
                            }
                            catch
                            {
                                Console.WriteLine("Contact Number does not exsist.");
                                Console.ReadKey();
                            }

                        }
                    }
                    break;
                default:
                    Console.WriteLine("Not a valid command.");
                    Console.ReadKey();
                    SearchContact(ref addressBook, filePath);
                    /* Skickar tillbaka oss till början av SearchContact ifall vi slår in fel och skickar oss inte tillbaka till huvudmenyn.*/
                    break;

            }
        }
        public void ViewAddressBook(List<Contact> addressBook)
        {
            if (addressBook.Count == 0)
            {
                Console.WriteLine("Your AddressBook is empty.");
            }
            else
            {
                Console.WriteLine("         CONTACTS         \n");
                for (int i = 0; i < addressBook.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {addressBook[i].FirstName} {addressBook[i].LastName}");
                    Console.WriteLine("__________________\n\n");
                }
                /* Jag har här valt att använda en for-loop eftersom jag satt Id som en Guid och det inte säger så mycket. Jag skapar därför ett index istället 
                   som är oberoende av kontakternas Id-värden. */
            }
        }
    }
}
