﻿namespace test.Models
{
    public class PhoneType
    {
        public int PhoneTypeId { get; set; }
        public string PhoneTypeName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}