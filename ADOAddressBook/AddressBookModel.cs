﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOAddressBook
{
    public class AddressBookModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }

        public string stateName { get; set; }
        public string zipCode { get; set; }
        public double phoneNum { get; set; }
        public string emailId { get; set; }

        public string addrBookName { get; set; }
        public string relationType { get; set; }
    }
}
