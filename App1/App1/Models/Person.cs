using System;

namespace App1.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public KeyValue MaritalStatus { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
    }
}