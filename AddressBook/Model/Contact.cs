using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    internal class Contact
    {
        public Contact()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }

        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public string DisplayPerson => $"{FirstName} {LastName}";
        public string DisplayAddress => $"{StreetAddress}, {City}";

        /*
            Jag har för min klass "Contact" valt att använda mig av ett Guid istället för
            ett int Id. Detta för att inte behöva korrigera den numeriska ordningen på 
            kontakterna i min adressbok när en kontakt tas bort. För att inte Id:et ska vara 
            möjligt för en användare att ändra så har jag skapat en constructor som 
            sätter Id när en ny kontakt skapas.
         */

    }
}
