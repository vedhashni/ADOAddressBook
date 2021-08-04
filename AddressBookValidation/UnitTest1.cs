using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ADOAddressBook;

namespace AddressBookValidation
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepository addrBookRepo;
        [TestInitialize]
        public void Setup()
        {
            addrBookRepo = new AddressBookRepository();
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
    }
}
