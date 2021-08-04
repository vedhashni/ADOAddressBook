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
            Console.WriteLine("1.Connecting to DB And Retrieve the data from sql server");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    addrBookRepo.RetrieveData();
                    break;
            }
        }
    }
}
