using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOAddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");

           AddressBookRepository addrBookRepo = new AddressBookRepository();
            AddressBookModel addrBook = new AddressBookModel();
            
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    addrBookRepo.RetrieveData();
                    break;

                case 2:
                    addrBook.firstName = "mohana";
                    addrBook.lastName = "vijay";
                    addrBook.address = "1st street";
                    addrBook.city = "Trichy";
                    addrBook.stateName = "Tamilnadu";
                    addrBook.zipCode = "600098";
                    addrBook.phoneNum = 9856723560;
                    addrBook.emailId = "mohana@gmail.com";
                    addrBook.addrBookName = "Cousin";
                    addrBook.relationType = "Family";
                    addrBookRepo.InsertIntoTable(addrBook);
                    break;
            }
        }
    }
}
