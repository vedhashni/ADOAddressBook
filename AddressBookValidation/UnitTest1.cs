using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ADOAddressBook;

namespace AddressBookValidation
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepository addrBookRepo;
        ERRepository eRRepoistory;
        Transaction transcation;
        [TestInitialize]
        public void Setup()
        {
            addrBookRepo = new AddressBookRepository();
            eRRepoistory = new ERRepository();
            transcation = new Transaction();
        }
        /// <summary>
        /// UC2-Retrieve the data using query and returns the count
        /// </summary>
        [TestMethod]
        public void TestMethodForRetriveDataUsingQuery()
        {
            int expected = 4;
            var actual = addrBookRepo.RetrieveData();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC3-Insert the values in address_book_table
        /// </summary>
        [TestMethod]
        public void TestMethodInsertIntoTable()
        {
            int expected = 1;
            AddressBookModel addrBook = new AddressBookModel();
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
            var actual = addrBookRepo.InsertIntoTable(addrBook);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC4-Edit the existing contact using update query(by their name)
        /// </summary>
        [TestMethod]
        public void TestMethodForUpdateQuery()
        {
            int expected = 1;
            AddressBookModel addrBook = new AddressBookModel();
            var actual = addrBookRepo.EditExistingContact(addrBook);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC5-Delete the contact using name
        /// </summary>
        [TestMethod]
        public void TestMethodForDeleteContactUsingName()
        {
            int expected = 1;
            AddressBookModel addrBook = new AddressBookModel();
            var actual = addrBookRepo.DeleteParticularContact(addrBook);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC6-Retrieve Data Based on City and State
        /// </summary>
        [TestMethod]
        public void TestMethodForRetrieveDataBasedOnCityAndState()
        {
            int expected = 2;
            AddressBookModel model = new AddressBookModel();
            var actual = addrBookRepo.RetrieveDataBasedOnStateAndCity(model);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC7-Size Of addressBook by City and State
        /// </summary>
        [TestMethod]
        public void TestMethodForCountGroupByCityAndState()
        {
            var expected = "1 TamilNadu Coimbatore 3 TamilNadu Chennai ";
            AddressBookModel model = new AddressBookModel();
            var actual = addrBookRepo.RetrieveCountGroupByStateAndCity(model);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC8-Retrieve Data Sorted Alphabetically by Name for a City
        /// </summary>
        [TestMethod]
        public void TestMethodForSortAlphabeticallyByNameAndGivenCity()
        {
            int expected = 2;
            AddressBookModel model = new AddressBookModel();
            var actual = addrBookRepo.RetrieveDataBySortedAlphabetically(model);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC10-Get Count By RelationType
        /// </summary>
        [TestMethod]
        public void TestMethodForCountRelationType()
        {
            var expected = "2 Family 1 Friend 1 Profession ";
            AddressBookModel model = new AddressBookModel();
            var actual = addrBookRepo.CountRelationType(model);
            Assert.AreEqual(expected, actual);
        }

        //------------------Implementing ER Diagram Relationship------------------
        /// <summary>
        /// ----UC6--->Retrieve Person Belonging to  City or State
        /// </summary>
        [TestMethod]
        public void TestMethodForPrintDataBasedOnCityAndStateUisngERRelationship()
        {
            int expected = 3;
            AddressBookModel model = new AddressBookModel();
            int actual = eRRepoistory.PrintDataBasedOnCityAndStateUisngERRelationship(model);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// ----UC7--->Size of state and city
        /// </summary>
        [TestMethod]
        public void TestMethodForCountCityAndStateUsingERRelationship()
        {
            var expected = "1 TamilNadu Coimbatore 2 Tamil Nadu Chennai ";
            AddressBookModel model = new AddressBookModel();
            var actual = eRRepoistory.CountStateAndCityUsingERDiagram(model);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// -----UC8--->Retrieve the person data entries sorted alphabetically
        /// </summary>
        [DataTestMethod]
        public void SortedTheirNameUsingERRelationship()
        {
            int expected = 5;
            AddressBookModel model = new AddressBookModel();
            int actual = eRRepoistory.SortedtheirNameUsingERDiagram(model);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// ---	UC9--->Get Number Of contact persons by type
        /// </summary>
        [TestMethod]
        public void TestMethodForRelationTypeUsingERRelationship()
        {
            var expected = "2 Family 1 Friends 1 Profession ";
            AddressBookModel model = new AddressBookModel();
            var actual = eRRepoistory.CountTypeNameUsingERDiagram(model);
            Assert.AreEqual(expected, actual);
        }

        public void TestMethodForAddingADateColumn()
        {
            int expected = 2;
            int actual = transcation.UpdateStartDateValueBasedOnContctId();
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Retrieve teh details based on date range
        /// </summary>
        [TestMethod]
        public void RetrieveDataBasedOnDateRange()
        {
            int expected = 2;
            int actual = transcation.RetrieveDataBasedOnDateRange();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///  Insert into tables using transcation
        /// </summary>
        [DataTestMethod]
        public void TestMethodForInsertIntoTablesUsingTranscation()
        {
            int expected = 1;
            int actual = transcation.InsertIntoTablesUsingTranscation();
            Assert.AreEqual(expected, actual);
        }
    }
}
