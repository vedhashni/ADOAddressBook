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
            ERRepository eRRepoistory = new ERRepository();
            Transaction transcation = new Transaction();

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

                case 3:
                    addrBookRepo.EditExistingContact(addrBook);
                    break;

                case 4:
                    addrBookRepo.DeleteParticularContact(addrBook);
                    break;

                case 5:
                    addrBookRepo.RetrieveDataBasedOnStateAndCity(addrBook);
                    break;

                case 6:
                    addrBookRepo.RetrieveCountGroupByStateAndCity(addrBook);
                    break;

                case 7:
                    addrBookRepo.RetrieveDataBySortedAlphabetically(addrBook);
                    break;

                case 8:
                    addrBookRepo.CountRelationType(addrBook);
                    break;

                case 9:
                    eRRepoistory.PrintDataBasedOnCityAndStateUisngERRelationship(addrBook);
                    break;
                case 10:
                    eRRepoistory.CountStateAndCityUsingERDiagram(addrBook);
                    break;
                case 11:
                    eRRepoistory.CountTypeNameUsingERDiagram(addrBook);
                    break;
                case 12:
                    eRRepoistory.SortedtheirNameUsingERDiagram(addrBook);
                    break;

                case 13:
                   
                    transcation.UpdateStartDateValueBasedOnContctId();
                    break;

                case 14:
                    transcation.RetrieveDataBasedOnDateRange();
                    break;
            }
        }
        }
    }
}
