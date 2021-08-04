﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
